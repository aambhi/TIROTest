using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_ADDRESS")]
    public class UDT_USER_ADDRESS
    {
        [UserDefinedTableTypeColumn(1)]
        public int ADDRESS_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string ADDRESS { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string CITY_CODE { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string USER_VILLAGE { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string USER_PINCODE { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public int USER_ADDRESS_ID { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public bool ISNEW { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string STATE_CODE { get; set; }
    }
}
