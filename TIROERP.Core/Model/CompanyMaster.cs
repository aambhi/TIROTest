using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class CompanyMaster
    {
        public int COMPANY_ID { get; set; }

        [MaxLength(50)]
        [Display(Name = "COMPANY NAME")]
        [Required(ErrorMessage = "Please enter Company Name")]
        public string COMPANY_NAME { get; set; }

        [MaxLength(50)]
        [Display(Name = "CONTACT PERSON")]
        public string CONTACT_PERSON { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
