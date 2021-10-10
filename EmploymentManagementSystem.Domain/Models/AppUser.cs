using Microsoft.AspNetCore.Identity;
using System;


namespace EmploymentManagementSystem.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
