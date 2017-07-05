using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_CONTACT")]
    public class UDT_USER_CONTACT
    {
        [UserDefinedTableTypeColumn(1)]
        public int CONTACT_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string CONTACT_NO { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public int USER_CONTACT_ID { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public bool ISNEW { get; set; }
    }
}
