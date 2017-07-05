using System;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IMofa
    {
        void Create(Mofa mofaObj);
        List<Passport_Details> GetPassportNumbers();
        string GetCandidateName(int userRequirementId);
        void Update(Mofa mofaDetails);
        List<Mofa> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}