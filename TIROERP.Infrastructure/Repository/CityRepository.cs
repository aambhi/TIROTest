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
    public class CityRepository : ICity
    {
        ArbabTravelsERPEntities _entities;
        public bool CheckDuplicate(string city_name, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_CITY_MASTER tblcity = new TBL_CITY_MASTER();
            if (id == null)
            {
                tblcity = _entities.TBL_CITY_MASTER.Where(x => x.CITY_NAME.Trim().ToLower() == city_name.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblcity = _entities.TBL_CITY_MASTER.Where(x => x.CITY_NAME.Trim().ToLower() == city_name.Trim().ToLower() && x.IS_ACTIVE == true && x.ID != id).SingleOrDefault();
            }

            if (tblcity != null)
            {
                return true;
            }
            return false;
        }

        public void Create(City city)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_CITY_MASTER tblCity = new TBL_CITY_MASTER();
            tblCity.CITY_NAME = city.CITY_NAME;
            tblCity.CITY_CODE = city.CITY_CODE;
            tblCity.STATE_CODE = city.STATE_CODE;
            tblCity.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblCity.CREATED_DATE = DateTime.Now;
            tblCity.IS_ACTIVE = true;
            _entities.TBL_CITY_MASTER.Add(tblCity);
            _entities.SaveChanges();
        }

        public void Delete(City cityDetails)
        {
            _entities = new  ArbabTravelsERPEntities();

            var city = _entities.TBL_CITY_MASTER.Where(x => x.ID == cityDetails.CityId).SingleOrDefault();
            city.IS_ACTIVE = false;
            city.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            city.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public void Edit(City cityDetails)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var city = _entities.TBL_CITY_MASTER.Where(x => x.ID == cityDetails.CityId).SingleOrDefault();
                city.STATE_CODE = cityDetails.STATE_CODE;
                city.CITY_NAME = cityDetails.CITY_NAME;
                city.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                city.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<City> GetAllCities()
        {
            _entities = new  ArbabTravelsERPEntities();

            var _lstUsers = _entities.PROC_GET_ALL_CITIES(null).
                Select(c => new City
                {
                    CITY_CODE = c.CITY_CODE,
                    CITY_NAME = c.CITY_NAME,
                    STATE_NAME = c.STATE_NAME,
                    STATE_CODE = c.STATE_CODE,
                    CityId = c.ID
                }).OrderBy(x => x.CITY_NAME).ToList();

            return _lstUsers;
        }

        public List<State> GetAllStates()
        {
            _entities = new  ArbabTravelsERPEntities();
            var _lstUserUI = new List<State>();

            var _lstUsers = _entities.TBL_STATE_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new State
                {
                    STATE_CODE = c.STATE_CODE,
                    STATE_NAME = c.STATE_NAME,
                    COUNTRY_CODE = c.COUNTRY_CODE,
                    StateId=c.ID
                }).OrderBy(x => x.STATE_NAME).ToList();

            return _lstUsers;
        }

        public City GetDetailById(int? cityId)
        {
            _entities = new  ArbabTravelsERPEntities();
            var cityDetails = _entities.PROC_GET_ALL_CITIES(cityId).
                Select(c => new City
                {
                    CITY_CODE = c.CITY_CODE,
                    CITY_NAME = c.CITY_NAME,
                    STATE_NAME = c.STATE_NAME,
                    STATE_CODE=c.STATE_CODE,
                    CityId = c.ID
                }).OrderBy(x => x.CITY_NAME).SingleOrDefault();

            return cityDetails;
        }
    }
}
