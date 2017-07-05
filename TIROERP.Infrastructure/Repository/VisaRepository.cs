using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using System.Web;
using System.Data.SqlClient;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class VisaRepository : IVisa
    {
        ArbabTravelsERPEntities _entities;
        public void Create(Visa visa)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_VISA_MASTER tbl_visa = new TBL_VISA_MASTER();
            try
            {
                tbl_visa.REGISTRATION_NUMBER = visa.REGISTRATION_NUMBER;
                tbl_visa.CIVILIAN_NUMBER = visa.CIVILIAN_NUMBER;
                tbl_visa.VISA_NUMBER = visa.VISA_NUMBER;
                tbl_visa.PLACE_OF_ENDORSEMENT = visa.PLACE_OF_ENDORSEMENT;
                tbl_visa.ISSUE_DATE = visa.INDIAN_FORMAT_ISSUE_DATE;
                tbl_visa.EXPIRY_DATE = visa.INDIAN_FORMAT_EXPIRY_DATE;
                tbl_visa.RECIEVED_DATE = Convert.ToDateTime(visa.RECIEVED_DATE);
                tbl_visa.FILE_PATH = visa.FILE_PATH;
                tbl_visa.REMARK = visa.REMARK;
                tbl_visa.PURPOSE = visa.PURPOSE;
                tbl_visa.IS_ACTIVE = true;
                tbl_visa.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_visa.CREATED_DATE = DateTime.Now;
                _entities.TBL_VISA_MASTER.Add(tbl_visa);
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(Visa visa)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_VISA_MASTER tbl_visa = new TBL_VISA_MASTER();
            try
            {
                tbl_visa.VISA_ID = visa.VISA_ID;
                tbl_visa.REGISTRATION_NUMBER = visa.REGISTRATION_NUMBER;
                tbl_visa.CIVILIAN_NUMBER = visa.CIVILIAN_NUMBER;
                tbl_visa.VISA_NUMBER = visa.VISA_NUMBER;
                tbl_visa.PLACE_OF_ENDORSEMENT = visa.PLACE_OF_ENDORSEMENT;
                tbl_visa.ISSUE_DATE = visa.INDIAN_FORMAT_ISSUE_DATE;
                tbl_visa.EXPIRY_DATE = visa.INDIAN_FORMAT_EXPIRY_DATE;
                tbl_visa.RECIEVED_DATE = Convert.ToDateTime(visa.RECIEVED_DATE);
                tbl_visa.FILE_PATH = visa.FILE_PATH;
                tbl_visa.REMARK = visa.REMARK;
                tbl_visa.PURPOSE = visa.PURPOSE;
                tbl_visa.IS_ACTIVE = true;
                tbl_visa.CREATED_BY = visa.CREATED_BY;
                tbl_visa.CREATED_DATE = visa.CREATED_DATE;
                tbl_visa.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_visa.MODIFIED_DATE = DateTime.Now;
                _entities.Entry(tbl_visa).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Visa visa)
        {
            _entities = new ArbabTravelsERPEntities();

            var designation = _entities.TBL_VISA_MASTER.Where(x => x.VISA_ID == visa.VISA_ID).SingleOrDefault();
            designation.IS_ACTIVE = false;
            designation.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            designation.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public List<Visa> GetAllVisa(int visaid, DateTime? fromDate = null, DateTime? toDate = null, string visaNo = null, string conditionOperator = null)
        {
            var VISA_ID = new SqlParameter { ParameterName = "VISA_ID", Value = visaid };
            var CREATED_BY = new SqlParameter { ParameterName = "CREATED_BY", Value = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO) };
            var FROMDATE = new SqlParameter { ParameterName = "FROMDATE", Value = fromDate };
            var TODATE = new SqlParameter { ParameterName = "TODATE", Value = toDate };
            var VISA_NUMBER = new SqlParameter { ParameterName = "VISA_NUMBER", Value = visaNo };
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = conditionOperator };

            var result = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_VISA_GETALLVISA]")
                .With<Visa>()
                .Execute(CREATED_BY, VISA_ID, VISA_NUMBER, FROMDATE, TODATE, CONDITIONAL_OPERATOR);

            var _lstUsers = ((List<Visa>)result[0]).
                Select(c => new Visa
                {
                    VISA_ID = c.VISA_ID,
                    CIVILIAN_NUMBER = c.CIVILIAN_NUMBER,
                    VISA_NUMBER = c.VISA_NUMBER,
                    PURPOSE = c.PURPOSE,
                    PLACE_OF_ENDORSEMENT = c.PLACE_OF_ENDORSEMENT,
                    INDIAN_FORMAT_ISSUE_DATE = c.INDIAN_FORMAT_ISSUE_DATE,
                    INDIAN_FORMAT_EXPIRY_DATE = c.INDIAN_FORMAT_EXPIRY_DATE,
                    RECIEVED_DATE = c.RECIEVED_DATE,
                    REGISTRATION_NUMBER = c.REGISTRATION_NUMBER,
                    CLIENT_NAME = c.CLIENT_NAME,
                    FILE_PATH = c.FILE_PATH,
                    REMARK = c.REMARK,
                    CREATED_BY = c.CREATED_BY,
                    CREATED_DATE = c.CREATED_DATE

                }).ToList();

            return _lstUsers;
        }

        public List<GetClient> GetClient()
        {
            _entities = new ArbabTravelsERPEntities();
            var clienresult = (from user in _entities.TBL_USER_DETAILS
                               join personal in _entities.TBL_USER_PERSONAL_DETAILS on user.REGISTRATION_NO equals personal.REGISTRATION_NO
                               where user.USER_TYPE_ID == 5 && personal.IS_ACTIVE == true
                               select new GetClient
                               {
                                   REGISTRATION_NO = user.REGISTRATION_NO,
                                   NAME = (user.COMPANY_NAME + " | " + personal.FIRST_NAME + " " + personal.LAST_NAME)
                               }).OrderBy(x => x.NAME).ToList();
            return clienresult;
        }

        public string GetCivilianNo(string registration_no)
        {
            _entities = new ArbabTravelsERPEntities();
            var civilian_no = _entities.TBL_USER_DETAILS.Where(x => x.REGISTRATION_NO.Trim().ToLower() == registration_no.Trim().ToLower()).Select(d => d.CIVILIAN_NO).SingleOrDefault();

            return civilian_no;
        }
    }
}
