using EmploymentManagementSystem.Domain.Models;
using EmploymentManagementSystem.Infrastructure.Contracts.Interface;
using EmploymentManagementSystem.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentManagementSystem.Infrastructure.Contracts.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            var employeeToAdd = await _context.Employees.AddAsync(employee);

            if (employeeToAdd == null)
                throw new ArgumentNullException(nameof(employee));
            return await _context.SaveChangesAsync() > 1;
        }

        public async Task<List<Employee>> GetEmployeesAsync() => await _context.Employees.ToListAsync();
        
    }
}
