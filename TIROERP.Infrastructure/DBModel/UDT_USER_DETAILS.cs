using EntityFrameworkExtras.EF6;
using System;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_DETAILS")]
    public class UDT_USER_DETAILS
    {
        [UserDefinedTableTypeColumn(1)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string FIRST_NAME { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string MIDDLE_NAME { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string LAST_NAME { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string GAMCA_NO { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string FILE_NAME { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string FILE_PATH { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string WEBSITE { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string SKYPE { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public string REMARK { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string CONTACT_REMARK { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public int? AVAILING_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public int? SOURCE_ID { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public string OTHER_SOURCE { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public string REFERRER_NAME { get; set; }

        [UserDefinedTableTypeColumn(17)]
        public int? STATUS_ID { get; set; }

        [UserDefinedTableTypeColumn(18)]
        public int? REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(19)]
        public bool LOGIN_ACCESS { get; set; }

        [UserDefinedTableTypeColumn(20)]
        public string LOGIN_PASSWORD { get; set; }

        [UserDefinedTableTypeColumn(21)]
        public string MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(22)]
        public bool? IS_EXPERIENCED { get; set; }

        [UserDefinedTableTypeColumn(23)]
        public string EDUCATION_REMARK { get; set; }

        [UserDefinedTableTypeColumn(24)]
        public string WORK_REMARK { get; set; }

        [UserDefinedTableTypeColumn(25)]
        public string BRANCH_CODE { get; set; }

        [UserDefinedTableTypeColumn(26)]
        public string LOCATION_CODE { get; set; }

        [UserDefinedTableTypeColumn(27)]
        public string COMPANY_NAME { get; set; }

        [UserDefinedTableTypeColumn(28)]
        public string TOTAL_WORK_EXPERIENCE { get; set; }

        [UserDefinedTableTypeColumn(29)]
        public string TOTAL_GULF_EXPERIENCE { get; set; }

        [UserDefinedTableTypeColumn(30)]
        public string SKILLS { get; set; }

        [UserDefinedTableTypeColumn(31)]
        public string FATHER_NAME { get; set; }

        [UserDefinedTableTypeColumn(32)]
        public string MOTHER_NAME { get; set; }

        [UserDefinedTableTypeColumn(33)]
        public string GENDER_CODE { get; set; }

        [UserDefinedTableTypeColumn(34)]
        public DateTime? DATE_OF_BIRTH { get; set; }

        [UserDefinedTableTypeColumn(35)]
        public string PLACE_OF_BIRTH { get; set; }

        [UserDefinedTableTypeColumn(36)]
        public int? MARITAL_STATUS_ID { get; set; }

        [UserDefinedTableTypeColumn(37)]
        public int? NATIONALITY_ID { get; set; }

        [UserDefinedTableTypeColumn(38)]
        public string CURRENT_LOCATION { get; set; }

        [UserDefinedTableTypeColumn(39)]
        public int? RELIGION_ID { get; set; }

        [UserDefinedTableTypeColumn(40)]
        public string DESIGNATION { get; set; }

        [UserDefinedTableTypeColumn(41)]
        public string INDUSTRY { get; set; }

        [UserDefinedTableTypeColumn(42)]
        public string REFERENCE { get; set; }

        [UserDefinedTableTypeColumn(43)]
        public string POST_APPLIED_FOR { get; set; }

        [UserDefinedTableTypeColumn(44)]
        public string CIVILIAN_NO { get; set; }

        [UserDefinedTableTypeColumn(45)]
        public string CLINIC_NAME { get; set; }

        [UserDefinedTableTypeColumn(46)]
        public int? VISA_ID { get; set; }

        [UserDefinedTableTypeColumn(47)]
        public string FILE_NO { get; set; }

        [UserDefinedTableTypeColumn(48)]
        public string PERSONAL_REMARK { get; set; }
    }
}
