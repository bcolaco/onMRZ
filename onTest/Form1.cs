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
            var customer = MRZParser.Parse(dfsMRZ.Text);
            dfsIssuingCountry.Text = customer.IssuingCountryIso;
            dfsFirstName.Text = customer.FirstName;
            dfsLastName.Text = customer.LastName;
            dfsDocumentNumber.Text = customer.DocumentNumber;
            dfsNationality.Text = customer.NationalityIso;
            dfdDOB.Text = customer.DateOfBirth.ToString("dd/MM/yyyy");
            dfdExpireDate.Text = customer.ExpireDate.ToString("dd/MM/yyyy");
            dfsGender.Text = customer.Gender;
        }

        private void btnMake_Click(object sender, EventArgs e)
        {
            var customer = new MrzData
            {
                IssuingCountryIso = dfsIssuingCountry.Text,
                FirstName = dfsFirstName.Text,
                LastName = dfsLastName.Text,
                DocumentNumber = dfsDocumentNumber.Text,
                NationalityIso = dfsNationality.Text,
                DateOfBirth = DateTime.Parse(dfdDOB.Text),
                ExpireDate = DateTime.Parse(dfdExpireDate.Text),
                Gender = dfsGender.Text
            };


            dfsMRZ.Text = MRZParser.CreatMrz(customer, false);
        }
    }
}