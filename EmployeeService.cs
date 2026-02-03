using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Repositories.Interface;
using EmployeeManagementAPI.Services.Interface;

namespace EmployeeManagementAPI.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }
        public async Task<Employee?> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeById(id);
        }
     
        public async Task<int> CreateEmployee(Employee employee)
        {
            return await  _employeeRepository.CreateEmployee(employee);
        }
        public async Task<int> UpdateEmployee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(employee);
        }
        public async Task<int> DeleteEmployee(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }
    }
}
