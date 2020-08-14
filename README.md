# OnMRZ
This is a library that parses a machine readable zone (MRZ) found in Machine readable Documents for instance (Passport).
It parses PassportNumber, FirstName, LastName, dates (ex.date of birth, expire date), nationality and issuing country.

It can also generate the MRZ string itslef (Machine Readable Zone) if all the proper parameters are passed to it.


![image](https://user-images.githubusercontent.com/9623964/40993748-40a626e6-68af-11e8-8af7-714ac46944bb.png)

## Usage
### Parsing MRZ
```csharp
var data = MrzParser.Parse("PMUSARAMBO<<JOHN<<<<<<<<<<<<<<<<<<<<<<<<<<<<12345678<8USA5001013M3001019<<<<<<<<<<<<<<04");
Console.WriteLine(data.FirstName);
Console.WriteLine(data.LastName);
// Output:
// JOHN
// RAMBO
```
### Creating MRZ
```csharp
var data = new MrzData
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
var mrz = MrzParser.CreatMrz(data);
Console.WriteLine(mrz);
// Output:
// PMUSARAMBO<<JOHN<<<<<<<<<<<<<<<<<<<<<<<<<<<<12345678<8USA5001013M3001019<<<<<<<<<<<<<<04
```