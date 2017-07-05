using EntityFrameworkExtras.EF6;
using System;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_PROCESS_MEDICAL")]
    public class UDT_PROCESS_MEDICAL
    {
        [UserDefinedTableTypeColumn(1)]
        public int MedicalId { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string DoctorID { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public DateTime? CheckupDate { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string TokenNumber { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? ReportDate { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public int? MedicalStatus { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string ReportPath { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string Remark { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public string CreatedBy { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public DateTime? CreatedDate { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public string ModifiedBy { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public DateTime? ModifiedDate { get; set; }
    }

    [UserDefinedTableType("UDT_PROCESS_MOFA")]
    public class UDT_PROCESS_MOFA
    {
        [UserDefinedTableTypeColumn(1)]
        public int MofaID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string MofaNumber { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public DateTime? MofaDate { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string ApplicationNumber { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? ApplicationDate { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string HealthNumber { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public DateTime? HealthDate { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string DDNumber { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public DateTime? DDDate { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string MofaFilePath { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public string MofaRemark { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public string CreatedBy { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public DateTime? CreatedDate { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public string ModifiedBy { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public DateTime? ModifiedDate { get; set; }
    }

    [UserDefinedTableType("UDT_PROCESS_VISA_ENDORSEMENT")]
    public class UDT_PROCESS_VISA_ENDORSEMENT
    {
        [UserDefinedTableTypeColumn(1)]
        public int VisaEndorsementId { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public DateTime? SubmissionDate { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public int? SubmissionStatusID { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string CreatedBy { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? CreatedDate { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string ModifiedBy { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public DateTime? ModifiedDate { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string VisaEndorsementFilePath { get; set; }
    }

    [UserDefinedTableType("UDT_PROCESS_POLICY")]
    public class UDT_PROCESS_POLICY
    {
        [UserDefinedTableTypeColumn(1)]
        public int POLICYID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string Policy { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public DateTime? PolicyDate { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public Decimal? PolicyFees { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string PolicyRemark { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string CreatedBy { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public DateTime? CreatedDate { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string ModifiedBy { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public DateTime? ModifiedDate { get; set; }
    }

    [UserDefinedTableType("UDT_PROCESS_EMIGRATION")]
    public class UDT_PROCESS_EMIGRATION
    {
        [UserDefinedTableTypeColumn(1)]
        public int EMIGRATION_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string FE_NO { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string PT_NO { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string DM_NO { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public DateTime? DM_DATE { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string POLICY_NO { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public DateTime? POLICY_DATE { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public decimal? POLICY_AMOUNT { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public string POLICY_COMPANYNAME { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string POLICY_ATTACHMENT { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public DateTime? SUBMISSION_DATE { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public string EMIGRATION_CLEARANCENO { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public string EMIGRATION_ATTACHMENT { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public string POE { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public string REMARK { get; set; }

        [UserDefinedTableTypeColumn(17)]
        public DateTime? CREATED_DATE { get; set; }

        [UserDefinedTableTypeColumn(18)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(19)]
        public string MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(20)]
        public DateTime? MODIFIED_DATE { get; set; }

        [UserDefinedTableTypeColumn(21)]
        public bool IS_ECR { get; set; }

    }
}
