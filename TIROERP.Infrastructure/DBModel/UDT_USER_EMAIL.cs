using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_EMAIL")]
    public class UDT_USER_EMAIL
    {
        [UserDefinedTableTypeColumn(1)]
        public string USER_EMAIL { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int USER_EMAIL_ID { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public bool ISNEW { get; set; }
    }
}
