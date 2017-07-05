using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Industry
    {
        public int INDUSTRY_ID { get; set; }
        [MaxLength(80)]
        [Display(Name = "Industry")]
        [Required(ErrorMessage = "Please enter Industry")]
        public string INDUSTRY_TYPE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
