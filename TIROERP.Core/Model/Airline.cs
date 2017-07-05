using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Airline
    {
        public int AirlinesId { get; set; }

        [MaxLength(50)]
        [Display(Name = "Airline Name")]
        [Required(ErrorMessage = "Please enter Airline Name")]
        public string AirlinesName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
