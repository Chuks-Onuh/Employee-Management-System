using EmploymentManagementSystem.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmploymentManagementSystem.Infrastructure.Contracts.Interface
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployeeAsync(Employee employee);
        Task<List<Employee>> GetEmployeesAsync();
    }
}
