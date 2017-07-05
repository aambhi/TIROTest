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
    public class SpecializationRepository : ISpecialization
    {
         ArbabTravelsERPEntities _entities;

        public void Create(Specialization specialization)
        {
            _entities = new  ArbabTravelsERPEntities();
            TBL_SPECIALIZATION_MASTER tblSpecialization = new TBL_SPECIALIZATION_MASTER();
            tblSpecialization.SPECIALIZATION_TYPE = specialization.SPECIALIZATION_TYPE;
            tblSpecialization.EDUCATION_TYPE_ID = specialization.EDUCATION_TYPE_ID;
            tblSpecialization.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblSpecialization.CREATED_DATE = DateTime.Now;
            tblSpecialization.IS_ACTIVE = true;

            _entities.TBL_SPECIALIZATION_MASTER.Add(tblSpecialization);
            _entities.SaveChanges();
        }

        public List<Specialization> GetAllSpecialization()
        {
            _entities = new  ArbabTravelsERPEntities();

            var _lstUsers = _entities.PROC_GET_ALL_SPECIALIZATIONS(null)
                            .Select(x => new Specialization
                            {
                                SPECIALIZATION_ID = x.SPECIALIZATION_ID,
                                SPECIALIZATION_TYPE = x.SPECIALIZATION_TYPE,
                                EDUCATION_TYPE_ID = x.EDUCATION_TYPE_ID,
                                EDUCATION_TYPE = x.EDUCATION_TYPE
                            }).ToList();

            return _lstUsers;
        }

        public List<EducationType> GetAllEducationList()
        {
            _entities = new  ArbabTravelsERPEntities();

            var _lstUsers = _entities.TBL_EDUCATION_TYPE_MASTER.Where(x => x.IS_ACTIVE == true)
                            .Select(x => new EducationType
                            {
                                EDUCATION_TYPE_ID = x.EDUCATION_TYPE_ID,
                                EDUCATION_TYPE = x.EDUCATION_TYPE
                            }).OrderBy(x => x.EDUCATION_TYPE_ID).ToList();

            return _lstUsers;
        }

        public void Edit(Specialization specialization)
        {
            try
            {
                _entities = new  ArbabTravelsERPEntities();

                var specializationType = _entities.TBL_SPECIALIZATION_MASTER.Where(x => x.SPECIALIZATION_ID == specialization.SPECIALIZATION_ID).SingleOrDefault();
                specializationType.EDUCATION_TYPE_ID = specialization.EDUCATION_TYPE_ID;
                specializationType.SPECIALIZATION_TYPE = specialization.SPECIALIZATION_TYPE;
                specializationType.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                specializationType.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Specialization specialization)
        {
            _entities = new  ArbabTravelsERPEntities();

            var specializationDetail = _entities.TBL_SPECIALIZATION_MASTER.Where(x => x.SPECIALIZATION_ID == specialization.SPECIALIZATION_ID).SingleOrDefault();
            specializationDetail.IS_ACTIVE = false;
            specializationDetail.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            specializationDetail.MODIFIED_DATE = DateTime.Now;
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string specialization_type, int education_type_id, int? id)
        {
            _entities = new  ArbabTravelsERPEntities();

            TBL_SPECIALIZATION_MASTER tblspec = new TBL_SPECIALIZATION_MASTER();
            if (id == null)
            {
                tblspec = _entities.TBL_SPECIALIZATION_MASTER.Where(x => x.SPECIALIZATION_TYPE.Trim().ToLower() == specialization_type.Trim().ToLower() && x.EDUCATION_TYPE_ID == education_type_id && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tblspec = _entities.TBL_SPECIALIZATION_MASTER.Where(x => x.SPECIALIZATION_TYPE.Trim().ToLower() == specialization_type.Trim().ToLower() && x.EDUCATION_TYPE_ID == education_type_id && x.IS_ACTIVE == true && x.SPECIALIZATION_ID != id).SingleOrDefault();
            }

            if (tblspec != null)
            {
                return true;
            }
            return false;
        }

        public Specialization GetSpecializationById(int specialization_type_id)
        {
            _entities = new  ArbabTravelsERPEntities();
            var specializationDetails = _entities.PROC_GET_ALL_SPECIALIZATIONS(specialization_type_id)
                            .Select(x => new Specialization
                            {
                                SPECIALIZATION_ID = x.SPECIALIZATION_ID,
                                SPECIALIZATION_TYPE = x.SPECIALIZATION_TYPE,
                                EDUCATION_TYPE_ID = x.EDUCATION_TYPE_ID,
                                EDUCATION_TYPE = x.EDUCATION_TYPE
                            }).SingleOrDefault();


            return specializationDetails;
        }
    }
}
