using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class EducationType
    {
        public int EDUCATION_TYPE_ID { get; set; }

        [MaxLength(50)]
        [Display(Name = "Education Type")]
        [Required(ErrorMessage = "Please enter education type")]
        public string EDUCATION_TYPE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
