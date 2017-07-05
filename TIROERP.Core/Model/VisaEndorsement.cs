using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class VisaEndorsement
    {
        public int VisaEndorsementId { get; set; }

        [Required(ErrorMessage = "Please select passport")]
        public int USER_REQUIREMENT_ID { get; set; }

        [Required(ErrorMessage = "Please select submission date")]
        public string SubmissionDate { get; set; }

        [Required(ErrorMessage = "Please select submission status")]
        public int? SubmissionStatusID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string VisaSubmissionStatus { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string PASSPORT_NUMBER { get; set; }
        public string VisaEndorsementFilePath { get; set; }
    }

    public class SubmissionStatus
    {
        public int SubmissionStatusId { get; set; }
        public string VisaEndorsementSubmissionStatus { get; set; }

    }
}