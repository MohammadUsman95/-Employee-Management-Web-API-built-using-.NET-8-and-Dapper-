using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<Employee?> GetEmployeeById(int id);
        public Task<int> CreateEmployee(Employee employee);
        public Task<int> UpdateEmployee(Employee employee);
        public Task<int> DeleteEmployee(int id);
    }
}
