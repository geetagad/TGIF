﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace TGIF.Models
{
    

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User Email")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email ")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password ")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    
        [Required]
        [StringLength(10)]
        [Display(Name = "Security Code ")]
        public string SecurityCode { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Student Name ")]
        public string StudentName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "School Name ")]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Display(Name = "Parent/Guardian name")]
        public string ParentName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        //[Phone]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Home Phone format is not valid.")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        [Display(Name = "Home Phone ")]
        public string HomePhone { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        [Display(Name = "Home Address ")]
        public string HomeAddress { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
