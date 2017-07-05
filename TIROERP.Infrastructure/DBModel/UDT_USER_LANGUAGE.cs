using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_LANGUAGE")]
    public class UDT_USER_LANGUAGE
    {
        [UserDefinedTableTypeColumn(1)]
        public int LANGUAGE_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public bool? IS_READ { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public bool? IS_WRITE { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public bool? IS_SPEAK { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public int USER_LANGUAGE_ID { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public bool ISNEW { get; set; }
    }
}
