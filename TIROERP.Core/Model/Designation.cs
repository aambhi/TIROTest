using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Designation
    {
        public int DESIGNATION_ID { get; set; }
        [Display(Name = "Industry")]
        [Required(ErrorMessage = "Please select Industry")]
        public int? INDUSTRY_ID { get; set; }
        public string INDUSTRY_NAME { get; set; }

        [MaxLength(50)]
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please enter Designation")]
        public string DESIGNATION_NAME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
