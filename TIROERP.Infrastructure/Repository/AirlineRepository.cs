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
    public class AirlineRepository : IAirline
    {
        ArbabTravelsERPEntities _entities;

        public void Create(Airline airline)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_AIRLINES_MASTER tblairline = new TBL_AIRLINES_MASTER();
            tblairline.AirlinesName = airline.AirlinesName;
            tblairline.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblairline.CreatedDate = DateTime.Now;
            tblairline.IsActive = true;
            _entities.TBL_AIRLINES_MASTER.Add(tblairline);
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string airline, int? id)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_AIRLINES_MASTER tblairline = new TBL_AIRLINES_MASTER();
            if (id == null)
            {
                tblairline = _entities.TBL_AIRLINES_MASTER.Where(x => x.AirlinesName.Trim().ToLower() == airline.Trim().ToLower() && x.IsActive == true).SingleOrDefault();
            }
            else
            {
                tblairline = _entities.TBL_AIRLINES_MASTER.Where(x => x.AirlinesName.Trim().ToLower() == airline.Trim().ToLower() && x.IsActive == true && x.AirlinesId != id).SingleOrDefault();
            }

            if (tblairline != null)
            {
                return true;
            }
            return false;
        }

        public void Delete(Airline airlinedetails)
        {
            _entities = new ArbabTravelsERPEntities();

            var airline = _entities.TBL_AIRLINES_MASTER.Where(x => x.AirlinesId == airlinedetails.AirlinesId).SingleOrDefault();
            airline.IsActive = false;
            airline.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            airline.ModifiedDate = DateTime.Now;
            _entities.SaveChanges();
        }

        public Airline GetDetailById(int airlineId)
        {
            _entities = new ArbabTravelsERPEntities();
            var airlinedetails = from airline in _entities.TBL_AIRLINES_MASTER
                                 where airline.AirlinesId == airlineId
                                 select new Airline
                                 {
                                     AirlinesId = airline.AirlinesId,
                                     AirlinesName = airline.AirlinesName,
                                 };
            return airlinedetails.FirstOrDefault();
        }

        public void Edit(Airline airlinedetails)
        {
            try
            {
                _entities = new ArbabTravelsERPEntities();

                var airline = _entities.TBL_AIRLINES_MASTER.Where(x => x.AirlinesId == airlinedetails.AirlinesId).SingleOrDefault();
                airline.AirlinesName = airlinedetails.AirlinesName;
                airline.ModifiedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                airline.ModifiedDate = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Airline> GetAllAirline()
        {
            _entities = new ArbabTravelsERPEntities();
            var _lstUserUI = new List<Airline>();

            var _lstUsers = _entities.TBL_AIRLINES_MASTER.Where(x => x.IsActive == true).ToList().
                Select(c => new Airline
                {
                    AirlinesId = c.AirlinesId,
                    AirlinesName = c.AirlinesName,
                }).OrderBy(x => x.AirlinesName).ToList();

            return _lstUsers;
        }
    }
}
