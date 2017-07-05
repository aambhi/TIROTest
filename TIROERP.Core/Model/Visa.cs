﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Visa
    {
        public int VISA_ID { get; set; }

        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "Please select Client")]
        public string REGISTRATION_NUMBER { get; set; }

        public string CLIENT_NAME { get; set; }
        public string CIVILIAN_NUMBER { get; set; }

        [Required(ErrorMessage = "Please enter Visa Number")]
        public string VISA_NUMBER { get; set; }

        [Required(ErrorMessage = "Please Select Purpose")]
        public string PURPOSE { get; set; }

        [Required(ErrorMessage = "Please Select Place Of Endorsement")]
        public string PLACE_OF_ENDORSEMENT { get; set; }

        [Required(ErrorMessage = "Please enter Issue Date")]
        public string ISSUE_DATE { get; set; }
        public DateTime INDIAN_FORMAT_ISSUE_DATE { get; set; }

        [Required(ErrorMessage = "Please enter Expry Date")]
        public string EXPIRY_DATE { get; set; }
        public DateTime INDIAN_FORMAT_EXPIRY_DATE { get; set; }

        [Required(ErrorMessage = "Please enter Received Date")]
        public DateTime? RECIEVED_DATE { get; set; }
        
        public string FILE_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public string REMARK { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime? CREATED_DATE { get; set; }

        public List<GetClient> CLIENT_LIST { get; set; }

    }

    public class GetClient
    {
        public string REGISTRATION_NO { get; set; }
        public string NAME { get; set; }
    }
}
