using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;

namespace TIROERP.Web.Controllers.Process
{
    
    [Authenticate]
    [ErrorFilter]
    public class InterviewController : Controller
    {
        private readonly IInterview _iInterviewRepository;

        public InterviewController(IInterview iInterviewRepository)
        {
            _iInterviewRepository = iInterviewRepository;
        }

        // GET: Interview
        public ActionResult Interview()
        {
            ViewBag.GetRequirement = getRequirements("");
            ViewBag.GetModeOfInterview = getModeOfInterview();
            return View();
        }

        [HttpPost]
        public ActionResult Interview(Interview interview)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iInterviewRepository.Create(interview);
                    ViewBag.GetRequirement = getRequirements("");
                    ViewBag.GetModeOfInterview = getModeOfInterview();
                    ModelState.Clear();
                    TempData["Success"] = "Interview created successfully!";
                    return RedirectToAction("Interview");
                }
                else
                {
                    ViewBag.GetRequirement = getRequirements("");
                    ViewBag.GetModeOfInterview = getModeOfInterview();
                    
                    return View("Interview", interview);
                }
                
            }
            catch (Exception ex)
            {
                return View("Interview",interview);
            }
        }

        private IEnumerable<SelectListItem> getRequirements(string requirementName)
        {
            List<Advertisement_Requirements> requirementListDetails = _iInterviewRepository.GetAllRequirements();

            IEnumerable<SelectListItem> getAllRequirements = requirementListDetails.Where(x => x.RequirementName != requirementName).Select(x => new SelectListItem
            {
                Value = x.REQUIREMENT_ID.ToString(),
                Text = x.RequirementName
            });

            return getAllRequirements;
        }

        private IEnumerable<SelectListItem> getModeOfInterview()
        {
            List<Interview_Mode_Master> modeOfInterviewList = _iInterviewRepository.GetModeOfInterview();

            IEnumerable<SelectListItem> getInterviewModeList = modeOfInterviewList.Select(x => new SelectListItem
            {
                Value = x.INTERVIEW_MODE_ID.ToString(),
                Text = x.INTERVIEW_MODE
            });

            return getInterviewModeList;
        }
    }
}