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
    public class VisaEndorsementRepository : IVisaEndorsement
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        public void Create(VisaEndorsement visaEndorsement)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_VISA_ENDORSEMENT tbl_visa_endorsement = new TBL_VISA_ENDORSEMENT();

            try
            {
                tbl_visa_endorsement.USER_REQUIREMENT_ID = visaEndorsement.USER_REQUIREMENT_ID;
                tbl_visa_endorsement.SubmissionDate = !string.IsNullOrEmpty(visaEndorsement.SubmissionDate) ? Convert.ToDateTime(visaEndorsement.SubmissionDate) : (DateTime?)null;
                tbl_visa_endorsement.SubmissionStatusID = visaEndorsement.SubmissionStatusID;
                tbl_visa_endorsement.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_visa_endorsement.CreatedDate = DateTime.Now;
                tbl_visa_endorsement.VisaEndorsementFilePath = visaEndorsement.VisaEndorsementFilePath;

                _entities.TBL_VISA_ENDORSEMENT.Add(tbl_visa_endorsement);
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(visaEndorsement.USER_REQUIREMENT_ID, visaEndorsement.SubmissionStatusID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(VisaEndorsement visaEndorsement)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_VISA_ENDORSEMENT tbl_visa_endorsement = new TBL_VISA_ENDORSEMENT();

            try
            {
                tbl_visa_endorsement.VisaEndorsementId = visaEndorsement.VisaEndorsementId;
                tbl_visa_endorsement.USER_REQUIREMENT_ID = visaEndorsement.USER_REQUIREMENT_ID;
                tbl_visa_endorsement.SubmissionDate = !string.IsNullOrEmpty(visaEndorsement.SubmissionDate) ? Convert.ToDateTime(visaEndorsement.SubmissionDate) : (DateTime?)null;
                tbl_visa_endorsement.SubmissionStatusID = visaEndorsement.SubmissionStatusID;
                tbl_visa_endorsement.CreatedBy = visaEndorsement.CreatedBy;
                tbl_visa_endorsement.CreatedDate = visaEndorsement.CreatedDate;
                tbl_visa_endorsement.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_visa_endorsement.ModifiedDate = DateTime.Now;
                tbl_visa_endorsement.VisaEndorsementFilePath = visaEndorsement.VisaEndorsementFilePath;

                _entities.Entry(tbl_visa_endorsement).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(visaEndorsement.USER_REQUIREMENT_ID, visaEndorsement.SubmissionStatusID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCandidateName(int userRequirementId)
        {
            return common.GetCandidateName(userRequirementId);
        }

        public List<SubmissionStatus> GetSubmissionStatusDetails()
        {
            List<SubmissionStatus> submissionStatusList = new List<SubmissionStatus>();
            _entities = new ArbabTravelsERPEntities();
            try
            {
                submissionStatusList = _entities.TBL_STATUS_MASTER
                    .Where(x => x.STATUS_NAME.Contains("VISA ENDROSMENT"))
                    .Select(x => new SubmissionStatus
                    {
                        SubmissionStatusId = x.STATUS_ID,
                        VisaEndorsementSubmissionStatus = x.STATUS_NAME
                    }).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return submissionStatusList;
        }

        public List<Passport_Details> GetPassportDetails()
        {
            string status = "16,10,11";
            return common.GetPassportNumbers(status);
        }

        public List<VisaEndorsement> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<VisaEndorsement>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);


            var lstvisa = ((List<VisaEndorsement>)result[0])
                .Select(x => new VisaEndorsement
                {
                    VisaEndorsementId = x.VisaEndorsementId,
                    VisaSubmissionStatus = x.VisaSubmissionStatus,
                    SubmissionDate = x.SubmissionDate,
                    SubmissionStatusID = x.SubmissionStatusID,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                    VisaEndorsementFilePath = x.VisaEndorsementFilePath
                }).ToList();
            return lstvisa;
        }
    }
}