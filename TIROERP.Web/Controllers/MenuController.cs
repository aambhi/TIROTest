using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{
    
    [Authenticate]
    [ErrorFilter]
    public class MenuController : Controller
    {
        IMenu _iMenuRepository;

        public MenuController(IMenu iMenuRepository)
        {
            this._iMenuRepository = iMenuRepository;
        }
        public ActionResult MenuMapping()
        {
            List<UserType> userList = _iMenuRepository.GetUserType();//Bind User Type
            var userListData = userList.Select(c => new SelectListItem
            {
                Text = c.USER_TYPE,
                Value = c.USER_TYPE_ID
            });
            ViewData["GetUserType"] = new SelectList(userListData, "Value", "Text");
            return View();
        }

        public JsonResult GetBindGridForMenu(string SEL_USER_TYPE)
        {
            var menuResult = _iMenuRepository.GetMenuByUserTypeId(SEL_USER_TYPE);
            var resultObj = from s in menuResult
                            select new
                            {
                                Menu_ID = s.MENU_ID,
                                MENU_NAME = s.MENU_NAME,
                                MENU_TITLE = s.MENU_TITLE,
                                MENU_URL = s.PAGE_URL,
                                IS_PARENT = s.IS_PARENT,
                                USER_TYPE_MENU_ID = s.USER_TYPE_MENU_ID
                            };

            if (resultObj.ToList().Count > 0)
                return Json(resultObj, JsonRequestBehavior.AllowGet);
            else
                return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MenuMapping(FormCollection FM)
        {
            List<UserType> userList = _iMenuRepository.GetUserType();//Bind User Type
            var userListData = userList.Select(c => new SelectListItem
            {
                Text = c.USER_TYPE,
                Value = c.USER_TYPE_ID
            });
            ViewData["GetUserType"] = new SelectList(userListData, "Value", "Text");

            String user_type_id = Request.Form["USER_TYPE_ID"];
            if (!string.IsNullOrEmpty(user_type_id))
            {
                var hdnrowcount = Request.Form["hdnrowcount"];
                string Created_By = ((UserLoginResult)(Session["UserDetails"])).REGISTRATION_NO;
                MenuModel menuModel = new MenuModel();

                for (int i = 0; i <= Convert.ToInt32(hdnrowcount); i++)
                {
                    int Menu_ID = Convert.ToInt32(Request.Form["hdnMenu_ID" + i]);
                    var menuselected = Request.Form["chksel" + i];
                    menuModel.MENU_ID = Menu_ID;
                    menuModel.USER_TYPE_ID = user_type_id;
                    menuModel.CREATED_BY = Created_By;
                    if (menuselected == "on")
                        _iMenuRepository.MenuInsertionByUserType(menuModel, "Add");
                    else
                        _iMenuRepository.MenuInsertionByUserType(menuModel, "Del");
                }

                ViewBag.Success = "Menu assigned to selected user type successfully";
            }
            else
            {
                ViewBag.Error = "Please select mandatory fields.";
            }

            return View();
        }

    }
}
