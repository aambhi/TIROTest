using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Mofa
    {
        public int MofaID { get; set; }

        [Required(ErrorMessage = "Please select Passport")]
        public int USER_REQUIREMENT_ID { get; set; }

        [Required(ErrorMessage = "Please enter Mofa number")]
        public string MofaNumber { get; set; }

        [Required(ErrorMessage = "Please enter Mofa date")]
        public string MofaDate { get; set; }
        public string ApplicationNumber { get; set; }
        public string ApplicationDate { get; set; }
        public string HealthNumber { get; set; }
        public string HealthDate { get; set; }
        public string DDNumber { get; set; }
        public string DDDate { get; set; }
        public string MofaFilePath { get; set; }
        public string MofaRemark { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string PASSPORT_NUMBER { get; set; }

    }
}