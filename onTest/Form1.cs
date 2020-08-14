namespace onTest
{
    using System;
    using System.Windows.Forms;
    using onMRZ;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mrzData = MRZParser.Parse(dfsMRZ.Text);
            dfsDocumentType.Text = mrzData.DocumentType;
            dfsIssuingCountry.Text = mrzData.IssuingCountryIso;
            dfsFirstName.Text = mrzData.FirstName;
            dfsLastName.Text = mrzData.LastName;
            dfsDocumentNumber.Text = mrzData.DocumentNumber;
            dfsNationality.Text = mrzData.NationalityIso;
            dfdDOB.Text = mrzData.DateOfBirth.ToString("dd/MM/yyyy");
            dfdExpireDate.Text = mrzData.ExpireDate.ToString("dd/MM/yyyy");
            dfsGender.Text = mrzData.Gender;
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            var mrzData = new MrzData
            {
                DocumentType = dfsDocumentType.Text,
                IssuingCountryIso = dfsIssuingCountry.Text,
                FirstName = dfsFirstName.Text,
                LastName = dfsLastName.Text,
                DocumentNumber = dfsDocumentNumber.Text,
                NationalityIso = dfsNationality.Text,
                DateOfBirth = DateTime.Parse(dfdDOB.Text),
                ExpireDate = DateTime.Parse(dfdExpireDate.Text),
                Gender = dfsGender.Text,
            };
        }
    }
}