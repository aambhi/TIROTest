using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class DashboardRepository : IDashboard
    {
        ArbabTravelsERPEntities entities;
        public List<IEnumerable> GetDashboardDataCount()
        {
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "DASHBOARD" };

            entities = new ArbabTravelsERPEntities();
            var results = new ArbabTravelsERPEntities()
                              .MultipleResults("[dbo].[PROC_DASHBOARD]")
                              .With<int>()
                              .With<int>()
                              .With<int>()
                              .With<int>()
                              .Execute(CONDITIONAL_OPERATOR);

            return results;
        }

        public List<Candidate> GetAllCandidates()
        {
            List<Candidate> candidateresult = new List<Candidate>();
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "CANDIDATE" };

            entities = new ArbabTravelsERPEntities();
            var results = new ArbabTravelsERPEntities()
                              .MultipleResults("[dbo].[PROC_DASHBOARD]")
                              .With<Candidate>()
                              .Execute(CONDITIONAL_OPERATOR);
            candidateresult = (List<Candidate>)results[0];
            return candidateresult;
        }

        public List<RequirementSearchResult> GetAllRequirements()
        {
            List<RequirementSearchResult> requirementResult = new List<RequirementSearchResult>();
            var CONDITIONAL_OPERATOR = new SqlParameter { ParameterName = "CONDITIONAL_OPERATOR", Value = "REQUIREMENT" };

            entities = new ArbabTravelsERPEntities();
            var results = new ArbabTravelsERPEntities()
                              .MultipleResults("[dbo].[PROC_DASHBOARD]")
                              .With<RequirementSearchResult>()
                              .Execute(CONDITIONAL_OPERATOR);
            requirementResult = (List<RequirementSearchResult>)results[0];

            return requirementResult;
        }
    }
}
