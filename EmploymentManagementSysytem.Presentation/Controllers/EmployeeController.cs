using AutoMapper;
using EmploymentManagementSystem.Domain.Models;
using EmploymentManagementSystem.Domain.ViewModels;
using EmploymentManagementSystem.Infrastructure.Contracts.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmploymentManagementSysytem.Presentation.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }

        public async Task<ActionResult> Details()
        {
            return View(await _employeeRepository.GetEmployeesAsync());
        }

        public async Task<IActionResult> Search(string searchParam)
        {
            var employees = new List<Employee>();

            if (!string.IsNullOrWhiteSpace(searchParam))
            {
                var result = await _employeeRepository.GetEmployeesAsync();
                employees = result.Where(x => x.FirstName.ToLower().Contains(searchParam.ToLower())
                || x.LastName.ToLower().Contains(searchParam.ToLower()) || x.Department.ToLower().Contains(searchParam.ToLower())
                || x.BirthDate.ToString("MM/dd/yyyy").Contains(searchParam)).ToList();
            }

            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var employee = _mapper.Map<Employee>(model);
            await _employeeRepository.AddEmployeeAsync(employee);
            return RedirectToAction("Details");

        }
    }
}
