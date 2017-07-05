using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Medical
    {
        public int MedicalId { get; set; }

        [Required(ErrorMessage = "Please select Passport")]
        public int USER_REQUIREMENT_ID { get; set; }

        [Required(ErrorMessage = "Please select doctor")]
        public string DoctorID { get; set; }

        [Required(ErrorMessage = "Please enter checkup date")]
        public string CheckupDate { get; set; }
        public string TokenNumber { get; set; }
        public string ReportDate { get; set; }

        [Required(ErrorMessage = "Please select any one option")]
        public int? MedicalStatus { get; set; }

        public string ReportPath { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DoctorName { get; set; }
        public string STATUS_NAME { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string ReportName { get; set; }
        public string PASSPORT_NUMBER { get; set; }

    }

    public class Passport_Details
    {
        public int USER_REQUIREMENT_ID { get; set; }
        public string REGISTATION_NUMBER { get; set; }
        public string PASSPORT_NUMBER { get; set; }
    }

    public class Doctor_Details
    {
        public string First_Name { get; set; }
        public string REGISTATION_NUMBER { get; set; }
        public string Last_Name { get; set; }

        public string ClinicName { get; set; }
    }
}