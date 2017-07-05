using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;


namespace TIROERP.Infrastructure.Repository
{

    public class MenuRepository : IMenu
    {
        ArbabTravelsERPEntities _entities;

        public List<MenuResult> GetMenu(MenuModel menuModel)
        {
            _entities = new ArbabTravelsERPEntities();
            var menuResult = _entities.PROC_GET_LAYOUT_MENU(menuModel.USER_TYPE_ID)
               .Select(c => new MenuResult
               {
                   CONTROLLER_NAME = c.CONTROLLER_NAME,
                   IS_PARENT = c.IS_PARENT,
                   MENU_ID = c.MENU_ID,
                   MENU_NAME = c.MENU_NAME,
                   MENU_TITLE = c.MENU_TITLE,
                   MENU_URL = c.MENU_URL,
                   PAGE_NAME = c.PAGE_NAME,
                   //PAGE_URL=c.PAGE_URL,
                   PARENT_MENU_ID = c.PARENT_MENU_ID,
                   MENU_ICON = c.MENU_ICON,
                   // PARENT_MENU_NAME=c.PARENT_MENU_NAME,
                   REMARK = c.REMARK
               }).ToList();

            //"Get_PARENT_MENU" : "Get_MENU"


            return menuResult;
        }

        public List<UserType> GetUserType()
        {
            _entities = new ArbabTravelsERPEntities();
            List<UserType> userTypeObj = (List<UserType>)
                (from x in _entities.TBL_USER_PERSONAL_DETAILS
                 join y in _entities.TBL_USER_DETAILS on x.REGISTRATION_NO equals y.REGISTRATION_NO
                 where y.USER_TYPE_ID == 2
                 select new UserType
                 {
                     USER_TYPE_ID = x.REGISTRATION_NO,
                     USER_TYPE = (string.IsNullOrEmpty(x.FIRST_NAME) ? "" : x.FIRST_NAME)
                     + " " + (string.IsNullOrEmpty(x.MIDDLE_NAME) ? "" : x.MIDDLE_NAME) + " "
                     + (string.IsNullOrEmpty(x.LAST_NAME) ? "" : x.LAST_NAME)
                 }).ToList();

            return userTypeObj;
        }

        public List<MenuResult> GetMenuByUserTypeId(string userTypeId)
        {
            _entities = new ArbabTravelsERPEntities();

            List<MenuResult> userMenuResult = _entities.PROC_GET_MENU_BY_SELECTED_USER(userTypeId)
                                            .Select(c => new MenuResult
                                            {
                                                MENU_ID = c.MENU_ID,
                                                MENU_NAME = c.MENU_NAME,
                                                MENU_TITLE = c.MENU_TITLE,
                                                MENU_URL = c.MENU_URL,
                                                IS_PARENT = c.IS_PARENT,
                                                USER_TYPE_MENU_ID = c.USER_TYPE_MENU_ID
                                            }).ToList();

            return userMenuResult;
        }

        public void MenuInsertionByUserType(MenuModel menuModel, string Action)
        {
            _entities.PROC_ADD_DELETE_MENU_FOR_USERTYPE(menuModel.MENU_ID, menuModel.USER_TYPE_ID, menuModel.CREATED_BY, (Action == "Add") ? "ADD_MENU_FOR_USERTYPE" : "DEL_MENU_FOR_USERTYPE");

        }
    }
}
