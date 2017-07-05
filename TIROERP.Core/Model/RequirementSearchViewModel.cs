using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class RequirementSearchViewModel
    {
        public int REQUIREMENT_ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OPENING_DATE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CONTACT_PERSON { get; set; }
        public int? NO_OF_OPENINGS { get; set; }
        public string INTERVIEW_MODE { get; set; }
        public string INDUSTRY_TYPE { get; set; }
        public string REQ_ROLE { get; set; }
        public string VISA { get; set; }
        public string EXPERIENCE { get; set; }
        public string SPECIALIZATION { get; set; }
        public string EDUCATION_TYPE { get; set; }
        public string CERTIFICATION_TYPE { get; set; }
        public string DESIGNATION { get; set; }
        public string LANGUAGES { get; set; }
        public string GENDERS { get; set; }
        public string AGE { get; set; }
        public string RELIGION { get; set; }
        public string POSTING_PLACE { get; set; }
        public string BASIC_SALARY { get; set; }
        public string OVERTIME { get; set; }
        public string CONTACT_PERIOD { get; set; }
        public string WORKING_HOURS { get; set; }
        public string LEAVES_PER_YEAR { get; set; }
        public string TRIP_PER_YEAR { get; set; }
        public bool IS_ACTIVE { get; set; }
        public decimal? HOUSE { get; set; }
        public decimal? FOOD { get; set; }
        public decimal? MEDICAL { get; set; }
        public decimal? TRAVEL { get; set; }
        public string JOB_TITLE { get; set; }
        public string JOB_DESCRIPTION { get; set; }
        public string VISA_NUMBER { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ISSUE_DATE { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? EXPIRY_DATE { get; set; }
        public CVDetails cVDetails { get; set; }

        public string REMARK { get; set; }

        public List<RequirementAllowance> reqAllowance { get; set; }
    }
    public class CVDetails
    {
        public int CV_SOURCED { get; set; }
        public int SHORTLISTED { get; set; }
        public int SELECTED { get; set; }
        public int INPROCESS { get; set; }
        public int MOBILIZED { get; set; }
        public int VISA_COUNT { get; set; }

    }

    public class RequirementAllowance
    {
        public string ALLOWANCE_NAME { get; set; }
        public string ALLOWANCE_TYPE { get; set; }
        public decimal? ALLOWANCE_AMOUNT { get; set; }
        public int REQUIRMENT_ID { get; set; }
    }
}