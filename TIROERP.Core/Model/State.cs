using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class State
    {
        [MaxLength(50)]
        [Display(Name = "State Code")]
        public string STATE_CODE { get; set; }

        [MaxLength(50)]
        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please select Country")]
        public string COUNTRY_CODE { get; set; }

        [MaxLength(50)]
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please enter State")]
        public string STATE_NAME { get; set; }

        public string COUNTRY_NAME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public System.DateTime MODIFIED_DATE { get; set; }

        public int StateId { get; set; }
    }
}
