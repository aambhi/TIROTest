using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Specialization
    {
        public int SPECIALIZATION_ID { get; set; }

        [Required(ErrorMessage = "Please select education type")]
        public int EDUCATION_TYPE_ID { get; set; }
        public string EDUCATION_TYPE { get; set; }

        [MaxLength(50)]
        [Display(Name = "Specialization Type")]
        [Required(ErrorMessage = "Please enter specialization type")]
        public string SPECIALIZATION_TYPE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
