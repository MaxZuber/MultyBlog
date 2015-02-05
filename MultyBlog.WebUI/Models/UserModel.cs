using MultyBlog.Dal.Abstract;
using MultyBlog.WebUI.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Models
{
    public class UserModel
    {
        public int ID { set; get; }

        [DisplayName("User name: ")]    
        [Required(ErrorMessage = "Please enter Username")]
        //[IsRegistered()]
        public string Username { set; get; }


        [DisplayName("Password: ")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { set; get; }


        [DisplayName("E-mail: ")]
        //[Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { set; get; }

        public DateTime RegistrationDate { set; get; }

        public bool Persistent { set; get; }

    }
}