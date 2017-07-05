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
    public class IndustryRepository : IIndustry
    {
         ArbabTravelsERPEntities _entities;
        public void Create(Industry industry)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_INDUSTRY_MASTER tblindustry = new TBL_INDUSTRY_MASTER();
            tblindustry.INDUSTRY_TYPE = industry.INDUSTRY_TYPE;
            tblindustry.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblindustry.CREATED_DATE = DateTime.Now;
            tblindustry.IS_ACTIVE = true;
            _entities.TBL_INDUSTRY_MASTER.Add(tblindustry);
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string industry, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();

            TBL_INDUSTRY_MASTER tblindustry = new TBL_INDUSTRY_MASTER();
            if (id == null)
            {
                tblindustry = _entities.TBL_INDUSTRY_MASTER.Where(x => x.INDUSTRY_TYPE.Trim().ToLower() == industry.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblindustry = _entities.TBL_INDUSTRY_MASTER.Where(x => x.INDUSTRY_TYPE.Trim().ToLower() == industry.Trim().ToLower() && x.IS_ACTIVE == true && x.INDUSTRY_ID != id).SingleOrDefault();
            }

            if (tblindustry != null)
            {
                return true;
            }
            return false;
        }

        public void Delete(Industry industrydetails)
        {
            _entities = new  ArbabTravelsERPEntities();

            var industry = _entities.TBL_INDUSTRY_MASTER.Where(x => x.INDUSTRY_ID == industrydetails.INDUSTRY_ID).SingleOrDefault();
            industry.IS_ACTIVE = false;
            industry.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            industry.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public Industry GetDetailById(int industryId)
        {
            _entities = new  ArbabTravelsERPEntities();
            var industrydetails = from industry in _entities.TBL_INDUSTRY_MASTER
                                  where industry.INDUSTRY_ID == industryId
                                  select new Industry
                                  {
                                      INDUSTRY_ID = industry.INDUSTRY_ID,
                                      INDUSTRY_TYPE = industry.INDUSTRY_TYPE,
                                  };
            return industrydetails.FirstOrDefault();
        }

        public void Edit(Industry industrydetails)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var industry = _entities.TBL_INDUSTRY_MASTER.Where(x => x.INDUSTRY_ID == industrydetails.INDUSTRY_ID).SingleOrDefault();
                industry.INDUSTRY_TYPE = industrydetails.INDUSTRY_TYPE;
                industry.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                industry.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Industry> GetAllIndustry()
        {
            _entities = new  ArbabTravelsERPEntities();
            var _lstUserUI = new List<Industry>();

            var _lstUsers = _entities.TBL_INDUSTRY_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new Industry
                {
                    INDUSTRY_ID = c.INDUSTRY_ID,
                    INDUSTRY_TYPE = c.INDUSTRY_TYPE,
                }).OrderBy(x => x.INDUSTRY_TYPE).ToList();

            return _lstUsers;
        }
    }
}
