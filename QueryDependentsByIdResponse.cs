namespace MulesoftConsoleApp.QueryDependentsByIdResponse
{
    public class QueryDependentsByIdResponse
    {
        public BirthDate BirthDate { get; set; }
        public string Gender { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Name Name { get; set; }
        public Nationality Nationality { get; set; }
        public Occupation Occupation { get; set; }
        public Relationship Relationship { get; set; }
        public Religion Religion { get; set; }
        public Residency Residency { get; set; }
        public Sponsor Sponsor { get; set; }
        public Status Status { get; set; }
        public Travel Travel { get; set; }
        public Visa Visa { get; set; }
    }

    public class BirthDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class MaritalStatus
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public TranslatedName TranslatedName { get; set; }
    }

    public class TranslatedName
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
    }

    public class Nationality
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Occupation
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Relationship
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Religion
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ExpiryDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class IssueDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class Residency
    {
        public ExpiryDate ExpiryDate { get; set; }
        public string IdNo { get; set; }
        public string IdType { get; set; }
        public IssueDate IssueDate { get; set; }
        public string IssuePlace { get; set; }
    }

    public class Type
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Sponsor
    {
        public string IdNo { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Status { get; set; }
        public Type Type { get; set; }
    }

    public class PersonStatus
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Status
    {
        public string FingerPrintStatus { get; set; }
        public PersonStatus PersonStatus { get; set; }
        public string PrisonerStatus { get; set; }
    }

    public class EntryDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class LastEntryDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class LastExitDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class PassportExpiryDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class Travel
    {
        public EntryDate EntryDate { get; set; }
        public LastEntryDate LastEntryDate { get; set; }
        public LastExitDate LastExitDate { get; set; }
        public PassportExpiryDate PassportExpiryDate { get; set; }
        public string TravelStatus { get; set; }
    }

    public class VisaExpiryDate
    {
        public string GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class Visa
    {
        public string FinalExitVisaIssued { get; set; }
        public VisaExpiryDate VisaExpiryDate { get; set; }
        public string VisaType { get; set; }
    }


}