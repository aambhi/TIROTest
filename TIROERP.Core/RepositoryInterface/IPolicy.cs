using System;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IPolicy
    {
        void Create(Policy policyObj);
        List<Passport_Details> GetPassportNumbers();
        string GetCandidateName(int userRequirementId);
        void Update(Policy policyDetails);
        List<Policy> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}