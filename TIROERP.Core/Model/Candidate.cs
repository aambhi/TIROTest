using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Candidate
    {
        public string REGISTRATION_NO { get; set; }
        public string Candidate_Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? REGISTRATION_DATE { get; set; }

        public string PHONE_NO { get; set; }
        public string USER_EMAIL { get; set; }
        public int? Age { get; set; }
        public string Contact_No { get; set; }
        public string SOURCE_NAME { get; set; }
        public string AVAILING_TYPE { get; set; }

        public int? AVAILING_TYPE_ID { get; set; }
        public int? SOURCE_ID { get; set; }
        public string OTHER_SOURCE { get; set; }
        public string REFERRER_NAME { get; set; }
        public int? STATUS_ID { get; set; }
        public string STATUS_NAME { get; set; }
        public int? REQUIREMENT_ID { get; set; }
        public string REQUIREMENT { get; set; }
        public int? VISA_ID { get; set; }
        public string VISA_NUMBER { get; set; }
        public bool LOGIN_ACCESS { get; set; }
        public string LOGIN_PASSWORD { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public bool? IS_EXPERIENCED { get; set; }
        public string EDUCATION_REMARK { get; set; }
        public string WORK_REMARK { get; set; }
        public string BRANCH_CODE { get; set; }
        public string BRANCH_NAME { get; set; }
        public string LOCATION_CODE { get; set; }
        public string COMPANY_NAME { get; set; }
        public string TOTAL_WORK_EXPERIENCE { get; set; }
        public string TOTAL_GULF_EXPERIENCE { get; set; }
        public string SKILLS { get; set; }

        [MaxLength(50)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LAST_NAME { get; set; }
        public string GAMCA_NO { get; set; }
        public string FILE_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public string REMARK { get; set; }
        public string WEBSITE { get; set; }
        public string SKYPE { get; set; }
        public string CONTACT_REMARK { get; set; }
        public string FATHER_NAME { get; set; }
        public string MOTHER_NAME { get; set; }
        public string GENDER_CODE { get; set; }
        public string GENDER_NAME { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DATE_OF_BIRTH { get; set; }
        public string PLACE_OF_BIRTH { get; set; }
        public int? MARITAL_STATUS_ID { get; set; }
        public string MARITAL_STATUS { get; set; }
        public int? NATIONALITY_ID { get; set; }
        public string NATIONALITY { get; set; }
        public string CURRENT_LOCATION { get; set; }
        public string CURRENT_LOCATION_NAME { get; set; }
        public int? RELIGION_ID { get; set; }

        public string RELIGION_NAME { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public int? PASSPORT_ID { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DATE_OF_ISSUE { get; set; }

        public string PLACE_OF_ISSUE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DATE_OF_EXPIRY { get; set; }

        public bool? EMIGRATION_CLEARANCE_REQUIRED { get; set; }
        public string DRIVING_LICENCE_NUMBER { get; set; }
        public string DRIVING_PLACE_OF_ISSUE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DRIVING_DATE_OF_ISSUE { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DRIVING_EXPIRY_DATE { get; set; }

        public int? VEHICLE_TYPE_ID { get; set; }
        public string VEHICLE_TYPE { get; set; }
        public string DRIVING_REMARK { get; set; }
        public int? DRIVING_LICENCE_ID { get; set; }
        public string POST_APPLIED_FOR { get; set; }
        public int USER_TYPE_ID { get; set; }
        public int[] INDUSTRY { get; set; }
        public int[] DESIGNATION { get; set; }
        public string CIVILIAN_NO { get; set; }
        public string REFERENCE { get; set; }
        public string CLINIC_NAME { get; set; }
        public string LANGUAGES { get; set; }

        public List<UserAddress> LST_USER_ADDRESS { get; set; }
        public List<UserContact> LST_USER_CONTACT { get; set; }
        public List<UserEmail> LST_USER_EMAIL { get; set; }
        public List<UserEducation> LST_USER_EDUCATION { get; set; }
        public List<UserCertification> LST_USER_CERTIFICATION { get; set; }
        public List<UserExperience> LST_USER_EXPERIENCE { get; set; }
        public List<UserDocument> LST_USER_DOCUMENT { get; set; }
        public List<UserLanguage> LST_USER_LANGUAGE { get; set; }

        public List<IndustryDesignation> LST_INDUSTRY_DESIGNATION { get; set; }
        public List<Mofa> LST_Mofa { get; set; }
        public List<Medical> LST_Medical { get; set; }
        public List<VisaEndorsement> LST_VisaEndorsement { get; set; }
        public List<Policy> LST_Policy { get; set; }
        public List<Ticket> LST_Ticket { get; set; }
        public List<UserRequirement> LST_USER_REQUIREMENT { get; set; }
        public string CONDITIONAL_OPERATOR { get; set; }

        public bool IsNew { get; set; }

        public Mofa MOFA_Details { get; set; }
        public Medical Medical_Details { get; set; }
        public VisaEndorsement VisaEndorsement_Details { get; set; }
        public Policy Policy_Details { get; set; }
        public Ticket Ticket_Details { get; set; }
        public Emigration Emigration_Details { get; set; }

        public string SERVER_MAP_PATH { get; set; }
        public string MULTIPLE_INDUSTRY_ID { get; set; }
        public string INDUSTRY_TYPE { get; set; }
        public string MULTIPLE_DESIGNATION_ID { get; set; }
        public string DESIGNATION_NAME { get; set; }
        public string FILE_NO { get; set; }
    }
}
