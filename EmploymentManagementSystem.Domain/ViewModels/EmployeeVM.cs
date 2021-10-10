using System;
using System.ComponentModel.DataAnnotations;

namespace EmploymentManagementSystem.Domain.ViewModels
{
    public class EmployeeVM
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime BirthDate { get; set; }
        public string Department { get; set; }
    }
}
