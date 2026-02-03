using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();

            if (employees == null)
            {
                return NotFound("No employees found.");
            }
            return Ok(employees);
        }
        //api/employee/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound($"Employee with id {id} not found.");
            }
            return Ok(employee);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is null.");
            }
            var createdEmployee = await _employeeService.CreateEmployee(employee);
            return Ok(createdEmployee);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is null.");
            }
            var existingEmployee = await _employeeService.GetEmployeeById(employee.Id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with id {employee.Id} not found.");
            }
            var updatedEmployee = await _employeeService.UpdateEmployee(employee);
            return Ok(updatedEmployee);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeService.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with id {id} not found.");
            }
            await _employeeService.DeleteEmployee(id);
            return Ok($"Employee with id {id} deleted successfully.");
        }
    }
}