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
    
    public partial class TBL_MOFA
    {
        public int MofaID { get; set; }
        public Nullable<int> USER_REQUIREMENT_ID { get; set; }
        public string MofaNumber { get; set; }
        public Nullable<System.DateTime> MofaDate { get; set; }
        public string ApplicationNumber { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public string HealthNumber { get; set; }
        public Nullable<System.DateTime> HealthDate { get; set; }
        public string DDNumber { get; set; }
        public Nullable<System.DateTime> DDDate { get; set; }
        public string MofaFilePath { get; set; }
        public string MofaRemark { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual TBL_USER_REQUIREMENT TBL_USER_REQUIREMENT { get; set; }
    }
}