using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{

    [Authenticate]
    [ErrorFilter]
    public class CityController : Controller
    {
        ICity _iCityRepository;

        public CityController(ICity iCityRepository)
        {
            _iCityRepository = iCityRepository;
        }
        // GET: City
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iCityRepository.GetAllCities();
            return View(_lstUsers);
        }
        public ActionResult Create()
        {
            GetMasterData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCityRepository.CheckDuplicate(city.CITY_NAME, null))
                    {
                        _iCityRepository.Create(city);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate City Code", "Duplicate city code is found. Please enter different City Code");
                        GetMasterData();
                        return View("Create", city);
                    }
                }
                else
                {
                    GetMasterData();
                    return View("Create", city);
                }
            }
            catch (Exception ex)
            {
                GetMasterData();
                return View("Create", city);
            }
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                var getdetailsbyId = _iCityRepository.GetDetailById(Convert.ToInt32(id));
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(City city)
        {
            try
            {
                _iCityRepository.Delete(city);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(city);
            }

        }

        public ActionResult Edit(string id)
        {
            try
            {
                var getdetailsbyId = _iCityRepository.GetDetailById(Convert.ToInt32(id));
                GetMasterData();
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                GetMasterData();
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCityRepository.CheckDuplicate(city.CITY_NAME, city.CityId))
                    {
                        _iCityRepository.Edit(city);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetMasterData();
                        ModelState.AddModelError("Duplicate City Code", "Duplicate city code is found. Please enter different City Code");
                        return View("Edit", city);
                    }
                }
                else
                {
                    GetMasterData();
                    return View("Edit", city);
                }
            }
            catch (Exception)
            {
                GetMasterData();
                return View("Edit", city);
            }
        }
        private void GetMasterData()
        {
            IEnumerable<SelectListItem> lstState = _iCityRepository.GetAllStates()
                                .Select(x => new SelectListItem
                                {
                                    Value = Convert.ToString(x.StateId),
                                    Text = x.STATE_NAME
                                }); ;

            ViewData["GetStates"] = new SelectList(lstState, "Value", "Text");
        }

    }
}