using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIROERP.Core.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Net.Mail;
using System.Web.Hosting;
using TIROERP.Core.Constants;
using System.Net;
using System.Data;
using System.Reflection;

namespace TIROERP.Web.Utilities
{
    public class Common
    {
        public static IEnumerable<SelectListItem> FillCOuntryStateCity(string code, string type, IEnumerable result)
        {
            IEnumerable<SelectListItem> iitem;
            List<Country> lstCountry = (List<Country>)result;
            if (type == "S")
            {
                iitem = (from country in lstCountry
                         where country.COUNTRY_CODE == code
                         group country by new { country.STATE_CODE, country.STATE_NAME } into state
                         select state).Select(c => new SelectListItem
                         {
                             Value = c.Key.STATE_CODE,
                             Text = c.Key.STATE_NAME
                         });

            }
            else
            {
                iitem = (from country in lstCountry
                         where country.STATE_CODE == code
                         group country by new { country.CITY_CODE, country.CITY_NAME } into city
                         select city).Select(c => new SelectListItem
                         {
                             Value = c.Key.CITY_CODE,
                             Text = c.Key.CITY_NAME
                         });
            }

            return iitem;
        }

        public static string UploadFile(HttpPostedFileBase httpPostedFile, string filepath)
        {
            var path = Path.Combine(httpPostedFile.FileName);
            var filename = Path.GetFileName(path);
            filename = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + filename;
            var fileSavePath = (filepath + Convert.ToString(filename));
            httpPostedFile.SaveAs(fileSavePath);
            return filename;
        }

        public static string GenerateExcelFile(List<RequirementSearchViewModel> requirementViewModel, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets.Add("REQUIREMENT_DETAILS");

                worksheet.Cells[1, 1].Value = "REQUIREMENT_NO";
                worksheet.Cells[1, 2].Value = "CATEGORY";
                worksheet.Cells[1, 3].Value = "EXP";
                worksheet.Cells[1, 4].Value = "AGE";
                worksheet.Cells[1, 5].Value = "SPECIFICATION";
                worksheet.Cells[1, 6].Value = "SALARY";
                worksheet.Cells[1, 7].Value = "LOCATION";
                worksheet.Cells[1, 8].Value = "SCG";

                using (var range = worksheet.Cells[1, 1, 1, 33])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Gray);
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
                    range.Style.Border.Bottom.Color.SetColor(System.Drawing.Color.Black);
                    range.Style.Font.Color.SetColor(System.Drawing.Color.Black);
                    range.Style.Font.SetFromFont(new System.Drawing.Font("Arial", 10));
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                }

                var i = 0;

                foreach (var obj in requirementViewModel)
                {
                    worksheet.Cells[i + 2, 1].Value = ("R000" + obj.REQUIREMENT_ID);
                    worksheet.Cells[i + 2, 2].Value = (obj.INDUSTRY_TYPE + " - " + obj.DESIGNATION);
                    worksheet.Cells[i + 2, 3].Value = obj.EXPERIENCE;
                    worksheet.Cells[i + 2, 4].Value = obj.AGE;
                    worksheet.Cells[i + 2, 5].Value = (obj.EDUCATION_TYPE + " - " + obj.SPECIALIZATION);
                    worksheet.Cells[i + 2, 6].Value = obj.BASIC_SALARY;
                    worksheet.Cells[i + 2, 7].Value = obj.POSTING_PLACE;
                    worksheet.Cells[i + 2, 8].Value = obj.REMARK;
                    i++;
                }

                worksheet.Cells.AutoFitColumns();
                DateTime dt = DateTime.Now;
                string timeStamp = dt.Day + "_" + dt.Month + "_" + dt.Year + "_" + dt.Second;
                //string filePath = @"c:\RequirementExel\RequirementDetails_" + timeStamp + ".xlsx";
                package.SaveAs(new FileInfo(filePath));
                return filePath;
            }
        }

        public static void SendEmail(string fromAddress, string toAddress, string attachmentFilePath, string subject, string userName)
        {
            string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
            string SMTPPort = ConfigurationManager.AppSettings["SMTPPort"];
            int portNo = 0;
            if (!string.IsNullOrEmpty(SMTPPort))
                portNo = Convert.ToInt32(SMTPPort);

            if (!string.IsNullOrEmpty(SMTPServer) && !string.IsNullOrEmpty(SMTPPassword) && portNo > 0 && !string.IsNullOrEmpty(subject))
            {
                MailMessage mailObj = new MailMessage();
                mailObj.From = new MailAddress(fromAddress);
                var toAddressList = toAddress.Split(';');
                foreach (string bccEmailId in toAddressList)
                {
                    mailObj.Bcc.Add(new MailAddress(bccEmailId)); //Adding Multiple BCC email Id
                }
                //mailObj.To.Add(toAddress);
                SmtpClient smtpClient = new SmtpClient(SMTPServer, portNo);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromAddress, SMTPPassword);
                Attachment attachment;
                attachment = new System.Net.Mail.Attachment(attachmentFilePath);
                mailObj.Attachments.Add(attachment);
                mailObj.IsBodyHtml = true;
                mailObj.Subject = subject;
                string bodytemplate = string.Empty;
                using (var sr = new StreamReader(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["RequirementEmailTemplate"]) + EmailTemplateConstants.AgentEmailTemplate))
                {
                    bodytemplate = sr.ReadToEnd();
                }

                mailObj.Body = string.Format(bodytemplate, userName);

                try
                {
                    smtpClient.Send(mailObj);
                }
                catch (Exception ex)
                {
                    Common.LogError("SendEmail", "", "SendEmail", "EXCEPTION OCCURED", Convert.ToString(ex.Message), Convert.ToString(ex.InnerException));
                    throw new Exception(ex.Message);
                }
            }

        }

        public static DataTable GetDataTableFromObjects<T>(List<T> items, string dtName)
        {
            try
            {
                DataTable dataTable = new DataTable(dtName);

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void LogError(string Controller, string PageUrl, string Action, string ErrorMessage = null, string InnerException = null, string userCode = null, string UserIp = null)
        {

            string LOG_FILE = Convert.ToString(AppDomain.CurrentDomain.BaseDirectory) + "Log\\" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() + ".txt";
            //set up a filestream
            FileStream fs = new FileStream(LOG_FILE, FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text
            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream
            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text
            sw.WriteLine("==================================================================\r\nDateTime" + DateTime.Now.ToString() + "\r\n Controller: " +
                Controller + "\r\n URL: " + PageUrl + "\r\n Action: " + Action + "\r\n Error Message: " + ErrorMessage + "\r\n Inner Exception: " + InnerException + "\r\n User: " + userCode + "\r\n UserIP: " + UserIp + "\r\n==================================================================");
            //add the text to the underlying filestream

            sw.Flush();
            //close the writersw.Close();

            sw.Close();
        }
    }
}