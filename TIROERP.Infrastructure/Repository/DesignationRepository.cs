using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
namespace TIROERP.Infrastructure.Repository
{
    public class DesignationRepository : IDesignation
    {
         ArbabTravelsERPEntities _entities;

        public void Create(Designation designation)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_DESIGNATION_MASTER tbldesignation = new TBL_DESIGNATION_MASTER();
            tbldesignation.DESIGNATION_NAME = designation.DESIGNATION_NAME;
            tbldesignation.INDUSTRY_ID = Convert.ToInt16(designation.INDUSTRY_ID);
            tbldesignation.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tbldesignation.CREATED_DATE = DateTime.Now;
            tbldesignation.IS_ACTIVE = true;
            _entities.TBL_DESIGNATION_MASTER.Add(tbldesignation);
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string designation, int industryId, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_DESIGNATION_MASTER tbldesgination = new TBL_DESIGNATION_MASTER();
            if (id == null)
            {
                tbldesgination = _entities.TBL_DESIGNATION_MASTER.Where(x => x.DESIGNATION_NAME.Trim().ToLower() == designation.Trim().ToLower() && x.IS_ACTIVE == true && x.INDUSTRY_ID == industryId).SingleOrDefault();
            }
            else
            {
                tbldesgination = _entities.TBL_DESIGNATION_MASTER.Where(x => x.DESIGNATION_NAME.Trim().ToLower() == designation.Trim().ToLower() && x.IS_ACTIVE == true && x.INDUSTRY_ID == industryId && x.DESIGNATION_ID != id).SingleOrDefault();
            }

            if (tbldesgination != null)
            {
                return true;
            }
            return false;
        }

        public void Delete(Designation designationdetails)
        {
            _entities = new  ArbabTravelsERPEntities();

            var designation = _entities.TBL_DESIGNATION_MASTER.Where(x => x.DESIGNATION_ID == designationdetails.DESIGNATION_ID).SingleOrDefault();
            designation.IS_ACTIVE = false;
            designation.MODIFIED_BY = "";
            designation.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public Designation GetDetailById(int designationId)
        {
            _entities = new  ArbabTravelsERPEntities();
            var designationdetails = from designation in _entities.TBL_DESIGNATION_MASTER
                                     join industry in _entities.TBL_INDUSTRY_MASTER
                                     on designation.INDUSTRY_ID equals industry.INDUSTRY_ID
                                     where designation.DESIGNATION_ID == designationId
                                     && designation.IS_ACTIVE == true
                                     select new Designation
                                     {
                                         DESIGNATION_ID = designation.DESIGNATION_ID,
                                         DESIGNATION_NAME = designation.DESIGNATION_NAME,
                                         INDUSTRY_NAME = industry.INDUSTRY_TYPE,
                                         INDUSTRY_ID = industry.INDUSTRY_ID
                                     };
            return designationdetails.FirstOrDefault();
        }

        public void Edit(Designation designationdetails)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var designation = _entities.TBL_DESIGNATION_MASTER.Where(x => x.DESIGNATION_ID == designationdetails.DESIGNATION_ID).SingleOrDefault();
                designation.DESIGNATION_NAME = designationdetails.DESIGNATION_NAME;
                designation.INDUSTRY_ID = Convert.ToInt16(designationdetails.INDUSTRY_ID);
                designation.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                designation.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Designation> GetAllDesignation()
        {
            _entities = new  ArbabTravelsERPEntities();
            var _lstUserUI = new List<Designation>();

            var _lstUsers = (from designation in _entities.TBL_DESIGNATION_MASTER
                             join industry in _entities.TBL_INDUSTRY_MASTER
                             on designation.INDUSTRY_ID equals industry.INDUSTRY_ID
                             where designation.IS_ACTIVE == true
                             select new Designation
                             {
                                 DESIGNATION_ID = designation.DESIGNATION_ID,
                                 DESIGNATION_NAME = designation.DESIGNATION_NAME,
                                 INDUSTRY_NAME = industry.INDUSTRY_TYPE
                             }).ToList().OrderBy(x => x.DESIGNATION_NAME).ToList();

            return _lstUsers;
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

        public List<Designation> GetDesignationByIndustry(int[] industryIds)
        {
            _entities = new  ArbabTravelsERPEntities();
            var _lstDesignation = new List<Designation>();

            _lstDesignation = _entities.TBL_DESIGNATION_MASTER.Where(x => x.IS_ACTIVE == true && industryIds.Contains(x.INDUSTRY_ID)).ToList().
                Select(c => new Designation
                {
                    DESIGNATION_ID = c.DESIGNATION_ID,
                    DESIGNATION_NAME = c.DESIGNATION_NAME,
                    INDUSTRY_ID = c.INDUSTRY_ID,
                    IS_ACTIVE = c.IS_ACTIVE
                }).OrderBy(x => x.DESIGNATION_ID).ToList();

            return _lstDesignation;
        }
    }
}
