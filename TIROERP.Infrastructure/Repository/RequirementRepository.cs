using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class RequirementRepository : IRequirement
    {
        ArbabTravelsERPEntities _entities;

        public List<Specialization> GetSpecilizationByEducationType(int[] educationList)
        {
            _entities = new ArbabTravelsERPEntities();
            var _lstSpecilization = new List<Specialization>();

            _lstSpecilization = _entities.TBL_SPECIALIZATION_MASTER.Where(x => x.IS_ACTIVE == true && educationList.Contains(x.EDUCATION_TYPE_ID)).ToList().
                Select(c => new Specialization
                {
                    SPECIALIZATION_ID = c.SPECIALIZATION_ID,
                    SPECIALIZATION_TYPE = c.SPECIALIZATION_TYPE,
                    IS_ACTIVE = c.IS_ACTIVE
                }).OrderBy(x => x.SPECIALIZATION_ID).ToList();

            return _lstSpecilization;
        }

        public List<IEnumerable> GetMasterData()
        {
            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_REQUIREMENT_MASTER]")
                .With<Allowance>()
                .With<ClientCompany>()
                .With<ContactPerson>()
                .With<Currency>()
                .With<EducationType>()
                .With<Gender>()
                .With<InterviewMode>()
                .With<Language>()
                .With<Religion>()
                .With<RequirementStatus>()
                //.With<Specialization>()
                .With<Industry>()
                .With<Certification>()
                .With<AllowanceType>()
                .Execute();

            return results;
        }

        public int Create(RequirementModel requirementModel)
        {
            _entities = new ArbabTravelsERPEntities();

            string genderCodes = (requirementModel.GENDERS.Length > 0) ? string.Join("|", requirementModel.GENDERS) : string.Empty;
            string specializationIds = (requirementModel.SPECIALIZATION != null && requirementModel.SPECIALIZATION.Length > 0) ? string.Join("|", requirementModel.SPECIALIZATION) : string.Empty;
            string religionIds = (requirementModel.RELIGIONS != null && requirementModel.RELIGIONS.Length > 0) ? string.Join("|", requirementModel.RELIGIONS) : string.Empty;

            string educationIds = (requirementModel.EDUCATION != null && requirementModel.EDUCATION.Length > 0) ? string.Join("|", requirementModel.EDUCATION) : string.Empty;
            string industryIds = (requirementModel.INDUSTRY != null && requirementModel.INDUSTRY.Length > 0) ? string.Join("|", requirementModel.INDUSTRY) : string.Empty;
            string designationIds = (requirementModel.DESIGNATION != null && requirementModel.DESIGNATION.Length > 0) ? string.Join("|", requirementModel.DESIGNATION) : string.Empty;
            string cerificationIds = (requirementModel.CERTIFICATION != null && requirementModel.CERTIFICATION.Length > 0) ? string.Join("|", requirementModel.CERTIFICATION) : string.Empty;


            System.Data.Entity.Core.Objects.ObjectParameter output = new System.Data.Entity.Core.Objects.ObjectParameter("RequirementID", typeof(int));
            _entities.PROC_REQUIREMENT_DETAILS_INSERT(requirementModel.COMPANY_ID, requirementModel.NO_OF_OPENINGS, requirementModel.EXPERIENCE_FROM, requirementModel.EXPERIENCE_TO,
                requirementModel.JOB_DESCRIPTION, genderCodes, requirementModel.AGE_FROM,
                requirementModel.AGE_TO, religionIds, requirementModel.INTERVIEW_MODE_ID,
                specializationIds, requirementModel.POSTING_PLACE, requirementModel.CURRENCY_TYPE_ID, requirementModel.BASIC_SALARY_RANGE_TO,
                requirementModel.BASIC_SALARY_RANGE_FROM, requirementModel.OVERTIME, requirementModel.TRIP_PER_YEAR, requirementModel.CONTACT_PERIOD,
                requirementModel.WORKING_HOURS, requirementModel.LEAVES_PER_YEAR, requirementModel.REMARK, requirementModel.IS_ACTIVE, Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO)
                , requirementModel.CONTACT_PERSON, requirementModel.JOB_TITLE, requirementModel.ALLOWANCE_IDS, requirementModel.LANGUAGE, educationIds, industryIds, designationIds, cerificationIds, output);
            return Convert.ToInt32(output.Value);
        }

        public List<RequirementSearchResult> requirementSearchResult(RequirementSearch requirementSearch)
        {
            _entities = new ArbabTravelsERPEntities();

            var result = _entities.PROC_REQUIREMENT_SEARCH_RESULT(requirementSearch.COMPANY_NAME_ID, requirementSearch.STATUS, requirementSearch.CLIENT_NAME, requirementSearch.JOB_TITLE)
                .Select(c => new RequirementSearchResult
                {
                    CLIENT_NAME = c.CLIENT_NAME,
                    COMPANY_NAME = c.COMPANY_NAME,
                    REQUIREMENT_ID = c.REQUIREMENT_ID,
                    STATUS = c.STATUS,
                    JOB_TITLE = c.JOB_TITLE
                }).ToList();
            return result;
        }

        public List<IEnumerable> GetRequirementDetailsById(int Id)
        {

            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@REQUIREMENT_ID";
            sp.Value = Id;
            sp.SqlDbType = SqlDbType.Int;

            var results = new ArbabTravelsERPEntities()
               .MultipleResults("PROC_REQUIREMENT_SEARCH")
               .With<RequirementSearchViewModel>()
               .With<RequirementAllowance>()
               //.With<CVDetails>()
               .Execute(new object[] { sp });
            return results;
        }

        public RequirementModel EditRequirementDetailsById(int Id)
        {
            //PROC_GET_EDIT_DETAILS_BY_REQUIREMENT_ID


            var result = new List<RequirementModel>();
            _entities = new ArbabTravelsERPEntities();
            result = _entities.PROC_GET_EDIT_DETAILS_BY_REQUIREMENT_ID(Id)
               .Select(c => new RequirementModel
               {
                   REQUIREMENT_ID = c.REQUIREMENT_ID,
                   LANGUAGE = c.LANGUAGE_ID,
                   EDUCATION = (!string.IsNullOrEmpty(c.EDUCATION_TYPE_ID)) ? Array.ConvertAll(c.EDUCATION_TYPE_ID.Split('|'), int.Parse) : null,
                   GENDERS = (!string.IsNullOrEmpty(c.GENDER_CODES)) ? c.GENDER_CODES.Split('|') : null,
                   RELIGIONS = (!string.IsNullOrEmpty(c.RELIGION_ID)) ? Array.ConvertAll(c.RELIGION_ID.Split('|'), int.Parse) : null,
                   DESIGNATION = (!string.IsNullOrEmpty(c.DESIGNATION_ID)) ? Array.ConvertAll(c.DESIGNATION_ID.Split('|'), int.Parse) : null,
                   INDUSTRY = (!string.IsNullOrEmpty(c.INDUSTRY_ID)) ? Array.ConvertAll(c.INDUSTRY_ID.Split('|'), int.Parse) : null,
                   SPECIALIZATION = (!string.IsNullOrEmpty(c.SPECIALIZATION_ID)) ? Array.ConvertAll(c.SPECIALIZATION_ID.Split('|'), int.Parse) : null,
                   CERTIFICATION = (!string.IsNullOrEmpty(c.CERTIFICATION_ID)) ? Array.ConvertAll(c.CERTIFICATION_ID.Split('|'), int.Parse) : null,
                   AGE_FROM = c.AGE_FROM,
                   AGE_TO = c.AGE_TO,
                   BASIC_SALARY_RANGE_FROM = c.BASIC_SALARY_RANGE_FROM,
                   BASIC_SALARY_RANGE_TO = c.BASIC_SALARY_RANGE_TO,
                   COMPANY_ID = c.COMPANY_ID,
                   CONTACT_PERSON = c.CONTACT_PERSON,
                   CONTACT_PERIOD = c.CONTACT_PERIOD,
                   CURRENCY_TYPE_ID = c.CURRENCY_TYPE_ID,
                   EXPERIENCE_FROM = c.EXPERIENCE_FROM,
                   EXPERIENCE_TO = c.EXPERIENCE_TO,
                   INTERVIEW_MODE_ID = c.INTERVIEW_MODE_ID,
                   JOB_DESCRIPTION = c.JOB_DESCRIPTION,
                   JOB_TITLE = c.JOB_TITLE,
                   LEAVES_PER_YEAR = c.LEAVES_PER_YEAR,
                   NO_OF_OPENINGS = c.NO_OF_OPENINGS,
                   OVERTIME = c.OVERTIME,
                   POSTING_PLACE = c.POSTING_PLACE,
                   ALLOWANCE_IDS = c.ALLOWANCE_ID,
                   TRIP_PER_YEAR = c.TRIP_PER_YEAR,
                   WORKING_HOURS = c.WORKING_HOURS,
                   REMARK = c.REMARK,
                   STATUS_ID = c.IS_ACTIVE
               }).ToList();

            //_entities.MultipleResults("PROC_GET_EDIT_DETAILS_BY_REQUIREMENT_ID").Execute(sp).ToList();

            return result.FirstOrDefault();
        }

        public bool Update(RequirementModel requirementModel)
        {
            _entities = new ArbabTravelsERPEntities();

            string genderCodes = (requirementModel.GENDERS.Length > 0) ? string.Join("|", requirementModel.GENDERS) : string.Empty;
            string specializationIds = (requirementModel.SPECIALIZATION != null && requirementModel.SPECIALIZATION.Length > 0) ? string.Join("|", requirementModel.SPECIALIZATION) : string.Empty;
            string religionIds = (requirementModel.RELIGIONS != null && requirementModel.RELIGIONS.Length > 0) ? string.Join("|", requirementModel.RELIGIONS) : string.Empty;

            string educationIds = (requirementModel.EDUCATION != null && requirementModel.EDUCATION.Length > 0) ? string.Join("|", requirementModel.EDUCATION) : string.Empty;
            string industryIds = (requirementModel.INDUSTRY != null && requirementModel.INDUSTRY.Length > 0) ? string.Join("|", requirementModel.INDUSTRY) : string.Empty;
            string designationIds = (requirementModel.DESIGNATION != null && requirementModel.DESIGNATION.Length > 0) ? string.Join("|", requirementModel.DESIGNATION) : string.Empty;
            string cerificationIds = (requirementModel.CERTIFICATION != null && requirementModel.CERTIFICATION.Length > 0) ? string.Join("|", requirementModel.CERTIFICATION) : string.Empty;

            int resCount = _entities.PROC_REQUIREMENT_DETAILS_UPDATE(requirementModel.REQUIREMENT_ID, requirementModel.COMPANY_ID, requirementModel.NO_OF_OPENINGS, requirementModel.EXPERIENCE_FROM, requirementModel.EXPERIENCE_TO,
                 requirementModel.JOB_DESCRIPTION, genderCodes, requirementModel.AGE_FROM,
                 requirementModel.AGE_TO, religionIds, requirementModel.INTERVIEW_MODE_ID,
                 specializationIds, requirementModel.POSTING_PLACE, requirementModel.CURRENCY_TYPE_ID, requirementModel.BASIC_SALARY_RANGE_TO,
                 requirementModel.BASIC_SALARY_RANGE_FROM, requirementModel.OVERTIME, requirementModel.TRIP_PER_YEAR, requirementModel.CONTACT_PERIOD,
                 requirementModel.WORKING_HOURS, requirementModel.LEAVES_PER_YEAR, requirementModel.REMARK, requirementModel.STATUS_ID, Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO)
                 , requirementModel.CONTACT_PERSON, requirementModel.JOB_TITLE, requirementModel.ALLOWANCE_IDS,
                 requirementModel.LANGUAGE, educationIds, industryIds, designationIds, cerificationIds);
            return (resCount > 0) ? true : false;
        }

        public List<AgentEmail> GetAgentEmailList()
        {
            _entities = new ArbabTravelsERPEntities();
            var agentList = new List<AgentEmail>();
            agentList = _entities.PROC_GET_AGENT_NAME().Select(c => new AgentEmail
            {
                AGENT_NAME = c.AGENT_NAME,
                REGISTRATION_NO = c.REGISTRATION_NO,
                USER_EMAIL = c.USER_EMAIL
            }).ToList();
            return agentList;
        }

        public List<RequirementSearchViewModel> GetRequirementDetailList(string requirementIds)
        {
            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@REQUIREMENT_IDS";
            sp.Value = requirementIds;
            sp.SqlDbType = SqlDbType.VarChar;

            _entities = new ArbabTravelsERPEntities();
            var requirementDetailList = new List<RequirementSearchViewModel>();
            var results = new ArbabTravelsERPEntities()
              .MultipleResults("PROC_REQUIREMENT_DETAILS_LIST")
              .With<RequirementSearchViewModel>()
              .Execute(new object[] { sp });
            return (List<RequirementSearchViewModel>)results[0];
        }

        public bool CheckDuplicate(string companyId, string contactPerson, string jobTitle)
        {
            _entities = new ArbabTravelsERPEntities();

            var result = _entities.PROC_CHECK_DUPLICATEREQUIREMENT(companyId, contactPerson, jobTitle).ToList();

            if (result[0] != null)
                return false;

            return true;
        }
    }
}
