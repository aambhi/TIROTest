using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;
namespace TIROERP.Infrastructure.Repository
{
    public class MedicalRepository : IMedical
    {
         ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        public void Create(Medical medicalDetails)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_MEDICAL tbl_medical = new TBL_MEDICAL();

            try
            {
                tbl_medical.USER_REQUIREMENT_ID = medicalDetails.USER_REQUIREMENT_ID;
                tbl_medical.DoctorID = medicalDetails.DoctorID;
                tbl_medical.CheckupDate = !string.IsNullOrEmpty(medicalDetails.CheckupDate) ? Convert.ToDateTime(medicalDetails.CheckupDate) : (DateTime?)null;
                tbl_medical.TokenNumber = medicalDetails.TokenNumber;
                tbl_medical.ReportDate = !string.IsNullOrEmpty(medicalDetails.ReportDate) ? Convert.ToDateTime(medicalDetails.ReportDate) : (DateTime?)null; 
                tbl_medical.ReportPath = medicalDetails.ReportPath;
                tbl_medical.Remark = medicalDetails.Remark;
                tbl_medical.CreatedDate = DateTime.Now;
                tbl_medical.MedicalStatus = medicalDetails.MedicalStatus;
                tbl_medical.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                _entities.TBL_MEDICAL.Add(tbl_medical);
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(medicalDetails.USER_REQUIREMENT_ID, medicalDetails.MedicalStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Medical medicalDetails)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_MEDICAL tbl_medical = new TBL_MEDICAL();

            try
            {
                tbl_medical.MedicalId = medicalDetails.MedicalId;
                tbl_medical.USER_REQUIREMENT_ID = medicalDetails.USER_REQUIREMENT_ID;
                tbl_medical.DoctorID = medicalDetails.DoctorID;
                tbl_medical.CheckupDate = Convert.ToDateTime(medicalDetails.CheckupDate);
                tbl_medical.TokenNumber = medicalDetails.TokenNumber;
                tbl_medical.ReportDate = Convert.ToDateTime(medicalDetails.ReportDate);
                tbl_medical.ReportPath = medicalDetails.ReportPath;
                tbl_medical.Remark = medicalDetails.Remark;
                tbl_medical.ModifiedDate = DateTime.Now;
                tbl_medical.MedicalStatus = medicalDetails.MedicalStatus;
                tbl_medical.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_medical.CreatedBy = medicalDetails.CreatedBy;
                tbl_medical.CreatedDate = medicalDetails.CreatedDate;
                _entities.Entry(tbl_medical).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(medicalDetails.USER_REQUIREMENT_ID, medicalDetails.MedicalStatus);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Passport_Details> GetPassportNumbers()
        {
            string status = "6,9,8";
            return common.GetPassportNumbers(status);
        }

        public List<Doctor_Details> GetDoctorsList()
        {
            _entities = new  ArbabTravelsERPEntities();
            List<Doctor_Details> doctorDetailsLst = new List<Doctor_Details>();
            try
            {
                doctorDetailsLst = (from user in _entities.TBL_USER_DETAILS
                                    join personalDetails in _entities.TBL_USER_PERSONAL_DETAILS
                                    on user.REGISTRATION_NO equals personalDetails.REGISTRATION_NO
                                    where user.USER_TYPE_ID == 4
                                    select new Doctor_Details
                                    {
                                        REGISTATION_NUMBER = user.REGISTRATION_NO,
                                        First_Name = personalDetails.FIRST_NAME,
                                        Last_Name = personalDetails.LAST_NAME,
                                        ClinicName=user.CLINIC_NAME
                                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return doctorDetailsLst;
        }

        public string GetCandidateName(int userRequirementId)
        {
            return common.GetCandidateName(userRequirementId);
        }

        public List<Medical> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new  ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<Medical>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);


            var lstmedical = ((List<Medical>)result[0])
                .Select(x => new Medical
                {
                    STATUS_NAME = x.STATUS_NAME,
                    CheckupDate = x.CheckupDate,
                    DoctorName = x.DoctorName,
                    ReportDate = x.ReportDate,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    MedicalId = x.MedicalId,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    DoctorID = x.DoctorID,
                    TokenNumber = x.TokenNumber,
                    MedicalStatus = x.MedicalStatus,
                    ReportPath = x.ReportPath,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    Remark = x.Remark,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER
                }).ToList();
            return lstmedical;
        }

    }
}