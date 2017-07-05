using System;
using System.Web.Mvc;
using TIROERP.Core.Interface;
using TIROERP.Core.Model;
using TIROERP.Web.App_Start;

namespace Test.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class EducationController : Controller
    {
        private readonly IEducation _iEducationRepository;
        public EducationController(IEducation iEducationRepository)
        {
            _iEducationRepository = iEducationRepository;
        }
        // GET: Education
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iEducationRepository.GetAllEducationList();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EducationType eduType)
        {
            if (ModelState.IsValid)
            {
                if (!_iEducationRepository.CheckDuplicate(eduType.EDUCATION_TYPE, null))
                {
                    _iEducationRepository.Create(eduType);
                    return RedirectToAction("Index", new { successMsg = "Success" });
                }
                else
                {
                    ModelState.AddModelError("Duplicate Education Type", "Duplicate education type is found. Please enter different Education Type");
                    return View("Create", eduType);
                }
            }
            else
            {
                return View(eduType);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iEducationRepository.GetEducationById(Convert.ToInt32(id));
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }
        }

        [HttpPost]
        public ActionResult Edit(EducationType education)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iEducationRepository.CheckDuplicate(education.EDUCATION_TYPE, education.EDUCATION_TYPE_ID))
                    {
                        _iEducationRepository.Edit(education);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Education Type", "Duplicate education type is found. Please enter different Education Type.");
                        return View("Edit", education);
                    }
                }
                else
                {
                    return View("Edit", education);
                }
            }
            catch (Exception)
            {
                return View("Edit", education);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iEducationRepository.GetEducationById(Convert.ToInt32(id));
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(EducationType education)
        {
            try
            {
                _iEducationRepository.Delete(education);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(education);
            }

        }
    }
}