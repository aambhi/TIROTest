using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IMenu
    {
        List<MenuResult> GetMenu(MenuModel menuModel);
        List<UserType> GetUserType();
        List<MenuResult> GetMenuByUserTypeId(string userTypeId);
        void MenuInsertionByUserType(MenuModel menuModel, string Action);
    }
}
