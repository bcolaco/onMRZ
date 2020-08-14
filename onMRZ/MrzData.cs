namespace onMRZ
{
    using System;

    public class MrzData
    {
        public bool IsValid { get; set; }

        public string DocumentType { get; set; }

        public string AdditionalDocumentType { get; set; }

        public string IssuingCountryIso { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string DocumentNumber { get; set; }

        public string NationalityIso { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public DateTime ExpireDate { get; set; }

        public DateTime IssueDate { get; set; }
    }
}
