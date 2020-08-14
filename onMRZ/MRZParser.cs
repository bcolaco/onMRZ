namespace onMRZ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class MRZParser
    {
        private static readonly Dictionary<char, int> _checkDigitArray = new Dictionary<char, int>();

        //Parsing is based on https://en.wikipedia.org/wiki/Machine-readable_passport
        //Useful information https://www.icao.int/publications/Documents/9303_p3_cons_en.pdf

        public static MrzData Parse(string mrz)
        {
            if (mrz == null)
            {
                throw new ArgumentNullException(mrz);
            }
            else if(mrz.Length != 88)
            {
                throw new ArgumentException($"MRZ length is not valid. Should be 88 but it is {mrz.Length}", nameof(mrz));
            }

            var output = new MrzData
            {
                DocumentType = DocumentType(mrz),
                Gender = Gender(mrz),
                ExpireDate = ExpireDate(mrz),
                IssuingCountryIso = IssuingCountryIso(mrz),
                FirstName = FirstName(mrz),
                LastName = LastName(mrz),
                DocumentNumber = DocumentNumber(mrz),
                NationalityIso = NationalityIso(mrz),
                DateOfBirth = DateOfBirth(mrz),
            };

            output.FullName = (output.FirstName + " " + output.LastName).Replace("  ", " ").Trim();
            output.IssueDate = IssueDate(output.ExpireDate, output.NationalityIso);

            return output;
        }

        private static string DocumentType(string mrz)
        {
            return mrz.Substring(0, 2).Replace("<", string.Empty);
        }

        private static string IssuingCountryIso(string mrz)
        {
            return mrz.Substring(2, 3);
        }

        private static string FirstName(string mrz)
        {
            var nameArraySplit = mrz.Substring(5).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries);
            return nameArraySplit.Length >= 2 ? nameArraySplit[1].Replace("<", " ") : nameArraySplit[0].Replace("<", " ");
        }

        private static string LastName(string mrz)
        {
            var nameArraySplit = mrz.Substring(5).Split(new[] { "<<" }, StringSplitOptions.RemoveEmptyEntries);
            return nameArraySplit.Length >= 2 ? nameArraySplit[0].Replace("<", " ") : string.Empty;
        }

        private static string DocumentNumber(string mrz)
        {
            return mrz.Substring(0 + 44, 9).Replace("<", string.Empty);
        }

        private static string NationalityIso(string mrz)
        {
            return mrz.Substring(10 + 44, 3);
        }

        private static DateTime DateOfBirth(string mrz)
        {
            var dob = new DateTime(int.Parse(DateTime.Now.Year.ToString().Substring(0, 2) + mrz.Substring(13 + 44, 2)), int.Parse(mrz.Substring(15 + 44, 2)),
                    int.Parse(mrz.Substring(17 + 44, 2)));

            if (dob < DateTime.Now)
                return dob;

            return dob.AddYears(-100); //Subtract a century
        }

        private static string Gender(string mrz)
        {
            return mrz.Substring(20 + 44, 1);
        }

        private static DateTime ExpireDate(string mrz)
        {
            //I am assuming all passports will certainly expire this century
            return new DateTime(int.Parse(DateTime.Now.Year.ToString().Substring(0, 2) + mrz.Substring(21 + 44, 2)), int.Parse(mrz.Substring(23 + 44, 2)),
                int.Parse(mrz.Substring(25 + 44, 2)));
        }

        private static DateTime IssueDate(DateTime expireDate, string nationality)
        {
            return new DateTime(1900, 1, 1); //todo calculate based on Expire Date and nationality
        }

        public static string CreatMrz(MrzData mrzData, bool isMakeFullName)
        {
            if (string.IsNullOrEmpty(mrzData.IssuingCountryIso) || string.IsNullOrEmpty(mrzData.LastName) || string.IsNullOrEmpty(mrzData.FirstName) || string.IsNullOrEmpty(mrzData.DocumentNumber) ||
                string.IsNullOrEmpty(mrzData.NationalityIso) || mrzData.DateOfBirth.Year < 1901 || string.IsNullOrEmpty(mrzData.Gender) || mrzData.ExpireDate.Year < 1901) return string.Empty;

            var docType = mrzData.DocumentType;
            if(docType.Length < 2)
            {
                docType += "<";
            }
            var line1 = docType + mrzData.IssuingCountryIso + (mrzData.LastName + "<<" + mrzData.FirstName).Replace(" ", "<");
            if (isMakeFullName)
                line1 = docType + mrzData.IssuingCountryIso + (mrzData.FirstName + "<" + mrzData.LastName).Replace(" ", "<");
            line1 = line1.PadRight(44, '<').Replace("-", "<");
            if (line1.Length > 44)
                line1 = line1.Substring(0, 44);
            var line2 = mrzData.DocumentNumber.PadRight(9, '<') + CheckDigit(mrzData.DocumentNumber.PadRight(9, '<')) + mrzData.NationalityIso +
                        mrzData.DateOfBirth.ToString("yyMMdd") +
                        CheckDigit(mrzData.DateOfBirth.ToString("yyMMdd")) + mrzData.Gender.Substring(0, 1) +
                        mrzData.ExpireDate.ToString("yyMMdd") +
                        CheckDigit(mrzData.ExpireDate.ToString("yyMMdd"));
            line2 = line2.PadRight(42, '<') + "0";
            var compositeCheckDigit =
                CheckDigit(line2.Substring(0, 10) + line2.Substring(13, 7) +
                           line2.Substring(21, 22));
            line2 = line2 + compositeCheckDigit.Replace("-", "<");
            return line1 + line2;
        }

        internal static string CheckDigit(string icaoPassportNumber)
        {
            //http://www.highprogrammer.com/alan/numbers/mrp.html#checkdigit
            if (!_checkDigitArray.Any())
                FillCheckDigitDictionary();
            icaoPassportNumber = icaoPassportNumber.ToUpper();
            var inputArray = icaoPassportNumber.Trim().ToCharArray();
            var multiplier = 7;
            var total = 0;
            foreach (var dig in inputArray)
            {
                total = total + _checkDigitArray[dig] * multiplier;
                if (multiplier == 7) multiplier = 3;
                else if (multiplier == 3) multiplier = 1;
                else if (multiplier == 1) multiplier = 7;
            }

            long result;
            Math.DivRem(total, 10, out result);
            return result.ToString();
        }

        private static void FillCheckDigitDictionary()
        {
            _checkDigitArray.Add('<', 0);
            _checkDigitArray.Add('0', 0);
            _checkDigitArray.Add('1', 1);
            _checkDigitArray.Add('2', 2);
            _checkDigitArray.Add('3', 3);
            _checkDigitArray.Add('4', 4);
            _checkDigitArray.Add('5', 5);
            _checkDigitArray.Add('6', 6);
            _checkDigitArray.Add('7', 7);
            _checkDigitArray.Add('8', 8);
            _checkDigitArray.Add('9', 9);
            _checkDigitArray.Add('A', 10);
            _checkDigitArray.Add('B', 11);
            _checkDigitArray.Add('C', 12);
            _checkDigitArray.Add('D', 13);
            _checkDigitArray.Add('E', 14);
            _checkDigitArray.Add('F', 15);
            _checkDigitArray.Add('G', 16);
            _checkDigitArray.Add('H', 17);
            _checkDigitArray.Add('I', 18);
            _checkDigitArray.Add('J', 19);
            _checkDigitArray.Add('K', 20);
            _checkDigitArray.Add('L', 21);
            _checkDigitArray.Add('M', 22);
            _checkDigitArray.Add('N', 23);
            _checkDigitArray.Add('O', 24);
            _checkDigitArray.Add('P', 25);
            _checkDigitArray.Add('Q', 26);
            _checkDigitArray.Add('R', 27);
            _checkDigitArray.Add('S', 28);
            _checkDigitArray.Add('T', 29);
            _checkDigitArray.Add('U', 30);
            _checkDigitArray.Add('V', 31);
            _checkDigitArray.Add('W', 32);
            _checkDigitArray.Add('X', 33);
            _checkDigitArray.Add('Y', 34);
            _checkDigitArray.Add('Z', 35);
        }
    }
}
