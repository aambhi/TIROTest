using System;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class IndustryController : Controller
    {
        IIndustry _iIndustryRepository;

        public IndustryController(IIndustry iIndustryRepository)
        {
            this._iIndustryRepository = iIndustryRepository;
        }

        // GET: Country
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iIndustryRepository.GetAllIndustry();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Industry industry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iIndustryRepository.CheckDuplicate(industry.INDUSTRY_TYPE, null))
                    {
                        _iIndustryRepository.Create(industry);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Industry", "Duplicate Industry is found. Please enter different Industry");
                        return View("Create", industry);
                    }
                }
                else
                {
                    return View("Create", industry);
                }
            }
            catch (Exception ex)
            {
                return View("Create", industry);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iIndustryRepository.GetDetailById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(Industry industry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iIndustryRepository.CheckDuplicate(industry.INDUSTRY_TYPE, industry.INDUSTRY_ID))
                    {
                        _iIndustryRepository.Edit(industry);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Industry", "Duplicate Industry is found. Please enter different Industry");
                        return View("Edit", industry);
                    }
                }
                else
                {
                    return View("Edit", industry);
                }
            }
            catch (Exception)
            {
                return View("Edit", industry);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iIndustryRepository.GetDetailById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Industry industry)
        {
            try
            {
                _iIndustryRepository.Delete(industry);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(industry);
            }

        }
    }
}