using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Currency
    {
        public int CURRENCY_ID { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string CURRENCY_SYMBOL { get; set; }
        public int DISPLAY_ORDER { get; set; }
        public bool IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime? MODIFIED_DATE { get; set; }
    }
}
