using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_CERTIFICATION")]
    public class UDT_USER_CERTIFICATION
    {
        [UserDefinedTableTypeColumn(1)]
        public string CERTIFICATION { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int? CERTIFICATION_LEVEL { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string INSTITUTE { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public int? YEAR_OF_PASSING { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public int USER_CERTIFICATION_ID { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public bool ISNEW { get; set; }
    }
}
