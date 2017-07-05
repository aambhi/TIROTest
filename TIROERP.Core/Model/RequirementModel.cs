using System;


namespace TIROERP.Core.Model
{
    public class RequirementModel
    {

        public int REQUIREMENT_ID { get; set; }
        public string COMPANY_ID { get; set; }
        public DateTime? RECIEVED_DATE { get; set; }
        public int? NO_OF_OPENINGS { get; set; }
        public decimal? EXPERIENCE { get; set; }
        public string JOB_DESCRIPTION { get; set; }
        public string GENDER { get; set; }
        public int? AGE { get; set; }
        public string RELIGION_ID { get; set; }
        public int? INTERVIEW_MODE_ID { get; set; }
        public int? SPECIALIZATION_ID { get; set; }
        public string POSTING_PLACE { get; set; }
        public int? CURRENCY_TYPE_ID { get; set; }
        public int? BASIC_RANGE { get; set; }
        public decimal? OVERTIME { get; set; }
        public int? TRIP_PER_YEAR { get; set; }
        public decimal? CONTACT_PERIOD { get; set; }
        public double? CONTRACT_PERIOD { get; set; }
        public decimal? WORKING_HOURS { get; set; }
        public int? LEAVES_PER_YEAR { get; set; }
        public string REMARK { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public decimal? EXPERIENCE_FROM { get; set; }
        public decimal? EXPERIENCE_TO { get; set; }
        public int? AGE_FROM { get; set; }
        public int? AGE_TO { get; set; }
        public int? BASIC_SALARY_RANGE_TO { get; set; }
        public int? BASIC_SALARY_RANGE_FROM { get; set; }
        public string CONTACT_PERSON { get; set; }
        public bool STATUS_ID { get; set; }

        public string JOB_TITLE { get; set; }
        public string LANGUAGE { get; set; }
        public string ALLOWANCE_IDS { get; set; }
        public string EDUCATION_IDS { get; set; }

     
        public int[] ALLOWANCE { get; set; }
        public string[] GENDERS { get; set; }
        public Language[] LANGUAGES { get; set; }

        public int[] RELIGIONS { get; set; }
        public int[] INDUSTRY { get; set; }
        public int[] DESIGNATION { get; set; }
        public int[] EDUCATION { get; set; }
        public int[] SPECIALIZATION { get; set; }
        public int[] CERTIFICATION { get; set; }

        public bool IS_READ { get; set; }
        public bool IS_WRITE { get; set; }
        public bool IS_SPEAK { get; set; }
        public int CURRENCY_ID { get; set; }

        public decimal? HOUSING_ALLOWANCE { get; set; }
        public decimal? FOOD_ALLOWANCE { get; set; }
        public decimal? TRAVELLING_ALLOWANCE { get; set; }
        public decimal? MEDICAL_ALLOWANCE { get; set; }

        public int? SELECTD_FOOD_ALLOWANCE { get; set; }
        public int? SELECTD_HOUSE_ALLOWANCE { get; set; }
        public int? SELECTD_MEDICAL_ALLOWANCE { get; set; }
        public int? SELECTD_TRAVEL_ALLOWANCE { get; set; }
    }

    public enum ALLOWANCES
    {
        Included = 1,
        Allowance,
        Not_Applicable
    }
   public  enum ALLOWANCE_IDS
    {
        FOOD=1,
        MEDICAL,
        HOUSE,
        TRAVEL
    }
}
