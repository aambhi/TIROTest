using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Interface;
using TIROERP.Core.Model;
namespace TIROERP.Infrastructure.Repository
{
    public class EducationRepository : IEducation
    {
         ArbabTravelsERPEntities _entities;
        public void Create(EducationType education)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_EDUCATION_TYPE_MASTER tblEducation = new TBL_EDUCATION_TYPE_MASTER();
            tblEducation.EDUCATION_TYPE = education.EDUCATION_TYPE;
            tblEducation.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblEducation.CREATED_DATE = DateTime.Now;
            tblEducation.IS_ACTIVE = true;

            _entities.TBL_EDUCATION_TYPE_MASTER.Add(tblEducation);
            _entities.SaveChanges();
        }

        public List<EducationType> GetAllEducationList()
        {
            _entities = new  ArbabTravelsERPEntities();

            var _lstUsers = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.IS_ACTIVE == true)
                            .Select(x => new EducationType
                            {
                                EDUCATION_TYPE_ID = x.EDUCATION_TYPE_ID,
                                EDUCATION_TYPE = x.EDUCATION_TYPE
                            }).OrderBy(x => x.EDUCATION_TYPE).ToList();

            return _lstUsers;
        }

        public void Edit(EducationType education)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var educationType = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.EDUCATION_TYPE_ID == education.EDUCATION_TYPE_ID).SingleOrDefault();
                educationType.EDUCATION_TYPE = education.EDUCATION_TYPE;
                educationType.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                educationType.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(EducationType edu)
        {
            _entities = new  ArbabTravelsERPEntities();

            var education = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.EDUCATION_TYPE_ID == edu.EDUCATION_TYPE_ID).SingleOrDefault();
            education.IS_ACTIVE = false;
            education.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            education.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string education_type, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();

            TBL_EDUCATION_TYPE_MASTER tbledu = new TBL_EDUCATION_TYPE_MASTER();
            if (id == null)
            {
                tbledu = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.EDUCATION_TYPE.Trim().ToLower() == education_type.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tbledu = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.EDUCATION_TYPE.Trim().ToLower() == education_type.Trim().ToLower() && x.IS_ACTIVE == true && x.EDUCATION_TYPE_ID != id).SingleOrDefault();
            }

            if (tbledu != null)
            {
                return true;
            }
            return false;
        }

        public EducationType GetEducationById(int education_type_id)
        {
            _entities = new  ArbabTravelsERPEntities();
            var educationDetails = from education in _entities.TBL_EDUCATION_TYPE_MASTER
                                   where education.EDUCATION_TYPE_ID == education_type_id
                                   select new EducationType
                                   {
                                       EDUCATION_TYPE_ID = education.EDUCATION_TYPE_ID,
                                       EDUCATION_TYPE = education.EDUCATION_TYPE
                                   };
            return educationDetails.FirstOrDefault();
        }
    }
}
