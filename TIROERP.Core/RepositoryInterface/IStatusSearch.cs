using System.Collections;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IStatusSearch
    {
        List<CandidateSearch> GetCandidateResult(CandidateSearch search);

        List<IEnumerable> GetCandidateDetails(string registrationNo, string conditional_operator);

        List<IEnumerable> GetPeopleDetails(string registrationNo, string conditional_operator);

        List<IEnumerable> GetProcessDetails(int userRequirementId);

        List<IEnumerable> GetMasterData();

        List<IEnumerable> GetPeopleMasterData();

        List<UserEducation> GetUserEducationDetails(string registrationNo);

        List<UserCertification> GetUserCertificationDetails(string registrationNo);

        Candidate UpdateCandidateDetails(Candidate candidate);

        List<UserRequirement> AddUpdateUserRequirement(int userRequirementId, string regno, int requirementid, int candidateStatus, bool status);

        Candidate GetCandidateContactDetails(string registrationNo);

        Candidate GetCandidateDocumentDetails(string registrationNo);

        Candidate GetCandidateExperienceDetails(string registrationNo);

        Candidate GetCandidatePersonalDetails(string registrationNo);

        List<IEnumerable> CandidateResumeDownload(string registrationNo);

        bool DeleteEployee(string registrationNo);

        bool ResetPassword(string registrationNo, string password);

        List<IEnumerable> GetDocument(string passportNo, string registrationNo, string conditional_Operator);
    }
}
