using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class LoginRepository : IUserLogin
    {
        ArbabTravelsERPEntities _entities;
        public UserLoginResult ValidateUserLogin(UserLogin userlogin)
        {
            _entities = new ArbabTravelsERPEntities();
            var USER_NAME = new SqlParameter { ParameterName = "USER_NAME", Value = userlogin.User_Code };
            var USER_PASSWORD = new SqlParameter { ParameterName = "USER_PASSWORD", Value = userlogin.Password };

            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_USER_LOGIN_DETAILS]")
                .With<UserLoginResult>()
                .With<int>()
                .Execute(USER_NAME, USER_PASSWORD);

            var _details = (List<UserLoginResult>)results[0];
            var taskcount = (List<int>)results[1];

            var logindetails = _details.Select(x => new UserLoginResult
            {
                NAME = x.NAME,
                REGISTRATION_NO = x.REGISTRATION_NO,
                LOGIN_PASSWORD = x.LOGIN_PASSWORD,
                USER_IMAGE_PATH = x.USER_IMAGE_PATH,
                USER_TYPE_ID = x.USER_TYPE_ID,
                OPEN_TASK = taskcount[0]
            }).FirstOrDefault();

            return logindetails;
        }
    }
}
