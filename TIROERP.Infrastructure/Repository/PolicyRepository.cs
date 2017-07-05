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
    public class PolicyRepository : IPolicy
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        
        public void Create(Policy policyObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_POLICY tbl_policy = new TBL_POLICY();

            try
            {
                tbl_policy.Policy = policyObj.PolicyNumber;
                tbl_policy.USER_REQUIREMENT_ID = policyObj.USER_REQUIREMENT_ID;
                tbl_policy.PolicyFees = policyObj.PolicyFees;
                tbl_policy.PolicyDate = policyObj.PolicyDate;
                tbl_policy.PolicyRemark = policyObj.PolicyRemark;
                tbl_policy.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_policy.CreatedDate = DateTime.Now;

                _entities.TBL_POLICY.Add(tbl_policy);
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(policyObj.USER_REQUIREMENT_ID, 17);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Policy policyObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_POLICY tbl_policy = new TBL_POLICY();

            try
            {
                tbl_policy.POLICYID = policyObj.POLICYID;
                tbl_policy.Policy = policyObj.PolicyNumber;
                tbl_policy.USER_REQUIREMENT_ID = policyObj.USER_REQUIREMENT_ID;
                tbl_policy.PolicyFees = policyObj.PolicyFees;
                tbl_policy.PolicyDate = policyObj.PolicyDate;
                tbl_policy.PolicyRemark = policyObj.PolicyRemark;
                tbl_policy.CreatedBy = policyObj.CreatedBy;
                tbl_policy.CreatedDate = policyObj.CreatedDate;
                tbl_policy.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_policy.ModifiedDate = DateTime.Now;
                _entities.Entry(tbl_policy).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
                _entities.PROC_UPDATE_USER_STATUS(policyObj.USER_REQUIREMENT_ID, 17);
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

        public List<Policy> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<Policy>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);

            var lstpolicy = ((List<Policy>)result[0])
                .Select(x => new Policy
                {
                    POLICYID = x.POLICYID,
                    PolicyDate = x.PolicyDate,
                    PolicyFees = x.PolicyFees,
                    PolicyNumber = x.PolicyNumber,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    PolicyRemark = x.PolicyRemark,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER
                }).ToList();
            return lstpolicy;
        }
    }
}