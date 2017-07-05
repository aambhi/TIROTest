using System;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{

    [Authenticate]
    [ErrorFilter]
    public class CompanyController : Controller
    {
        private readonly ICompany _iCompanyRepository;

        public CompanyController(ICompany iCompanyRepository)
        {
            _iCompanyRepository = iCompanyRepository;
        }
        // GET: Company
        public ActionResult Index(string successMsg = null)
        {
            ViewBag.SuccessMsg = successMsg;
            var _lstUsers = _iCompanyRepository.GetAllCompanies();
            return View(_lstUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyMaster company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCompanyRepository.CheckDuplicate(company.COMPANY_NAME, null))
                    {
                        _iCompanyRepository.Create(company);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Company Name", "Duplicate company name is found. Please enter different Company Name");
                        return View("Create", company);
                    }
                }
                else
                {
                    return View("Create", company);
                }
            }
            catch (Exception ex)
            {
                return View("Create", company);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var getdetailsbyId = _iCompanyRepository.GetDetailById(id);
                return View(getdetailsbyId);

            }
            catch (Exception)
            {
                return View("Delete");
            }

        }

        [HttpPost]
        public ActionResult Delete(CompanyMaster company)
        {
            try
            {
                _iCompanyRepository.Delete(company);
                return RedirectToAction("Index", new { successMsg = "Success" });
            }
            catch (Exception)
            {
                return View(company);
            }

        }

        public ActionResult Edit(int id)
        {
            try
            {
                var getdetailsbyId = _iCompanyRepository.GetDetailById(id);
                return View(getdetailsbyId);
            }
            catch (Exception)
            {
                return View("Edit");
            }

        }

        [HttpPost]
        public ActionResult Edit(CompanyMaster company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_iCompanyRepository.CheckDuplicate(company.COMPANY_NAME, company.COMPANY_ID))
                    {
                        _iCompanyRepository.Edit(company);
                        return RedirectToAction("Index", new { successMsg = "Success" });
                    }
                    else
                    {
                        ModelState.AddModelError("Duplicate Company Name", "Duplicate company name is found. Please enter different Company Name");
                        return View("Edit", company);
                    }
                }
                else
                {
                    return View("Edit", company);
                }
            }
            catch (Exception)
            {
                return View("Edit", company);
            }
        }
    }
}