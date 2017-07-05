//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TIROERP.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_USER_DETAILS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USER_DETAILS()
        {
            this.TBL_INTERVIEW = new HashSet<TBL_INTERVIEW>();
            this.TBL_USER_REQUIREMENT = new HashSet<TBL_USER_REQUIREMENT>();
            this.TBL_USER_DOCUMENTS = new HashSet<TBL_USER_DOCUMENTS>();
        }
    
        public string REGISTRATION_NO { get; set; }
        public int USER_TYPE_ID { get; set; }
        public Nullable<int> AVAILING_TYPE_ID { get; set; }
        public Nullable<int> SOURCE_ID { get; set; }
        public Nullable<int> STATUS_ID { get; set; }
        public Nullable<int> VISIT_NUMBER { get; set; }
        public string REQUIREMENT_ID { get; set; }
        public bool LOGIN_ACCESS { get; set; }
        public string LOGIN_PASSWORD { get; set; }
        public string USER_IMAGE_PATH { get; set; }
        public string REMARK { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public Nullable<bool> IS_EXPERIENCED { get; set; }
        public string WEBSITE { get; set; }
        public string SKYPE { get; set; }
        public string CONTACT_REMARK { get; set; }
        public string EDUCATION_REMARK { get; set; }
        public string WORK_REMARK { get; set; }
        public string BRANCH_CODE { get; set; }
        public string CIVILIAN_NO { get; set; }
        public string NAME { get; set; }
        public Nullable<int> CLIENT_DESIGNATION { get; set; }
        public Nullable<int> CLIENT_INDUSTRY_ID { get; set; }
        public string REFERENCE { get; set; }
        public string GAMCA_NO { get; set; }
        public string LOCATION_CODE { get; set; }
        public string OTHER_SOURCE { get; set; }
        public string REFERRER_NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string DESIGNATION_ID { get; set; }
        public string INDUSTRY_ID { get; set; }
        public string TOTAL_WORK_EXPERIENCE { get; set; }
        public string TOTAL_GULF_EXPERIENCE { get; set; }
        public string SKILLS { get; set; }
        public string CLINIC_NAME { get; set; }
        public Nullable<int> VISA_ID { get; set; }
        public string POST_APPLIED_FOR { get; set; }
        public string FILE_NO { get; set; }
        public string PERSONAL_REMARK { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_INTERVIEW> TBL_INTERVIEW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_REQUIREMENT> TBL_USER_REQUIREMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_USER_DOCUMENTS> TBL_USER_DOCUMENTS { get; set; }
    }
}