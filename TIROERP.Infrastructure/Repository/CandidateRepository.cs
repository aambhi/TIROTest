using EntityFrameworkExtras.EF6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.DBModel;
using TIROERP.Infrastructure.Utilities;

namespace TIROERP.Infrastructure.Repository
{
    public class CandidateRepository : ICandidate
    {
        CommonRepository common = new CommonRepository();

        ArbabTravelsERPEntities _entities;

        public string Create(Candidate candidate)
        {
            try
            {
                _entities = new ArbabTravelsERPEntities();
                var procedure = new PROC_USER_INSERT()
                {
                    USER_TYPE_ID = candidate.USER_TYPE_ID,
                    UDT_USER_DETAIL = CommonRepository.GetLstUserDetails(candidate),
                    UDT_USER_ADDRESS = CommonRepository.GetLstUserAddress(candidate),
                    UDT_USER_CONTACT = CommonRepository.GetLstUserContact(candidate),
                    UDT_USER_EMAIL = CommonRepository.GetLstUserEmail(candidate),
                    UDT_USER_EDUCATION = CommonRepository.GetLstUserEducation(candidate),
                    UDT_USER_CERTIFICATION = common.GetLstUserCertification(candidate),
                    UDT_USER_EXPERIENCE = common.GetLstUserExperience(candidate),
                    UDT_USER_DOCUMENT = CommonRepository.GetLstUserDocument(candidate),
                    UDT_USER_PASSPORT = CommonRepository.GetLstUserPassport(candidate),
                    UDT_USER_DRIVING = CommonRepository.GetLstUserDriving(candidate),
                    UDT_USER_LANGUAGE = CommonRepository.GetLstUserLanguage(candidate)
                };

                var regno = _entities.Database.ExecuteStoredProcedure<string>(procedure);
                return Convert.ToString(regno.ToList()[0]);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IEnumerable> GetMasterData()
        {
            var results = new ArbabTravelsERPEntities()
                .MultipleResults("[dbo].[PROC_USER_GETMASTER]")
                .With<Country>()
                .With<ContactType>()
                .With<AvailingType>()
                .With<Source>()
                .With<Status>()
                .With<MaritalStatus>()
                .With<Nationality>()
                .With<Language>()
                .With<University>()
                .With<Company>()
                .With<IndustryDesignation>()
                .With<EducationSpeciaization>()
                .With<VehicleType>()
                .With<Branch>()
                .With<Certification>()
                .With<VisaMaster>()
                .With<RequirementMaster>()
                .With<Gender>()
                .With<Religion>()
                .With<City>()
                .Execute();

            return results;
        }

        public List<Country> GetCountryStateCity(string code)
        {
            return common.LstGetCountryStateCity(code);
        }

        public List<Source> GetSourceByAvailingType(int availTypeId)
        {
            _entities = new ArbabTravelsERPEntities();

            if (availTypeId == 2)
            {
                int[] sid = new int[] { 6, 8 };
                var lstSource = (from source in _entities.TBL_SOURCE_MASTER
                                 where sid.Contains(source.SOURCE_ID)
                                 select source).Select(x => new Source
                                 {
                                     SOURCE_ID = x.SOURCE_ID,
                                     SOURCE_NAME = x.SOURCE_NAME
                                 }).ToList();
                return lstSource;
            }
            else if (availTypeId == 3)
            {
                int[] sid = new int[] { 1, 5, 8 };
                var lstSource = (from source in _entities.TBL_SOURCE_MASTER
                                 where sid.Contains(source.SOURCE_ID)
                                 select source).Select(x => new Source
                                 {
                                     SOURCE_ID = x.SOURCE_ID,
                                     SOURCE_NAME = x.SOURCE_NAME
                                 }).ToList();
                return lstSource;
            }
            else
            {
                var lstSource = _entities.TBL_SOURCE_MASTER.Select(x => new Source
                {
                    SOURCE_ID = x.SOURCE_ID,
                    SOURCE_NAME = x.SOURCE_NAME
                }).ToList();
                return lstSource;
            }
        }

        public List<OtherSource> GetOtherSourceBySource(int sourceId)
        {
            _entities = new ArbabTravelsERPEntities();
            if (sourceId == 2)
            {
                var lstSource = _entities.TBL_PORTAL_MASTER.Select(x => new OtherSource
                {
                    ID = x.PORTAL_ID.ToString(),
                    NAME = x.PORTAL_NAME
                }).ToList();
                return lstSource;
            }
            else if (sourceId == 3)
            {
                var lstSource = _entities.TBL_ADVERTISEMENT_MASTER.Where(c => c.IS_ACTIVE == true).ToList().Select(x => new OtherSource
                {
                    ID = x.ADV_ID.ToString(),
                    NAME = x.PAPER_NAME + "-" + Convert.ToDateTime(x.ADV_DATE).ToString("dd/MM/yyyy")
                }).ToList();
                return lstSource;
            }
            else if (sourceId == 4)
            {
                var lstSource = _entities.PROC_GETUSER_BYUSERTYPE(3).Select(x => new OtherSource
                {
                    ID = x.REGISTRATION_NO,
                    NAME = x.NAME
                }).ToList();
                return lstSource;
            }
            else if (sourceId == 6)
            {
                var lstSource = _entities.PROC_GETUSER_BYUSERTYPE(5).Select(x => new OtherSource
                {
                    ID = x.REGISTRATION_NO,
                    NAME = x.NAME
                }).ToList();
                return lstSource;
            }
            return null;
        }

        public List<EducationSpeciaization> GetSpecializationByEducation(int educationId)
        {
            return common.LstGetSpecializationByEducation(educationId);
        }

        public List<IndustryDesignation> GetDesignationByIndustry(int industryId)
        {
            return common.LstGetDesignationByIndustry(industryId);
        }

        public List<IndustryDesignation> GetDesignationByIndustry(int[] industryId)
        {
            return common.LstGetDesignationByIndustry(industryId);
        }

        public bool CheckDuplicate(Candidate candidate)
        {
            _entities = new ArbabTravelsERPEntities();

            var result = _entities.PROC_CHECKDUPLICATE_USER(candidate.USER_TYPE_ID, candidate.FIRST_NAME, candidate.LAST_NAME, candidate.DATE_OF_BIRTH, candidate.PLACE_OF_BIRTH).ToList();

            if (result[0] != null)
                return false;

            return true;
        }
    }
}

