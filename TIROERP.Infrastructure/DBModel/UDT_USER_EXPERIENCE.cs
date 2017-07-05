using EntityFrameworkExtras.EF6;
using System;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_EXPERIENCE")]
    public class UDT_USER_EXPERIENCE
    {
        [UserDefinedTableTypeColumn(1)]
        public string USER_COMPANY_NAME { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public bool? IS_CURRENT_COMPANY { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public int? DESIGNATION_ID { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public int? INDUSTRY_ID { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string CITY_CODE { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? WORK_PERIOD_FROM { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public DateTime? WORK_PERIOD_TO { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string TOTAL_WORK_EXPERIENCE { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string REMARK { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public int EXPERIENCE_ID { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public bool ISNEW { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public String STATE_CODE { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public String COUNTRY_CODE { get; set; }
    }
}
