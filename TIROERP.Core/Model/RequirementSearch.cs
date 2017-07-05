namespace TIROERP.Core.Model
{
    public class RequirementSearch
    {
        public string CLIENT_NAME { get; set; }
        public string COMPANY_NAME_ID { get; set; }
        public int REQIREMENT_ID { get; set; }
        public bool? STATUS { get; set; }
        public string JOB_TITLE { get; set; }
    }

    public class RequirementSearchResult
    {
        public int REQUIREMENT_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CLIENT_NAME { get; set; }
        public string STATUS { get; set; }
        public string JOB_TITLE { get; set; }
    }
}
