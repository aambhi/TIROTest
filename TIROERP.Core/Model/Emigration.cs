using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Emigration
    {
        public int EMIGRATION_ID { get; set; }
        public string FE_NO { get; set; }
        public string PT_NO { get; set; }

        public int USER_REQUIREMENT_ID { get; set; }

        public string DM_NO { get; set; }

        public DateTime? DM_DATE { get; set; }

        public string POLICY_NO { get; set; }

        public DateTime? POLICY_DATE { get; set; }

        public decimal? POLICY_AMOUNT { get; set; }

        public string POLICY_COMPANYNAME { get; set; }

        public string POLICY_ATTACHMENT { get; set; }

        public DateTime? SUBMISSION_DATE { get; set; }

        public string EMIGRATION_CLEARANCENO { get; set; }

        public string EMIGRATION_ATTACHMENT { get; set; }
        public string POE { get; set; }
        public string REMARK { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string PASSPORT_NUMBER { get; set; }

        public bool IS_ECR { get; set; }

    }
}
