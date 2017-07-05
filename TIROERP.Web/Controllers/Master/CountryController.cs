using System;
using System.Web.Mvc;
using TIROERP.Core.Interface;
using TIROERP.Core.Model;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{
    [Authenticate]
    [ErrorFilter]

    public class CountryController : Controller
    {
        ICountry _iCountryRepository;

        public CountryController(ICountry iCountryRepository)
        {
            this._iCountryRepository = iCountryRepository;
        }

        // GET: Country
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iCountryRepository.GetAllCountry();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCountryRepository.CheckDuplicate(country.COUNTRY_NAME, null))
                    {
                        _iCountryRepository.Create(country);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Country Code", "Duplicate country code is found. Please enter different Country Code");
                        return View("Create", country);
                    }
                }
                else
                {
                    return View("Create", country);
                }
            }
            catch (Exception ex)
            {
                return View("Create", country);
            }
        }

        public ActionResult Edit(string id)
        {
            try
            {
                var getdetailsbyId = _iCountryRepository.GetDetailById(Convert.ToInt32(id));
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCountryRepository.CheckDuplicate(country.COUNTRY_NAME, country.CountryId))
                    {
                        _iCountryRepository.Edit(country);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Country Code", "Duplicate country code is found. Please enter different Country Code");
                        return View("Edit", country);
                    }
                }
                else
                {
                    return View("Edit", country);
                }
            }
            catch (Exception)
            {
                return View("Edit", country);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                var getdetailsbyId = _iCountryRepository.GetDetailById(Convert.ToInt32(id));
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Country country)
        {
            try
            {
                _iCountryRepository.Delete(country);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(country);
            }

        }
    }
}