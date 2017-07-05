using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter Username")]
        public string User_Code { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }

    public class UserLoginResult
    {
        public string REGISTRATION_NO { get; set; }
        public int USER_TYPE_ID { get; set; }
        public string USER_IMAGE_PATH { get; set; }
        public string NAME { get; set; }
        public int? OPEN_TASK { get; set; }
        public string LOGIN_PASSWORD { get; set; }
    }
}