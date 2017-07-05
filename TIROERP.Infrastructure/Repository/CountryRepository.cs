using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIROERP.Core.Interface;
using TIROERP.Core.Model;

namespace TIROERP.Infrastructure.Repository
{
    public class CountryRepository : ICountry
    {
        ArbabTravelsERPEntities _entities;
        public void Create(Country country)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_COUNTRY_MASTER tblcountry = new TBL_COUNTRY_MASTER();
            tblcountry.COUNTRY_NAME = country.COUNTRY_NAME;
            tblcountry.COUNTRY_CODE = country.COUNTRY_CODE;
            tblcountry.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblcountry.CREATED_DATE = DateTime.Now;
            tblcountry.IS_ACTIVE = true;
            _entities.TBL_COUNTRY_MASTER.Add(tblcountry);
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string country_name, int? id)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_COUNTRY_MASTER tblcountry = new TBL_COUNTRY_MASTER();
            if (id == null)
            {
                tblcountry = _entities.TBL_COUNTRY_MASTER.Where(x => x.COUNTRY_NAME.Trim().ToLower() == country_name.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblcountry = _entities.TBL_COUNTRY_MASTER.Where(x => x.COUNTRY_NAME.Trim().ToLower() == country_name.Trim().ToLower() && x.IS_ACTIVE == true && x.ID != id).SingleOrDefault();
            }

            if (tblcountry != null)
            {
                return true;
            }
            return false;
        }

        public void Delete(Country countrydetails)
        {
            _entities = new ArbabTravelsERPEntities();

            var country = _entities.TBL_COUNTRY_MASTER.Where(x => x.ID == countrydetails.CountryId).SingleOrDefault();
            country.IS_ACTIVE = false;
            country.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            country.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public Country GetDetailById(int country_Code)
        {
            _entities = new ArbabTravelsERPEntities();
            var countrydetails = from country in _entities.TBL_COUNTRY_MASTER
                                 where country.ID == country_Code
                                 select new Country
                                 {
                                     COUNTRY_CODE = country.COUNTRY_CODE,
                                     COUNTRY_NAME = country.COUNTRY_NAME,
                                     IS_ACTIVE = country.IS_ACTIVE,
                                     CountryId = country.ID
                                 };
            return countrydetails.FirstOrDefault();
        }

        public void Edit(Country countrydetails)
        {
            try
            {
                _entities = new ArbabTravelsERPEntities();

                var country = _entities.TBL_COUNTRY_MASTER.Where(x => x.ID == countrydetails.CountryId).SingleOrDefault();
                country.COUNTRY_NAME = countrydetails.COUNTRY_NAME;
                country.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                country.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Country> GetAllCountry()
        {
            _entities = new ArbabTravelsERPEntities();
            var _lstUserUI = new List<Country>();

            var _lstUsers = _entities.TBL_COUNTRY_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new Country
                {
                    COUNTRY_CODE = c.COUNTRY_CODE,
                    COUNTRY_NAME = c.COUNTRY_NAME,
                    IS_ACTIVE = c.IS_ACTIVE,
                    CountryId = c.ID
                }).OrderBy(x => x.COUNTRY_NAME).ToList();

            return _lstUsers;
        }
    }
}
