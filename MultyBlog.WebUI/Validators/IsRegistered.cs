using MultyBlog.Dal.Abstract;
using MultyBlog.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultyBlog.WebUI.Validators
{
    public class IsRegistered : ValidationAttribute
    {
        private readonly IUserManager _userManager; 
        public IsRegistered() : base("This {0} already registered") 
        {
            _userManager = DependencyResolver.Current.GetService(typeof(IUserManager)) as IUserManager;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string username = value as string;

            return _userManager.IsUserRegistered(username) ? 
                new ValidationResult(string.Format("Username {0}, already registered", username)) 
                : ValidationResult.Success;
        }
    }
}