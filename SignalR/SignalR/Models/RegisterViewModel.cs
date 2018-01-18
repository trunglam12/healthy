using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Remote("IsUserNameExist", "Login", ErrorMessage = "The {0} is exist")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Confirm password")]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }

        public LoginViewModel LoginViewModel { get; set; }

        public RegisterViewModel()
        {
            LoginViewModel = new LoginViewModel();
        }

    }
}