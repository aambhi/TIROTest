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
    public class ClientRepository : IClient
    {
        ArbabTravelsERPEntities _entities;
        public string Create(Client client)
        {
            _entities = new ArbabTravelsERPEntities();
            List<UDT_USER_DETAILS> lstUserDetails = new List<UDT_USER_DETAILS>();
            UDT_USER_DETAILS _udtuser = new UDT_USER_DETAILS();
            _udtuser.FIRST_NAME = client.FIRST_NAME;
            _udtuser.MIDDLE_NAME = client.MIDDLE_NAME;
            _udtuser.LAST_NAME = client.LAST_NAME;
            _udtuser.GAMCA_NO = client.CIVILIAN_NO;
            _udtuser.REMARK = client.REMARK;
            _udtuser.CONTACT_REMARK = client.CONTACT_REMARK;
            _udtuser.WEBSITE = client.WEBSITE;
            _udtuser.SKYPE = client.SKYPE;
            _udtuser.FILE_PATH = client.FILE_PATH;
            _udtuser.REFERENCE = client.REFERENCE;
            _udtuser.INDUSTRY = string.Join(",", client.INDUSTRY);
            _udtuser.DESIGNATION = string.Join(",", client.DESIGNATION);
            _udtuser.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);

            lstUserDetails.Add(_udtuser);

            var procedure = new PROC_USER_INSERT()
            {
                USER_TYPE_ID = 5,
                UDT_USER_DETAIL = lstUserDetails,
                UDT_USER_ADDRESS = GetLstUserAddress(client),
                UDT_USER_CONTACT = GetLstUserContact(client),
                UDT_USER_EMAIL = GetLstUserEmail(client)
            };

            var regno = _entities.Database.ExecuteStoredProcedure<string>(procedure);
            return Convert.ToString(regno.ToList()[0]);

        }

        private List<UDT_USER_ADDRESS> GetLstUserAddress(Client client)
        {
            List<UDT_USER_ADDRESS> lstUdtUserAddress = new List<UDT_USER_ADDRESS>();

            lstUdtUserAddress = client.LST_USER_ADDRESS.Select(x => new UDT_USER_ADDRESS
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

        private List<UDT_USER_EMAIL> GetLstUserEmail(Client client)
        {
            List<UDT_USER_EMAIL> lstUdtUserEmail = new List<UDT_USER_EMAIL>();

            lstUdtUserEmail = client.LST_USER_EMAIL.Select(x => new UDT_USER_EMAIL
            {
                USER_EMAIL = x.USER_EMAIL
            }).ToList();

            return lstUdtUserEmail;
        }

        private List<UDT_USER_CONTACT> GetLstUserContact(Client client)
        {
            List<UDT_USER_CONTACT> lstUdtUserContact = new List<UDT_USER_CONTACT>();

            lstUdtUserContact = client.LST_USER_CONTACT.Select(x => new UDT_USER_CONTACT
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
                .With<IndustryDesignation>()
                .Execute();

            return results;
        }

        public List<IndustryDesignation> GetDesignationByIndustry(int[] industry)
        {
            _entities = new ArbabTravelsERPEntities();

            var lstdesignation = _entities.TBL_DESIGNATION_MASTER.Where(c => industry.Contains(c.INDUSTRY_ID)).ToList()
                .Select(c => new IndustryDesignation
                {
                    DESIGNATION_ID = c.DESIGNATION_ID,
                    DESIGNATION_NAME = c.DESIGNATION_NAME,
                }).ToList();

            return lstdesignation;
        }
    }
}
