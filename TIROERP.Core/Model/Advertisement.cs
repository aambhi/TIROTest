using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Advertisement
    {
        public int ADV_ID { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter Paper Name")]
        public string PAPER_NAME { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Please enter Agency Name")]
        public string AD_AGENCY_NAME { get; set; }

        [Required(ErrorMessage = "Please enter Expenses")]
        public decimal? EXPENSES { get; set; }
        public int? REQUIREMENT_ID { get; set; }
        public string FILE_PATH { get; set; }

        [Required(ErrorMessage = "Please enter Advertisement Date")]
        public DateTime? ADV_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }

        public string REQUIREMENT_NAME { get; set; }

    }

    public class Advertisement_Requirements
    {
        public int REQUIREMENT_ID { get; set; }

        public string RequirementName { get; set; }
    }
}
