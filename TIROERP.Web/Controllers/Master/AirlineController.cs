using System;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class AirlineController : Controller
    {
        IAirline _iAirlineRepository;

        public AirlineController(IAirline iAirlineRepository)
        {
            this._iAirlineRepository = iAirlineRepository;
        }

        // GET: Country
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iAirlineRepository.GetAllAirline();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Airline airline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iAirlineRepository.CheckDuplicate(airline.AirlinesName, null))
                    {
                        _iAirlineRepository.Create(airline);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Airline", "Duplicate Airline is found. Please enter different Airline");
                        return View("Create", airline);
                    }
                }
                else
                {
                    return View("Create", airline);
                }
            }
            catch (Exception ex)
            {
                return View("Create", airline);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iAirlineRepository.GetDetailById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(Airline airline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iAirlineRepository.CheckDuplicate(airline.AirlinesName, airline.AirlinesId))
                    {
                        _iAirlineRepository.Edit(airline);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Airline", "Duplicate airline code is found. Please enter different Airline");
                        return View("Edit", airline);
                    }
                }
                else
                {
                    return View("Edit", airline);
                }
            }
            catch (Exception)
            {
                return View("Edit", airline);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iAirlineRepository.GetDetailById(id);
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Airline airline)
        {
            try
            {
                _iAirlineRepository.Delete(airline);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(airline);
            }

        }
    }
}