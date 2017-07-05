using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
using TIROERP.Web.App_Start;
using TIROERP.Web.Utilities;

namespace TIROERP.Web.Controllers
{
    
    [Authenticate]
    [ErrorFilter]
    public class DocumentController : Controller
    {
        private readonly IStatusSearch _iStatusSearchRepository;

        public DocumentController(IStatusSearch iStatusSearchRepository)
        {
            _iStatusSearchRepository = iStatusSearchRepository;
        }

        // GET: Document
        public ActionResult Index()
        {
            List<CandidateSearch> lstCandidate = new List<CandidateSearch>();
            return View(lstCandidate);
        }

        [HttpPost]
        public ActionResult Index(string PASSPORT_NO)
        {
            var result = _iStatusSearchRepository.GetDocument(PASSPORT_NO, "", "UNDERTAKING");
            var lstCandidate = (List<CandidateSearch>)result[0];

            var candidateresult = lstCandidate.Select(x => new CandidateSearch()
            {
                NAME = x.NAME,
                PASSPORT_NO = x.PASSPORT_NO,
                REGISTRATION_NO = x.REGISTRATION_NO
            });
            return View(candidateresult);
        }

        public ActionResult DocumentDownload(string registrationNo)
        {
            var result = _iStatusSearchRepository.GetDocument("", registrationNo, "VISA_APPLICATION_FORM");
            var lstCandidate = (List<Candidate>)result[0];
            DataTable dtCandidate = Common.GetDataTableFromObjects(lstCandidate, "Candidate");

            ReportViewer rs = new ReportViewer();
            // Variables
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Remote;
            viewer.LocalReport.ReportPath = "Reports/Download.rdlc";
            viewer.AsyncRendering = false;
            viewer.SizeToReportContent = true;

            //Add Report Data Source              
            viewer.LocalReport.DataSources.Add(new ReportDataSource("Candidate", dtCandidate));

            viewer.LocalReport.Refresh();
            viewer.LocalReport.EnableExternalImages = true;

            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            string savePath = @Server.MapPath(ConfigurationManager.AppSettings["CandidateUploadedFiles"]) + "_" + registrationNo + "_Resume.pdf";
            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
            Response.BufferOutput = true;
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            return File(savePath, "application/force-download", Path.GetFileName(savePath));
        }
    }
}