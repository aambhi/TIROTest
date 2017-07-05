using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class CandidateSearch
    {
        public string CONTACT_NO { get; set; }
        public string PASSPORT_NO { get; set; }
        public string NAME { get; set; }
        public DateTime? DOB { get; set; }
        public string REGISTRATION_NO { get; set; }
        public int USER_TYPE_ID { get; set; }
        public string VISA_NUMBER { get; set; }
    }

}
