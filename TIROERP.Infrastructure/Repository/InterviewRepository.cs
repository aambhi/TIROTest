using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;

namespace TIROERP.Infrastructure.Repository
{
    public class InterviewRepository : IInterview
    {
        ArbabTravelsERPEntities _entities;
        public void Create(Interview interview)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_INTERVIEW tbl_interview = new TBL_INTERVIEW();

            try
            {
                tbl_interview.RequirementID = interview.REQUIREMENT_ID;
                //tbl_interview.Company_ID = interview.Company_ID;
                tbl_interview.InterviewModeId = interview.InterviewModeId;
                tbl_interview.CreatedDate = DateTime.Now;
                tbl_interview.InterviewDate = interview.InterviewDate;
                tbl_interview.InterviewExpenses = interview.InterviewExpenses;
                tbl_interview.InterviewVenue = interview.InterviewVenue;
                tbl_interview.InterviewRemark = interview.InterviewRemark;
                tbl_interview.CreatedBy = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_interview.IsSelected = false;

                _entities.TBL_INTERVIEW.Add(tbl_interview);
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Advertisement_Requirements> GetAllRequirements()
        {
            List<Advertisement_Requirements> advert_requirement = new List<Advertisement_Requirements>();

            _entities = new ArbabTravelsERPEntities();

            advert_requirement = _entities.PROC_GET_REQUIREMENT(null).Select(x => new Advertisement_Requirements
            {
                RequirementName = x.REQUIREMENT,
                REQUIREMENT_ID = x.REQUIREMENT_ID
            }).ToList();

            return advert_requirement;

        }

        public List<Interview_Mode_Master> GetModeOfInterview()
        {
            _entities = new ArbabTravelsERPEntities();
            List<Interview_Mode_Master> interview_modes = new List<Interview_Mode_Master>();

            interview_modes = _entities.TBL_INTERVIEW_MODE_MASTER.Select(x => new Interview_Mode_Master
            {
                INTERVIEW_MODE = x.INTERVIEW_MODE,
                INTERVIEW_MODE_ID = x.INTERVIEW_MODE_ID
            }).ToList();

            return interview_modes;

        }
    }
}
