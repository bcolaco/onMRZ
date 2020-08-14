namespace onMRZ
{
    using System;
    using System.Collections.Generic;

    public static class MRZParser
    {
        private static readonly Dictionary<char, int> _checkDigitArray = new Dictionary<char, int>
        {
            {'<', 0},
            {'0', 0},
            {'1', 1},
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'A', 10},
            {'B', 11},
            {'C', 12},
            {'D', 13},
            {'E', 14},
            {'F', 15},
            {'G', 16},
            {'H', 17},
            {'I', 18},
            {'J', 19},
            {'K', 20},
            {'L', 21},
            {'M', 22},
            {'N', 23},
            {'O', 24},
            {'P', 25},
            {'Q', 26},
            {'R', 27},
            {'S', 28},
            {'T', 29},
            {'U', 30},
            {'V', 31},
            {'W', 32},
            {'X', 33},
            {'Y', 34},
            {'Z', 35},
        };

        /// <summary>
        /// Parses a MRZ string.
        /// </summary>
        /// <param name="mrz">The MRZ string to parse.</param>
        /// <returns>The parsed MRZ data.</returns>
        /// <seealso cref="https://en.wikipedia.org/wiki/Machine-readable_passport"/>
        /// <seealso cref="https://www.icao.int/publications/Documents/9303_p3_cons_en.pdf"/>
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

        /// <summary>
        /// Calculates the check digit from the document number.
        /// </summary>
        /// <param name="icaoPassportNumber">The ICAO document number.</param>
        /// <returns>The check digit.</returns>
        /// <seealso cref="http://www.highprogrammer.com/alan/numbers/mrp.html#checkdigit"/>
        internal static string CheckDigit(string icaoPassportNumber)
        {
            icaoPassportNumber = icaoPassportNumber.ToUpper();
            var inputArray = icaoPassportNumber.Trim().ToCharArray();
            var multiplier = 7;
            var total = 0;
            foreach (var dig in inputArray)
            {
                total += _checkDigitArray[dig] * multiplier;
                if (multiplier == 7) multiplier = 3;
                else if (multiplier == 3) multiplier = 1;
                else if (multiplier == 1) multiplier = 7;
            }

            Math.DivRem(total, 10, out long result);
            return result.ToString();
        }
    }
}
