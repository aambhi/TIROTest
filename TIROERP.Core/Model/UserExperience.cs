using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class UserExperience
    {
        public int EXPERIENCE_ID { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string USER_COMPANY_NAME { get; set; }
        public bool? IS_CURRENT_COMPANY { get; set; }
        public int? DESIGNATION_ID { get; set; }
        public int? INDUSTRY_ID { get; set; }
        public string WORK_CITY_CODE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WORK_PERIOD_FROM { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? WORK_PERIOD_TO { get; set; }

        public string TOTAL_WORK_EXPERIENCE { get; set; }
        public string TOTAL_GULF_EXPERIENCE { get; set; }
        public string SKILLS { get; set; }
        public string REMARK { get; set; }
        public string OTHER_COMPANY { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string CITY_NAME { get; set; }
        public string STATE_NAME { get; set; }
        public string INDUSTRY_TYPE { get; set; }
        public string DESIGNATION { get; set; }
        public string COMPANY_NAME { get; set; }
        public bool ISNEW { get; set; }
        public string OTHER_DESIGNATION { get; set; }
        public string WORK_STATE_CODE { get; set; }
    }
}
