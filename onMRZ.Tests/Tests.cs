namespace onMRZ.Tests
{
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Tests
    {
        [Theory]
        [MemberData(nameof(ValidTestData))]
        private void Parse(string mrz, MrzData expectedData)
        {
            var data = MRZParser.Parse(mrz);
            data.Equals(expectedData).ShouldBeTrue();
        }

        [Theory]
        [MemberData(nameof(ValidTestData))]
        private void Create(string expectedMrz, MrzData data)
        {
            var mrz = MRZParser.CreatMrz(data);
            mrz.Equals(expectedMrz).ShouldBeTrue();
        }

        public static IEnumerable<object[]> ValidTestData
            => new List<object[]>
            {
                new object[]
                {
                    "P<GBRMALIK<<MUSSARAT<ZARIN<<<<<<<<<<<<<<<<<<5119237240GBR4612078F2212119<<<<<<<<<<<<<<04",
                    new MrzData
                    {
                        DocumentType = "P",
                        IssuingCountryIso = "GBR",
                        FirstName = "MUSSARAT ZARIN",
                        LastName = "MALIK",
                        DocumentNumber = "511923724",
                        NationalityIso = "GBR",
                        DateOfBirth = new DateTime(1946, 12, 07),
                        Gender = "F",
                        ExpireDate = new DateTime(2022, 12, 11),
                    }
                },
                new object[]
                {
                    "PMUSARAMBO<<JOHN<<<<<<<<<<<<<<<<<<<<<<<<<<<<12345678<8USA5001013M3001019<<<<<<<<<<<<<<04",
                    new MrzData
                    {
                        DocumentType = "PM",
                        IssuingCountryIso = "USA",
                        FirstName = "JOHN",
                        LastName = "RAMBO",
                        DocumentNumber = "12345678",
                        NationalityIso = "USA",
                        DateOfBirth = new DateTime(1950, 1, 1),
                        Gender = "M",
                        ExpireDate = new DateTime(2030, 1, 1),
                    }
                },
                new object[]
                {
                    "P<PRTREMEDIOS<<DIACONO<<<<<<<<<<<<<<<<<<<<<<8765432100PRT9702020M3001019<<<<<<<<<<<<<<00",
                    new MrzData
                    {
                        DocumentType = "P",
                        IssuingCountryIso = "PRT",
                        FirstName = "DIACONO",
                        LastName = "REMEDIOS",
                        DocumentNumber = "876543210",
                        NationalityIso = "PRT",
                        DateOfBirth = new DateTime(1997, 2, 2),
                        Gender = "M",
                        ExpireDate = new DateTime(2030, 1, 1),
                    }
                },
            };
    }
}
