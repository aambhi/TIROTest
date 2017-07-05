using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Country
    {
        [MaxLength(50)]
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Please enter Country Name")]
        public string COUNTRY_NAME { get; set; }

        [MaxLength(50)]
        [Display(Name = "Country Code")]
        public string COUNTRY_CODE { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public string STATE_CODE { get; set; }
        public string STATE_NAME { get; set; }
        public string CITY_CODE { get; set; }
        public string CITY_NAME { get; set; }

        public int CountryId { get; set; }
    }
}
