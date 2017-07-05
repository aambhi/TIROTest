using System;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IVisaEndorsement
    {
        void Create(VisaEndorsement visaEndorsement);
        string GetCandidateName(int userRequirementId);
        List<SubmissionStatus> GetSubmissionStatusDetails();
        List<Passport_Details> GetPassportDetails();

        void Update(VisaEndorsement visaDetails);
        List<VisaEndorsement> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}