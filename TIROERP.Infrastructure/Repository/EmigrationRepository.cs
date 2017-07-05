using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class EmigrationRepository : IEmigration
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        public void Create(Emigration emigrationObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_EMIGRATION tbl_emigration = new TBL_EMIGRATION();
            try
            {
                tbl_emigration.USER_REQUIREMENT_ID = emigrationObj.USER_REQUIREMENT_ID;
                tbl_emigration.FE_NO = emigrationObj.FE_NO;
                tbl_emigration.PT_NO = emigrationObj.PT_NO;
                tbl_emigration.DM_NO = emigrationObj.DM_NO;
                tbl_emigration.DM_DATE = emigrationObj.DM_DATE;
                tbl_emigration.POLICY_NO = emigrationObj.POLICY_NO;
                tbl_emigration.POLICY_DATE = emigrationObj.POLICY_DATE;
                tbl_emigration.POLICY_AMOUNT = emigrationObj.POLICY_AMOUNT;
                tbl_emigration.POLICY_COMPANYNAME = emigrationObj.POLICY_COMPANYNAME;
                tbl_emigration.POLICY_ATTACHMENT = emigrationObj.POLICY_ATTACHMENT;
                tbl_emigration.SUBMISSION_DATE = emigrationObj.SUBMISSION_DATE;
                tbl_emigration.EMIGRATION_CLEARANCENO = emigrationObj.EMIGRATION_CLEARANCENO;
                tbl_emigration.EMIGRATION_ATTACHMENT = emigrationObj.EMIGRATION_ATTACHMENT;
                tbl_emigration.POE = emigrationObj.POE;
                tbl_emigration.REMARK = emigrationObj.REMARK;
                tbl_emigration.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_emigration.CREATED_DATE = DateTime.Now;
                tbl_emigration.IS_ECR = emigrationObj.IS_ECR;

                _entities.TBL_EMIGRATION.Add(tbl_emigration);
                _entities.SaveChanges();

                _entities.PROC_UPDATE_USER_STATUS(emigrationObj.USER_REQUIREMENT_ID, 17);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Emigration emigrationObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_EMIGRATION tbl_emigration = new TBL_EMIGRATION();

            try
            {
                tbl_emigration.EMIGRATION_ID = emigrationObj.EMIGRATION_ID;
                tbl_emigration.USER_REQUIREMENT_ID = emigrationObj.USER_REQUIREMENT_ID;
                tbl_emigration.FE_NO = emigrationObj.FE_NO;
                tbl_emigration.PT_NO = emigrationObj.PT_NO;
                tbl_emigration.DM_NO = emigrationObj.DM_NO;
                tbl_emigration.DM_DATE = emigrationObj.DM_DATE;
                tbl_emigration.POLICY_NO = emigrationObj.POLICY_NO;
                tbl_emigration.POLICY_DATE = emigrationObj.POLICY_DATE;
                tbl_emigration.POLICY_AMOUNT = emigrationObj.POLICY_AMOUNT;
                tbl_emigration.POLICY_COMPANYNAME = emigrationObj.POLICY_COMPANYNAME;
                tbl_emigration.POLICY_ATTACHMENT = emigrationObj.POLICY_ATTACHMENT;
                tbl_emigration.SUBMISSION_DATE = emigrationObj.SUBMISSION_DATE;
                tbl_emigration.EMIGRATION_CLEARANCENO = emigrationObj.EMIGRATION_CLEARANCENO;
                tbl_emigration.EMIGRATION_ATTACHMENT = emigrationObj.EMIGRATION_ATTACHMENT;
                tbl_emigration.POE = emigrationObj.POE;
                tbl_emigration.REMARK = emigrationObj.REMARK;
                tbl_emigration.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_emigration.MODIFIED_DATE = DateTime.Now;
                tbl_emigration.IS_ECR = emigrationObj.IS_ECR;
                _entities.Entry(tbl_emigration).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(emigrationObj.USER_REQUIREMENT_ID, 17);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Passport_Details> GetPassportNumbers()
        {
            string status = "20";
            return common.GetPassportNumbers(status);
        }

        public string GetCandidateName(int userRequirementId)
        {
            return common.GetCandidateName(userRequirementId);
        }

        public List<Emigration> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<Emigration>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);

            var lstpolicy = ((List<Emigration>)result[0])
                .Select(x => new Emigration
                {
                    EMIGRATION_ID = x.EMIGRATION_ID,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    FE_NO = x.FE_NO,
                    PT_NO = x.PT_NO,
                    DM_NO = x.DM_NO,
                    DM_DATE = x.DM_DATE,
                    POLICY_NO = x.POLICY_NO,
                    POLICY_DATE = x.POLICY_DATE,
                    POLICY_AMOUNT = x.POLICY_AMOUNT,
                    POLICY_COMPANYNAME = x.POLICY_COMPANYNAME,
                    POLICY_ATTACHMENT = x.POLICY_ATTACHMENT,
                    SUBMISSION_DATE = x.SUBMISSION_DATE,
                    EMIGRATION_CLEARANCENO = x.EMIGRATION_CLEARANCENO,
                    EMIGRATION_ATTACHMENT = x.EMIGRATION_ATTACHMENT,
                    POE = x.POE,
                    REMARK = x.REMARK,
                    CREATED_BY = x.CREATED_BY,
                    MODIFIED_BY = x.MODIFIED_BY,
                    CREATED_DATE = x.CREATED_DATE,
                    MODIFIED_DATE = x.MODIFIED_DATE,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER,
                    IS_ECR = x.IS_ECR
                }).ToList();
            return lstpolicy;
        }
    }
}
