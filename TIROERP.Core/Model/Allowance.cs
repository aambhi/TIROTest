using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Allowance
    {
      public int ALLOWANCE_ID { get; set; }  
      public string ALLOWANCE_NAME { get; set; }  
      public bool? IS_ACTIVE { get; set; }  
      public DateTime? CREATED_DATE { get; set; }
      public string CREATED_BY { get; set; } 
    }
}







