using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers
{
    [Authenticate]
    [ErrorFilter]
    public class DashboardController : Controller
    {
        private readonly IDashboard _iDashboardRepository;

        public DashboardController(IDashboard iDashboardRepository)
        {
            _iDashboardRepository = iDashboardRepository;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.CountResultSet = _iDashboardRepository.GetDashboardDataCount();
            return View();
        }

        public ActionResult CandidateIndex()
        {
            List<Candidate> candidateresult = _iDashboardRepository.GetAllCandidates();
            return View(candidateresult);
        }

        public ActionResult GetAllRequirements()
        {
            List<RequirementSearchResult> allRequirements = new List<RequirementSearchResult>();
            allRequirements = _iDashboardRepository.GetAllRequirements();
            return View(allRequirements);
        }
    }
}