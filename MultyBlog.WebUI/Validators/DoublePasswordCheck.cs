using MultyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultyBlog.WebUI.Validators
{
    public class DoublePasswordCheck : ValidationAttribute
    {
         public DoublePasswordCheck()
            : base("Password do not match")
        {  
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (RegistrationUserModel)validationContext.ObjectInstance;


            return model.PasswordRepeat == model.User.Password ? ValidationResult.Success:  new ValidationResult("Password do not match");
        }


    }
}