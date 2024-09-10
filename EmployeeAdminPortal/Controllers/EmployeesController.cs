using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Net;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:xxxx/api/
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region INDEX
        /// <summary>
        /// Get the list of all employees:
        /// </summary>
        /// <returns>the list of employees</returns>
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);
        }
        #endregion

        #region GET BY ID
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = dbContext.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null) 
            {
                return NotFound();
            }
            return Ok(employee);
        }
        #endregion

        #region INSERT
        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDto)
        {
            var emplooyeeEntity = new Employee() { 
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Address = addEmployeeDto.Address,
                Country = addEmployeeDto.Country,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary,
                DateofEmployment = addEmployeeDto.DateofEmployment,
            };
            
            dbContext.Employees.Add(emplooyeeEntity);
            dbContext.SaveChanges();
            
            return Ok(emplooyeeEntity);
        }
        #endregion

        #region UPDATE
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDto)
        {
            var employee = dbContext.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Address = updateEmployeeDto.Address;
            employee.Country = updateEmployeeDto.Country;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            employee.DateofEmployment = updateEmployeeDto.DateofEmployment;
            
            dbContext.SaveChanges();
            return Ok(employee);
        }
        #endregion

        #region DELETE
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            var employee = dbContext.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }
        #endregion
    }
}
