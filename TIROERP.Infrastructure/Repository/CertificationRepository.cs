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
    public class CertificationRepository : ICertification
    {
        ArbabTravelsERPEntities _entities;

        public void Create(Certification certification)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_CERTIFICATION_MASTER tblcertification = new TBL_CERTIFICATION_MASTER();
            tblcertification.CERTIFICATION_NAME = certification.CERTIFICATION_NAME;
            tblcertification.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
            tblcertification.CREATED_DATE = DateTime.Now;
            tblcertification.IS_ACTIVE = true;
            _entities.TBL_CERTIFICATION_MASTER.Add(tblcertification);
            _entities.SaveChanges();
        }

        public bool CheckDuplicate(string certification, int? id)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_CERTIFICATION_MASTER tcm = new TBL_CERTIFICATION_MASTER();
            if (id == null)
            {
                tcm = _entities.TBL_CERTIFICATION_MASTER.Where(x => x.CERTIFICATION_NAME.Trim().ToLower() == certification.Trim().ToLower() && x.IS_ACTIVE == true).SingleOrDefault();
            }
            else
            {
                tcm = _entities.TBL_CERTIFICATION_MASTER.Where(x => x.CERTIFICATION_NAME.Trim().ToLower() == certification.Trim().ToLower() && x.IS_ACTIVE == true && x.CERTIFICATION_ID != id).SingleOrDefault();
            }
            if (tcm != null)
            {
                return true;
            }
            return false;
        }

        public void Delete(Certification certificationdetails)
        {
            _entities = new ArbabTravelsERPEntities();

            var certification = _entities.TBL_CERTIFICATION_MASTER.Where(x => x.CERTIFICATION_ID == certificationdetails.CERTIFICATION_ID).SingleOrDefault();
            certification.IS_ACTIVE = false;
            _entities.SaveChanges();
        }

        public Certification GetDetailById(int certificationId)
        {
            _entities = new ArbabTravelsERPEntities();
            var certificationdetails = from certification in _entities.TBL_CERTIFICATION_MASTER
                                       where certification.CERTIFICATION_ID == certificationId
                                       select new Certification
                                       {
                                           CERTIFICATION_ID = certification.CERTIFICATION_ID,
                                           CERTIFICATION_NAME = certification.CERTIFICATION_NAME,
                                       };
            return certificationdetails.FirstOrDefault();
        }

        public void Edit(Certification certificationdetails)
        {
            try
            {
                _entities = new ArbabTravelsERPEntities();

                var certification = _entities.TBL_CERTIFICATION_MASTER.Where(x => x.CERTIFICATION_ID == certificationdetails.CERTIFICATION_ID).SingleOrDefault();
                certification.CERTIFICATION_NAME = certificationdetails.CERTIFICATION_NAME;
                _entities.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Certification> GetAllCertification()
        {
            _entities = new ArbabTravelsERPEntities();
            var _lstUserUI = new List<Certification>();

            var _lstUsers = _entities.TBL_CERTIFICATION_MASTER.Where(x => x.IS_ACTIVE == true).ToList().
                Select(c => new Certification
                {
                    CERTIFICATION_ID = c.CERTIFICATION_ID,
                    CERTIFICATION_NAME = c.CERTIFICATION_NAME,
                }).OrderBy(x => x.CERTIFICATION_NAME).ToList();

            return _lstUsers;
        }
    }
}
