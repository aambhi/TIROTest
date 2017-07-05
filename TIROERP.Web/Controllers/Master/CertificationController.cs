using System;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Master
{

    [Authenticate]
    [ErrorFilter]
    public class CertificationController : Controller
    {
        ICertification _iCertificationRepository;

        public CertificationController(ICertification iCertificationRepository)
        {
            this._iCertificationRepository = iCertificationRepository;
        }

        // GET: Country
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iCertificationRepository.GetAllCertification();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Certification certification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCertificationRepository.CheckDuplicate(certification.CERTIFICATION_NAME, null))
                    {
                        _iCertificationRepository.Create(certification);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Certification", "Duplicate Certification is found. Please enter different Certification");
                        return View("Create", certification);
                    }
                }
                else
                {
                    return View("Create", certification);
                }
            }
            catch (Exception ex)
            {
                return View("Create", certification);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iCertificationRepository.GetDetailById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(Certification certification)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCertificationRepository.CheckDuplicate(certification.CERTIFICATION_NAME, certification.CERTIFICATION_ID))
                    {
                        _iCertificationRepository.Edit(certification);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Certification", "Duplicate Certification found. Please enter different Certification");
                        return View("Edit", certification);
                    }
                }
                else
                {
                    return View("Edit", certification);
                }
            }
            catch (Exception)
            {
                return View("Edit", certification);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iCertificationRepository.GetDetailById(id);
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(Certification certification)
        {
            try
            {
                _iCertificationRepository.Delete(certification);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(certification);
            }

        }
    }
}