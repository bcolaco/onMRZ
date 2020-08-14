namespace OnMRZ
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// MRZ data holder.
    /// </summary>
    public class MrzData
    {
        /// <summary>
        /// Gets or sets the document type.
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the issuing country ISO3.
        /// </summary>
        public string IssuingCountryIso { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the nationality ISO3.
        /// </summary>
        public string NationalityIso { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the expire date.
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is MrzData data &&
                   this.DocumentType == data.DocumentType &&
                   this.IssuingCountryIso == data.IssuingCountryIso &&
                   this.FirstName == data.FirstName &&
                   this.LastName == data.LastName &&
                   this.DocumentNumber == data.DocumentNumber &&
                   this.NationalityIso == data.NationalityIso &&
                   this.DateOfBirth == data.DateOfBirth &&
                   this.Gender == data.Gender &&
                   this.ExpireDate == data.ExpireDate;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 1960940275;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.DocumentType);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.IssuingCountryIso);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.FirstName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.LastName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.DocumentNumber);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.NationalityIso);
            hashCode = (hashCode * -1521134295) + this.DateOfBirth.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(this.Gender);
            hashCode = (hashCode * -1521134295) + this.ExpireDate.GetHashCode();
            return hashCode;
        }
    }
}
