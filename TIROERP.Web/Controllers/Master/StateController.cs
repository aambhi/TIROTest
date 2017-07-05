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
    public class StateController : Controller
    {
        IState _iStateRepository;
        public StateController(IState iStateRepository)
        {
            _iStateRepository = iStateRepository;
        }
        // GET: State
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iStateRepository.GetAllState();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            GetMasterData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iStateRepository.CheckDuplicate(state.STATE_CODE, null))
                    {
                        _iStateRepository.Create(state);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetMasterData();
                        ModelState.AddModelError("Duplicate State Code", "Duplicate state code is found. Please enter different state Code");
                        return View("Create", state);
                    }
                }
                else
                {
                    GetMasterData();
                    return View("Create", state);
                }
            }
            catch (Exception ex)
            {
                GetMasterData();
                return View("Create", state);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            try
            {
                var getdetailsbyId = _iStateRepository.GetDetailById(Convert.ToInt32(id));
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(State state)
        {
            try
            {
                _iStateRepository.Delete(state);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(state);
            }

        }

        public ActionResult Edit(string id)
        {
            try
            {
                GetMasterData();
                var getdetailsbyId = _iStateRepository.GetDetailById(Convert.ToInt32(id));
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                GetMasterData();
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(State state)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iStateRepository.CheckDuplicate(state.STATE_NAME, state.StateId))
                    {
                        _iStateRepository.Edit(state);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetMasterData();
                        ModelState.AddModelError("Duplicate State Code", "Duplicate state code is found. Please enter different state Code");
                        return View("Edit", state);
                    }
                }
                else
                {
                    GetMasterData();
                    return View("Edit", state);
                }
            }
            catch (Exception)
            {
                GetMasterData();
                return View("Edit", state);
            }
        }

        private void GetMasterData()
        {
            IEnumerable<SelectListItem> lstCountryres = _iStateRepository.GetAllCountry()
                                .Select(x => new SelectListItem
                                {
                                    Value = Convert.ToString(x.CountryId),
                                    Text = x.COUNTRY_NAME
                                }); ;

            ViewData["GetCountry"] = new SelectList(lstCountryres, "Value", "Text");
        }
    }
}