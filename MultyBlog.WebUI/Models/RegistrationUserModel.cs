using MultyBlog.WebUI.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultyBlog.WebUI.Models
{
    [DoublePasswordCheck()]
    public class RegistrationUserModel
    {
        public UserModel User { set; get; }

        [DisplayName("Repeat password: ")]
        [Required(ErrorMessage = "Please repeat password")]
        public string PasswordRepeat { set; get; }

    }
}