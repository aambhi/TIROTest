using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Interview
    {
        public int InterviewID { get; set; }
        public Nullable<int> REQUIREMENT_ID { get; set; }
        public int InterviewModeId { get; set; }

        [Required(ErrorMessage ="Please enter interview date")]
        public DateTime InterviewDate { get; set; }
        public string InterviewVenue { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$",ErrorMessage ="Please enter expenses in proper format(upto 2 precision)")]
        [Range(0, 99999999.99, ErrorMessage = "Please enter expenses in proper format(upto 2 precision)")]
        public Nullable<decimal> InterviewExpenses { get; set; }
        public string InterviewRemark { get; set; }
        public bool IsSelected { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class Interview_Mode_Master
    {
        public int INTERVIEW_MODE_ID { get; set; }
        public string INTERVIEW_MODE { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public System.DateTime MODIFIED_DATE { get; set; }
    }

}
