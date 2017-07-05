using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class City
    {
        [MaxLength(50)]
        [Display(Name = "City Code")]
        public string CITY_CODE { get; set; }

        [MaxLength(50)]
        [Display(Name = "State Code")]
        [Required(ErrorMessage = "Please select State")]
        public string STATE_CODE { get; set; }

        [MaxLength(50)]
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Please enter City")]
        public string CITY_NAME { get; set; }
        public string STATE_NAME { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime MODIFIED_DATE { get; set; }

        public int CityId { get; set; }
    }
}
