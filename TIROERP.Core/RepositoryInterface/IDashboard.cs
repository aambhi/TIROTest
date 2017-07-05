using System.Collections;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IDashboard
    {
        List<IEnumerable> GetDashboardDataCount();
        List<Candidate> GetAllCandidates();
        List<RequirementSearchResult> GetAllRequirements();
    }
}
