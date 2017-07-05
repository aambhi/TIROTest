namespace TIROERP.Core.Model
{
    public class UserDocument
    {
        public int DOCUMENT_ID { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string DOCUMENT_TYPE_ID { get; set; }
        public string DOCUMENT_PATH { get; set; }
        public bool IsNew { get; set; }
    }
}
