using System.Collections;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IRequirement
    {
        List<IEnumerable> GetMasterData();
        List<Specialization> GetSpecilizationByEducationType(int[] educationList);
        int Create(RequirementModel requirementModel);
        List<RequirementSearchResult> requirementSearchResult(RequirementSearch requirementSearch);
        List<IEnumerable> GetRequirementDetailsById(int Id);
        RequirementModel EditRequirementDetailsById(int Id);
        bool Update(RequirementModel requirementModel);
        List<AgentEmail> GetAgentEmailList();
        List<RequirementSearchViewModel> GetRequirementDetailList(string requirementIds);
        bool CheckDuplicate(string companyId, string contactPerson, string jobTitle);
    }
}
