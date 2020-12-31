

namespace MulesoftConsoleApp
{
    public class GetPersonInfoResponse
    {
        public class GetPersonInfoResult
        {
            public string BirthDateH { get; set; }
            public string FamilyName { get; set; }
            public string FamilyNameT { get; set; }
            public string FatherName { get; set; }
            public string FatherNameT { get; set; }
            public string FirstName { get; set; }
            public string FirstNameT { get; set; }
            public string GrandfatherName { get; set; }
            public string GrandfatherNameT { get; set; }
            public string HasSaudiDependents { get; set; }
            public string Id { get; set; }
            public string MaritalStatus { get; set; }
            public string Nationality { get; set; }
            public string Occupation { get; set; }
            public string Sex { get; set; }
            public string Status { get; set; }
        }

        public class Root
        {
            public GetPersonInfoResult GetPersonInfoResult { get; set; }
        }

    }
}
