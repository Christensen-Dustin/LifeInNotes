using Life_In_Notes.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Life_In_Notes.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Entry Name cannot exceed 50 characters")]
        [Display(Name ="First Name")]
        // User's First Name
        public string NameFirst { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Entry Name cannot exceed 50 characters")]
        [Display(Name = "Last Name")]
        // User's Last Name
        public string NameLast { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Entry Name cannot exceed 50 characters")]
        [Display(Name = "User Name")]
        // Built-in validation method (ValidEmailDomainAttribute.cs)
        [Remote(action:"IsUserNameInUse", controller:"Account", ErrorMessage ="User Name is already use")]
        // UserName
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse", controller:"Account", ErrorMessage ="Email is already use")]
        // [ValidEmailDomain(allowedDomain: "gmail.com")]
        // User's Email
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        // User's Password
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        // Confirmation Password
        public string ConfirmPassword { get; set; }
    }
}
