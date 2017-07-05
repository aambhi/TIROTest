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
    
    public partial class TBL_USER_REQUIREMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_USER_REQUIREMENT()
        {
            this.TBL_MEDICAL = new HashSet<TBL_MEDICAL>();
            this.TBL_MOFA = new HashSet<TBL_MOFA>();
            this.TBL_POLICY = new HashSet<TBL_POLICY>();
            this.TBL_TICKET = new HashSet<TBL_TICKET>();
            this.TBL_VISA_ENDORSEMENT = new HashSet<TBL_VISA_ENDORSEMENT>();
            this.TBL_EMIGRATION = new HashSet<TBL_EMIGRATION>();
        }
    
        public int USER_REQUIREMENT_ID { get; set; }
        public string REGISTRATION_NO { get; set; }
        public int REQUIREMENT_ID { get; set; }
        public int CANDIDATE_STATUS { get; set; }
        public bool CURRENT_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MEDICAL> TBL_MEDICAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MOFA> TBL_MOFA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_POLICY> TBL_POLICY { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TICKET> TBL_TICKET { get; set; }
        public virtual TBL_USER_DETAILS TBL_USER_DETAILS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_VISA_ENDORSEMENT> TBL_VISA_ENDORSEMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_EMIGRATION> TBL_EMIGRATION { get; set; }
        public virtual TBL_REQUIREMENT_DETAILS TBL_REQUIREMENT_DETAILS { get; set; }
    }
}
