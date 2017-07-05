namespace TIROERP.Core.Model
{
    public class UserCertification
    {
        public int CERTIFICATION_ID { get; set; }
        public int USER_CERTIFICATION_ID { get; set; }
        public string REGISTRATION_NUMBER { get; set; }
        public string CERTIFICATION { get; set; }
        public int? CERTIFICATION_LEVEL { get; set; }
        public string INSTITUTE { get; set; }
        public int? YEAR_OF_PASSING { get; set; }
        public bool IsNew { get; set; }
        public string OTHER_CERTIFICATION { get; set; }
    }
}
