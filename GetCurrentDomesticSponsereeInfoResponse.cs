using System;
using System.Collections.Generic;

namespace MulesoftConsoleApp.GetCurrentDomesticSponsereeInfoResponse
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class AlienFirstArrivalDate
    {
        public DateTime GregorianDate { get; set; }
        public string GregorianDateSpecified { get; set; }
        public string HijriDate { get; set; }
    }

    public class Occupation
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Sex
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class SponsereeInfo
    {
        public AlienFirstArrivalDate AlienFirstArrivalDate { get; set; }
        public string Id { get; set; }
        public string Nationality { get; set; }
        public Occupation Occupation { get; set; }
        public Sex Sex { get; set; }
        public string Status { get; set; }
        public string TravelStatus { get; set; }
    }

    public class DomesticSponseree
    {
        public List<SponsereeInfo> SponsereeInfo { get; set; }
    }

    public class GetCurrentDomesticSponsereeInfoResult
    {
        public DomesticSponseree DomesticSponseree { get; set; }
    }

    public class Root
    {
        public GetCurrentDomesticSponsereeInfoResult GetCurrentDomesticSponsereeInfoResult { get; set; }
    }


}
