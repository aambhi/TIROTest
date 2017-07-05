using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_EDUCATION")]
    public class UDT_USER_EDUCATION
    {
        [UserDefinedTableTypeColumn(1)]
        public int USER_EDUCATION_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int? EDUCATION_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public int? SPECIALIZATION_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string UNIVERSITY_ID { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string UNIVERSITY_YEAR_OF_PASSING { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public bool? IS_HIGHEST_QUALIFICATION { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public bool? MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public bool IsNEW { get; set; }
    }
}
