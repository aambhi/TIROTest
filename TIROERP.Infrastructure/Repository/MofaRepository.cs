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
    public class MofaRepository : IMofa
    {
        ArbabTravelsERPEntities _entities;
        CommonRepository common = new CommonRepository();
        public void Create(Mofa mofaObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_MOFA tbl_mofa = new TBL_MOFA();
            try
            {
                tbl_mofa.USER_REQUIREMENT_ID = mofaObj.USER_REQUIREMENT_ID;
                tbl_mofa.MofaNumber = mofaObj.MofaNumber;
                tbl_mofa.MofaDate = !string.IsNullOrEmpty(mofaObj.MofaDate) ? Convert.ToDateTime(mofaObj.MofaDate) : (DateTime?)null;
                tbl_mofa.ApplicationNumber = mofaObj.ApplicationNumber;
                tbl_mofa.ApplicationDate = !string.IsNullOrEmpty(mofaObj.ApplicationDate) ? Convert.ToDateTime(mofaObj.ApplicationDate) : (DateTime?)null;
                tbl_mofa.HealthNumber = mofaObj.HealthNumber;
                tbl_mofa.HealthDate = !string.IsNullOrEmpty(mofaObj.HealthDate) ? Convert.ToDateTime(mofaObj.HealthDate) : (DateTime?)null;
                tbl_mofa.DDDate = !string.IsNullOrEmpty(mofaObj.DDDate) ? Convert.ToDateTime(mofaObj.DDDate) : (DateTime?)null;
                tbl_mofa.DDNumber = mofaObj.DDNumber;
                tbl_mofa.MofaFilePath = mofaObj.MofaFilePath;
                tbl_mofa.MofaRemark = mofaObj.MofaRemark;
                tbl_mofa.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_mofa.CreatedDate = DateTime.Now;

                _entities.TBL_MOFA.Add(tbl_mofa);
                _entities.SaveChanges();

                if (mofaObj.MofaNumber != null)
                {
                    _entities.PROC_UPDATE_USER_STATUS(mofaObj.USER_REQUIREMENT_ID, 16);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Mofa mofaObj)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_MOFA tbl_mofa = new TBL_MOFA();
            try
            {
                tbl_mofa.MofaID = mofaObj.MofaID;
                tbl_mofa.USER_REQUIREMENT_ID = mofaObj.USER_REQUIREMENT_ID;
                tbl_mofa.MofaNumber = mofaObj.MofaNumber;
                tbl_mofa.MofaDate = !string.IsNullOrEmpty(mofaObj.MofaDate) ? Convert.ToDateTime(mofaObj.MofaDate) : (DateTime?)null;
                tbl_mofa.ApplicationNumber = mofaObj.ApplicationNumber;
                tbl_mofa.ApplicationDate = !string.IsNullOrEmpty(mofaObj.ApplicationDate) ? Convert.ToDateTime(mofaObj.ApplicationDate) : (DateTime?)null;
                tbl_mofa.HealthNumber = mofaObj.HealthNumber;
                tbl_mofa.HealthDate = !string.IsNullOrEmpty(mofaObj.HealthDate) ? Convert.ToDateTime(mofaObj.HealthDate) : (DateTime?)null;
                tbl_mofa.DDDate = !string.IsNullOrEmpty(mofaObj.DDDate) ? Convert.ToDateTime(mofaObj.DDDate) : (DateTime?)null;
                tbl_mofa.DDNumber = mofaObj.DDNumber;
                tbl_mofa.MofaFilePath = mofaObj.MofaFilePath;
                tbl_mofa.MofaRemark = mofaObj.MofaRemark;
                tbl_mofa.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_mofa.ModifiedDate = DateTime.Now;
                tbl_mofa.CreatedBy = mofaObj.CreatedBy;
                tbl_mofa.CreatedDate = mofaObj.CreatedDate;

                _entities.Entry(tbl_mofa).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();

                if (mofaObj.DDNumber != null)
                {
                    _entities.PROC_UPDATE_USER_STATUS(mofaObj.USER_REQUIREMENT_ID, 16);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Passport_Details> GetPassportNumbers()
        {
            string status = "19";
            return common.GetPassportNumbers(status);
        }

        public string GetCandidateName(int userRequirementId)
        {
            return common.GetCandidateName(userRequirementId);
        }

        public List<Mofa> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null)
        {
            var ID = new SqlParameter { ParameterName = "ID", Value = id };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var CONDITION_OPERATOR = new SqlParameter { ParameterName = "CONDITION_OPERATOR", Value = condition_operator };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var PASSPORT_NUMBER = new SqlParameter { ParameterName = "PASSPORT_NUMBER", Value = passportNo };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_GET_ALL_PROCESS]")
                .With<Mofa>()
                .Execute(ID, CREATED_BY, CONDITION_OPERATOR, FROMDATE, TODATE, PASSPORT_NUMBER);


            var lstmofa = ((List<Mofa>)result[0])
                .Select(x => new Mofa
                {
                    MofaID = x.MofaID,
                    MofaNumber = x.MofaNumber,
                    MofaDate = x.MofaDate,
                    ApplicationNumber = x.ApplicationNumber,
                    ApplicationDate = x.ApplicationDate,
                    HealthNumber = x.HealthNumber,
                    HealthDate = x.HealthDate,
                    DDNumber = x.DDNumber,
                    DDDate = x.DDDate,
                    CANDIDATE_NAME = x.CANDIDATE_NAME,
                    REGISTRATION_NO = x.REGISTRATION_NO,
                    USER_REQUIREMENT_ID = x.USER_REQUIREMENT_ID,
                    MofaFilePath = x.MofaFilePath,
                    MofaRemark = x.MofaRemark,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    PASSPORT_NUMBER = x.PASSPORT_NUMBER

                }).ToList();
            return lstmofa;
        }
    }
}