using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TIROERP.Core.Interface;
using TIROERP.Core.Model;
using TIROERP.Web.App_Start;

namespace Test.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class SpecializationController : Controller
    {
        private readonly ISpecialization _iSpecializationRepository;
        public SpecializationController(ISpecialization iSpecializationRepository)
        {
            _iSpecializationRepository = iSpecializationRepository;
        }
        // GET: Specialization
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            List<Specialization> specializationList = _iSpecializationRepository.GetAllSpecialization();
            return View(specializationList);
        }

        public ActionResult Create()
        {
            GetViewData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Specialization specialization)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iSpecializationRepository.CheckDuplicate(specialization.SPECIALIZATION_TYPE, specialization.EDUCATION_TYPE_ID, null))
                    {
                        _iSpecializationRepository.Create(specialization);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetViewData();
                        ModelState.AddModelError("Duplicate Specialization Type", "Duplicate specialization type is found. Please enter different specialization type");
                        return View("Create", specialization);
                    }
                }
                else
                {
                    GetViewData();
                    return View("Create", specialization);
                }
            }
            catch (Exception ex)
            {
                GetViewData();
                return View("Create", specialization);
            }

        }

        public ActionResult Edit(int id)
        {
            try
            {
                GetViewData();
                var getdetailsbyId = _iSpecializationRepository.GetSpecializationById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                GetViewData();
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(Specialization specialization)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iSpecializationRepository.CheckDuplicate(specialization.SPECIALIZATION_TYPE, specialization.EDUCATION_TYPE_ID, specialization.SPECIALIZATION_ID))
                    {
                        _iSpecializationRepository.Edit(specialization);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        GetViewData();
                        ModelState.AddModelError("Duplicate Specialization Type", "Duplicate specialization type is found. Please enter different specialization type");
                        return View("Edit", specialization);
                    }
                }
                else
                {
                    GetViewData();
                    return View("Edit", specialization);
                }
            }
            catch (Exception ex)
            {
                GetViewData();
                return View("Edit", specialization);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iSpecializationRepository.GetSpecializationById(id);
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Specialization specialization)
        {
            try
            {
                _iSpecializationRepository.Delete(specialization);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(specialization);
            }

        }

        private void GetViewData()
        {
            var educationList = _iSpecializationRepository.GetAllEducationList()
                                .Select(x => new SelectListItem
                                {
                                    Value = x.EDUCATION_TYPE_ID.ToString(),
                                    Text = x.EDUCATION_TYPE
                                }).ToList();

            ViewData["EducationList"] = new SelectList(educationList, "Value", "Text");
        }
    }
}