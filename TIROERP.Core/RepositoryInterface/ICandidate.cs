using System.Collections;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface ICandidate
    {
        string Create(Candidate candidate);

        List<IEnumerable> GetMasterData();

        List<Source> GetSourceByAvailingType(int availTypeId);

        List<OtherSource> GetOtherSourceBySource(int sourceId);

        List<EducationSpeciaization> GetSpecializationByEducation(int educationId);

        List<IndustryDesignation> GetDesignationByIndustry(int industryId);

        List<IndustryDesignation> GetDesignationByIndustry(int[] industryId);

        List<Country> GetCountryStateCity(string code);

        bool CheckDuplicate(Candidate candidate);
    }
}
