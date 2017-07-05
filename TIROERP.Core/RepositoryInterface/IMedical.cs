using System;
using System.Collections.Generic;
using TIROERP.Core.Model;

namespace TIROERP.Core.RepositoryInterface
{
    public interface IMedical
    {
        void Create(Medical medicalDetails);

        void Update(Medical medicalDetails);
        List<Passport_Details> GetPassportNumbers();
        List<Doctor_Details> GetDoctorsList();
        string GetCandidateName(int userRequirementId);

        List<Medical> GetAllProcess(int id, string condition_operator, DateTime? fromDate = null, DateTime? toDate = null, string passportNo = null);
    }
}