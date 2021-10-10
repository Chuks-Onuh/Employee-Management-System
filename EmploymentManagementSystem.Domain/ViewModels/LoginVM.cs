﻿using System.ComponentModel.DataAnnotations;

namespace EmploymentManagementSystem.Domain.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
