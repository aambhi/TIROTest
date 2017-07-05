using EntityFrameworkExtras.EF6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.DBModel;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class DoctorRepository : IDoctor
    {
        ArbabTravelsERPEntities _entities;
        public string Create(Doctor doctor)
        {
            _entities = new ArbabTravelsERPEntities();
            List<UDT_USER_DETAILS> lstUserDetails = new List<UDT_USER_DETAILS>();
            UDT_USER_DETAILS _udtuser = new UDT_USER_DETAILS();
            _udtuser.FIRST_NAME = doctor.FIRST_NAME;
            _udtuser.MIDDLE_NAME = doctor.MIDDLE_NAME;
            _udtuser.LAST_NAME = doctor.LAST_NAME;
            _udtuser.GAMCA_NO = doctor.GAMCA_NO;
            _udtuser.REMARK = doctor.REMARK;
            _udtuser.CONTACT_REMARK = doctor.CONTACT_REMARK;
            _udtuser.WEBSITE = doctor.WEBSITE;
            _udtuser.SKYPE = doctor.SKYPE;
            _udtuser.FILE_PATH = doctor.FILE_PATH;
            _udtuser.REGISTRATION_NO = "reg1";
            _udtuser.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);

            lstUserDetails.Add(_udtuser);

            var procedure = new PROC_USER_INSERT()
            {
                USER_TYPE_ID = 4,
                UDT_USER_DETAIL = lstUserDetails,
                UDT_USER_ADDRESS = GetLstUserAddress(doctor),
                UDT_USER_CONTACT = GetLstUserContact(doctor),
                UDT_USER_EMAIL = GetLstUserEmail(doctor)
            };

            var regno = _entities.Database.ExecuteStoredProcedure<string>(procedure);
            return Convert.ToString(regno.ToList()[0]);

        }

        private List<UDT_USER_ADDRESS> GetLstUserAddress(Doctor doctor)
        {
            List<UDT_USER_ADDRESS> lstUdtUserAddress = new List<UDT_USER_ADDRESS>();

            lstUdtUserAddress = doctor.LST_USER_ADDRESS.Select(x => new UDT_USER_ADDRESS
            {
                ADDRESS = x.ADDRESS,
                ADDRESS_TYPE_ID = x.ADDRESS_TYPE_ID,
                CITY_CODE = x.CITY_CODE,
                CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO),
                USER_PINCODE = x.USER_PINCODE,
                USER_VILLAGE = x.USER_VILLAGE
            }).ToList();

            return lstUdtUserAddress;
        }

        private List<UDT_USER_EMAIL> GetLstUserEmail(Doctor doctor)
        {
            List<UDT_USER_EMAIL> lstUdtUserEmail = new List<UDT_USER_EMAIL>();

            lstUdtUserEmail = doctor.LST_USER_EMAIL.Select(x => new UDT_USER_EMAIL
            {
                USER_EMAIL = x.USER_EMAIL
            }).ToList();

            return lstUdtUserEmail;
        }

        private List<UDT_USER_CONTACT> GetLstUserContact(Doctor doctor)
        {
            List<UDT_USER_CONTACT> lstUdtUserContact = new List<UDT_USER_CONTACT>();

            lstUdtUserContact = doctor.LST_USER_CONTACT.Select(x => new UDT_USER_CONTACT
            {
                CONTACT_NO = x.CONTACT_NO,
                CONTACT_TYPE_ID = Convert.ToInt16(x.CONTACT_TYPE_ID),
                CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO)

            }).ToList();

            return lstUdtUserContact;
        }

        public List<IEnumerable> GetMasterData()
        {
            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_PEOPLE_MASTER]")
                .With<Country>()
                .With<ContactType>()
                .Execute();
            
            return results;
        }
    }
}
