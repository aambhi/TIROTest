using System;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class DesignationController : Controller
    {
        IDesignation _iDesignationRepository;

        public DesignationController(IDesignation iDesignationRepository)
        {
            this._iDesignationRepository = iDesignationRepository;
        }

        // GET: Country
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iDesignationRepository.GetAllDesignation();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            GetAllIndustry();
            return View();
        }

        private void GetAllIndustry()
        {
            var lstindustry = from industry in _iDesignationRepository.GetAllIndustry().AsEnumerable<Industry>()
                              select new
                              {
                                  Value = industry.INDUSTRY_ID,
                                  Text = industry.INDUSTRY_TYPE,
                              };

            ViewData["IndustryList"] = new SelectList(lstindustry, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Create(Designation designation)
        {
            if (ModelState.IsValid)
            {
                if (!_iDesignationRepository.CheckDuplicate(designation.DESIGNATION_NAME, Convert.ToInt32(designation.INDUSTRY_ID), null))
                {
                    _iDesignationRepository.Create(designation);
                    return RedirectToAction("Index", new { successMsg = "Success" });
                }
                else
                {
                    GetAllIndustry();
                    ModelState.AddModelError("Duplicate Designation", "Duplicate Designation is found. Please enter different Designation");
                    return View("Create", designation);
                }
            }
            else
            {
                GetAllIndustry();
                return View("Create", designation);
            }

        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iDesignationRepository.GetDetailById(id);
                GetIndustry(Convert.ToInt16(getdetailsbyId.INDUSTRY_ID));
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        private void GetIndustry(int industryId)
        {
            var lstindustry = from industry in _iDesignationRepository.GetAllIndustry().AsEnumerable<Industry>()
                              select new
                              {
                                  Value = Convert.ToString(industry.INDUSTRY_ID),
                                  Text = industry.INDUSTRY_TYPE,
                              };

            ViewBag.IndustryList = new SelectList(lstindustry, "Value", "Text", industryId);
        }

        [HttpPost]
        public ActionResult Edit(Designation designation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iDesignationRepository.CheckDuplicate(designation.DESIGNATION_NAME, Convert.ToInt32(designation.INDUSTRY_ID), designation.DESIGNATION_ID))
                    {
                        _iDesignationRepository.Edit(designation);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetIndustry(Convert.ToInt16(designation.INDUSTRY_ID));
                        ModelState.AddModelError("Duplicate Designation", "Duplicate designation code is found. Please enter different Designation");
                        return View("Edit", designation);
                    }
                }
                else
                {
                    GetIndustry(Convert.ToInt16(designation.INDUSTRY_ID));
                    return View("Edit", designation);
                }
            }
            catch (Exception)
            {
                GetIndustry(Convert.ToInt16(designation.INDUSTRY_ID));
                return View("Edit", designation);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iDesignationRepository.GetDetailById(id);
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Designation designation)
        {
            try
            {
                _iDesignationRepository.Delete(designation);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(designation);
            }

        }
    }
}