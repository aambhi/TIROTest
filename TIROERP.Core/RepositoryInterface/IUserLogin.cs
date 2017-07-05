using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IUserLogin
    {
        UserLoginResult ValidateUserLogin(UserLogin userlogin);
    }
}
