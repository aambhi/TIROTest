using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Policy
    {
        public int POLICYID { get; set; }

        [Required(ErrorMessage = "Please select Passport")]
        public int USER_REQUIREMENT_ID { get; set; }

        [Required(ErrorMessage = "Please enter Policy Number")]
        public string PolicyNumber { get; set; }

        [Required(ErrorMessage = "Please select policy date")]
        public DateTime? PolicyDate { get; set; }

        [Required(ErrorMessage = "Please enter policy fees")]
        public decimal? PolicyFees { get; set; }
        public string PolicyRemark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string PASSPORT_NUMBER { get; set; }
    }
}