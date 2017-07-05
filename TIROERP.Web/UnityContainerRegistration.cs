using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Interface;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Infrastructure.Repository;

namespace TIROERP.Web
{
    public class UnityContainerRegistration
    {
        public static IUnityContainer InitialiseContainer()
        {
            // Initialize the container
            var container = new UnityContainer();

            // Register the dependency
            container.RegisterType<ICountry, CountryRepository>();
            container.RegisterType<IAirline, AirlineRepository>();
            container.RegisterType<ICertification, CertificationRepository>();
            container.RegisterType<IIndustry, IndustryRepository>();
            container.RegisterType<IDesignation, DesignationRepository>();
            container.RegisterType<IVisa, VisaRepository>();
            container.RegisterType<IAdvertisement, AdvertisementRepository>();
            container.RegisterType<IDoctor, DoctorRepository>();
            container.RegisterType<IClient, ClientRepository>();
            container.RegisterType<IAgent, AgentRepository>();
            container.RegisterType<IStatusSearch, StatusSearchRepository>();
            container.RegisterType<IRequirement, RequirementRepository>();
            container.RegisterType<IUserLogin, LoginRepository>();
            container.RegisterType<IInterview, InterviewRepository>();
            container.RegisterType<IMedical, MedicalRepository>();
            container.RegisterType<IMofa, MofaRepository>();
            container.RegisterType<IPolicy, PolicyRepository>();
            container.RegisterType<ITicket, TicketRepository>();
            container.RegisterType<IVisaEndorsement, VisaEndorsementRepository>();
            container.RegisterType<ICandidate, CandidateRepository>();
            container.RegisterType<IMenu, MenuRepository>();
            container.RegisterType<IDashboard, DashboardRepository>();
            container.RegisterType<ITask, TaskRepository>();
            container.RegisterType<ICity, CityRepository>();
            container.RegisterType<IState, StateRepository>();
            container.RegisterType<ICompany, CompanyRepository>();
            container.RegisterType<IEducation, EducationRepository>();
            container.RegisterType<ISpecialization, SpecializationRepository>();
            container.RegisterType<IEmigration, EmigrationRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}