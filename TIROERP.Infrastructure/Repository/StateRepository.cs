using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
namespace TIROERP.Infrastructure.Repository
{
    public class StateRepository : IState
    {
         ArbabTravelsERPEntities _entities;
        public bool CheckDuplicate(string state_name, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_STATE_MASTER tblstate = new TBL_STATE_MASTER();
            if (id == null)
            {
                tblstate = _entities.TBL_STATE_MASTER.Where(x => x.STATE_NAME.Trim().ToLower() == state_name.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblstate = _entities.TBL_STATE_MASTER.Where(x => x.STATE_NAME.Trim().ToLower() == state_name.Trim().ToLower() && x.IS_ACTIVE == true && x.ID != id).SingleOrDefault();
            }

            if (tblstate != null)
            {
                return true;
            }
            return false;
        }

        public void Create(State state)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_STATE_MASTER tblState = new TBL_STATE_MASTER();
            tblState.STATE_NAME = state.STATE_NAME;
            tblState.STATE_CODE = state.STATE_CODE;
            tblState.COUNTRY_CODE = state.COUNTRY_CODE;
            tblState.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblState.CREATED_DATE = DateTime.Now;
            tblState.IS_ACTIVE = true;
            _entities.TBL_STATE_MASTER.Add(tblState);
            _entities.SaveChanges();
        }

        public void Delete(State stateDetails)
        {
            _entities = new  ArbabTravelsERPEntities();

            var state = _entities.TBL_STATE_MASTER.Where(x => x.ID == stateDetails.StateId).SingleOrDefault();
            state.IS_ACTIVE = false;
            state.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            state.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public void Edit(State stateDetails)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var state = _entities.TBL_STATE_MASTER.Where(x => x.ID == stateDetails.StateId).SingleOrDefault();
                state.COUNTRY_CODE = stateDetails.COUNTRY_CODE;
                state.STATE_NAME = stateDetails.STATE_NAME;
                state.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                state.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Country> GetAllCountry()
        {
            _entities = new  ArbabTravelsERPEntities();
            var _lstUserUI = new List<Country>();

            var _lstUsers = _entities.TBL_COUNTRY_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new Country
                {
                    CountryId = c.ID,
                    COUNTRY_NAME = c.COUNTRY_NAME,
                }).OrderBy(x => x.COUNTRY_NAME).ToList();

            return _lstUsers;
        }

        public List<State> GetAllState()
        {
            _entities = new  ArbabTravelsERPEntities();

            var _lstUsers = _entities.PROC_GET_ALL_STATES(null).
                Select(c => new State
                {
                    STATE_CODE = c.STATE_CODE,
                    STATE_NAME = c.STATE_NAME,
                    COUNTRY_NAME = c.COUNTRY_NAME,
                    StateId=c.ID
                }).OrderBy(x => x.STATE_NAME).ToList();

            return _lstUsers;
        }

        public State GetDetailById(int? stateId)
        {
            _entities = new  ArbabTravelsERPEntities();
            var stateDetails = _entities.PROC_GET_ALL_STATES(stateId).
                Select(c => new State
                {
                    STATE_CODE = c.STATE_CODE,
                    STATE_NAME = c.STATE_NAME,
                    COUNTRY_NAME = c.COUNTRY_NAME,
                    COUNTRY_CODE=c.COUNTRY_CODE,
                    StateId = c.ID
                }).SingleOrDefault();

            return stateDetails;
        }
    }
}
