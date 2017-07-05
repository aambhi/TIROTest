using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Core.Model
{
    public class Client
    {
        public Client()
        {
            LST_USER_ADDRESS = new List<UserAddress>();
            LST_USER_CONTACT = new List<UserContact>();
            LST_USER_EMAIL = new List<UserEmail>();
        }

        public string REGISTRATION_NO { get; set; }
        public string COMPANY_NAME { get; set; }
        public string CIVILIAN_NO { get; set; }

        [MaxLength(50)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter First Name")]
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }

        [MaxLength(50)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LAST_NAME { get; set; }
        public string FILE_PATH { get; set; }
        public string REMARK { get; set; }
        public string WEBSITE { get; set; }
        public string SKYPE { get; set; }
        public string CONTACT_REMARK { get; set; }

        public string REFERENCE { get; set; }
        public int[] INDUSTRY { get; set; }
        public int[] DESIGNATION { get; set; }

        public List<UserAddress> LST_USER_ADDRESS { get; set; }
        public List<UserContact> LST_USER_CONTACT { get; set; }
        public List<UserEmail> LST_USER_EMAIL { get; set; }
    }
}
