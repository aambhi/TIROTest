using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class UserRequirement
    {
        public int USER_REQUIREMENT_ID { get; set; }
        public string REGISTRATION_NO { get; set; }
        public int? REQUIREMENT_ID { get; set; }
        public int? CANDIDATE_STATUS { get; set; }
        public bool CURRENT_STATUS { get; set; }
        public string CREATED_BY { get; set; }

        public string REQUIREMENT { get; set; }
        public string STATUS_NAME { get; set; }
    }
}
