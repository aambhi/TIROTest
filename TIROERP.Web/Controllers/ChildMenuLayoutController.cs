using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using System.Data.Entity.Core.Objects;
using TIROERP.Web.App_Start;

namespace LMS.Controllers
{
    
    [Authenticate]
    [ErrorFilter]
    public class ChildMenuLayoutController : Controller
    {
        IMenu _iMenuRepository;

        public ChildMenuLayoutController(IMenu iMenuRepository)
        {
            this._iMenuRepository = iMenuRepository;
        }

        [ChildActionOnly]
        public ActionResult ChildMenuLayout()
        {
            try
            {
                if (Session["Layout_Menu"] == null)
                {
                    var s = Convert.ToString(((UserLoginResult)Session["UserDetails"]).USER_TYPE_ID);
                    string USER_TYPE = ((UserLoginResult)Session["UserDetails"]).REGISTRATION_NO;
                    MenuModel objMenuModel = new MenuModel();
                    objMenuModel.USER_TYPE_ID = USER_TYPE;
                    objMenuModel.CONDITIONAL_OPERATOR = "Layout_Menu";
                    List<MenuResult> objMenuResult = _iMenuRepository.GetMenu(objMenuModel);

                    Session["Layout_Menu"] = objMenuResult;
                }
                return PartialView();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
