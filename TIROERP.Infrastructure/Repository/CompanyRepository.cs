using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;

namespace TIROERP.Infrastructure.Repository
{
    public class CompanyRepository : ICompany
    {
        ArbabTravelsERPEntities _entities;
        public bool CheckDuplicate(string company_name, int? id)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_COMPANY_MASTER tblcomp = new TBL_COMPANY_MASTER();
            if (id == null)
            {
                tblcomp = _entities.TBL_COMPANY_MASTER.Where(x => x.COMPANY_NAME.Trim().ToLower() == company_name.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblcomp = _entities.TBL_COMPANY_MASTER.Where(x => x.COMPANY_NAME.Trim().ToLower() == company_name.Trim().ToLower() && x.IS_ACTIVE == true && x.COMPANY_ID != id).SingleOrDefault();
            }

            if (tblcomp != null)
            {
                return true;
            }
            return false;
        }

        public void Create(CompanyMaster company)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_COMPANY_MASTER tblCompany = new TBL_COMPANY_MASTER();
            tblCompany.COMPANY_NAME = company.COMPANY_NAME;
            tblCompany.CONTACT_PERSON = company.CONTACT_PERSON;
            tblCompany.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblCompany.CREATED_DATE = DateTime.Now;
            tblCompany.IS_ACTIVE = true;
            _entities.TBL_COMPANY_MASTER.Add(tblCompany);
            _entities.SaveChanges();
        }

        public void Delete(CompanyMaster companyDetails)
        {
            _entities = new ArbabTravelsERPEntities();

            var company = _entities.TBL_COMPANY_MASTER.Where(x => x.COMPANY_ID == companyDetails.COMPANY_ID).SingleOrDefault();
            company.IS_ACTIVE = false;
            company.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            company.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public void Edit(CompanyMaster companyDetails)
        {
            try
            {
                _entities = new ArbabTravelsERPEntities();

                var company = _entities.TBL_COMPANY_MASTER.Where(x => x.COMPANY_ID == companyDetails.COMPANY_ID).SingleOrDefault();
                company.COMPANY_NAME = companyDetails.COMPANY_NAME;
                company.CONTACT_PERSON = companyDetails.CONTACT_PERSON;
                company.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                company.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CompanyMaster> GetAllCompanies()
        {
            _entities = new ArbabTravelsERPEntities();

            var _lstUsers = _entities.TBL_COMPANY_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new CompanyMaster
                {
                    COMPANY_ID = c.COMPANY_ID,
                    COMPANY_NAME = c.COMPANY_NAME,
                    CONTACT_PERSON = c.CONTACT_PERSON

                }).OrderBy(x => x.COMPANY_NAME).ToList();

            return _lstUsers;
        }

        public CompanyMaster GetDetailById(int companyId)
        {
            _entities = new ArbabTravelsERPEntities();
            var company = from comp in _entities.TBL_COMPANY_MASTER
                          where comp.COMPANY_ID == companyId
                          select new CompanyMaster
                          {
                              COMPANY_ID = comp.COMPANY_ID,
                              COMPANY_NAME = comp.COMPANY_NAME,
                              CONTACT_PERSON = comp.CONTACT_PERSON
                          };
            return company.FirstOrDefault();
        }
    }
}
