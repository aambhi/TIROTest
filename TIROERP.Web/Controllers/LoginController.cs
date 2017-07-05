using System;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;

namespace ArbabTravelsERP.Controllers
{
    public class LoginController : Controller
    {
        IUserLogin _iLoginRepository;

        public LoginController(IUserLogin iLoginRepository)
        {
            this._iLoginRepository = iLoginRepository;
        }
        public ActionResult Index()
        {
            UserLogin objLogin = new UserLogin();
            return View(objLogin);//
        }

        [HttpPost]
        public ActionResult Index(UserLogin objLogin, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string varpwd = objLogin.Password;
                UserLoginResult loginDetails = _iLoginRepository.ValidateUserLogin(objLogin);
                if (loginDetails != null)
                {
                    if (loginDetails.LOGIN_PASSWORD.Equals(objLogin.Password))
                    {
                        if (string.IsNullOrEmpty(loginDetails.USER_IMAGE_PATH))
                            loginDetails.USER_IMAGE_PATH = Convert.ToString(ConfigurationManager.AppSettings["CandidateUploadedFiles"] + "no_img.png");
                        else
                            loginDetails.USER_IMAGE_PATH = Convert.ToString(ConfigurationManager.AppSettings["CandidateUploadedFiles"] + loginDetails.USER_IMAGE_PATH);

                        Session["UserDetails"] = loginDetails;
                        return RedirectToAction("Index", "DashBoard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(objLogin);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                    return View(objLogin);
                }
            }
            else
            {
                return View(objLogin);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}