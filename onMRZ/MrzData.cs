namespace onMRZ
{
    using System;
    using System.Collections.Generic;

    public class MrzData
    {
        public string DocumentType { get; set; }

        public string IssuingCountryIso { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentNumber { get; set; }

        public string NationalityIso { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public DateTime ExpireDate { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is MrzData data &&
                   DocumentType == data.DocumentType &&
                   IssuingCountryIso == data.IssuingCountryIso &&
                   FirstName == data.FirstName &&
                   LastName == data.LastName &&
                   DocumentNumber == data.DocumentNumber &&
                   NationalityIso == data.NationalityIso &&
                   DateOfBirth == data.DateOfBirth &&
                   Gender == data.Gender &&
                   ExpireDate == data.ExpireDate;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            int hashCode = 1960940275;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DocumentType);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(IssuingCountryIso);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DocumentNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NationalityIso);
            hashCode = hashCode * -1521134295 + DateOfBirth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gender);
            hashCode = hashCode * -1521134295 + ExpireDate.GetHashCode();
            return hashCode;
        }
    }
}
