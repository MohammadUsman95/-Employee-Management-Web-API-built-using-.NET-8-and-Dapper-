using Dapper;
using EmployeeManagementAPI.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeManagementAPI.Repositories.Interface
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EmployeeManagementDatabase")!;
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var employees = await connection.QueryFirstOrDefaultAsync<Employee>(
                "SELECT Id, Name, Department FROM Employee WHERE Id = @Id",
                new { Id = id });
            return employees;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using var connection = new SqlConnection(_connectionString);
            var employees = await connection.QueryAsync<Employee>("SELECT Id, Name, Department FROM Employee");
            return employees;
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Employee (Name, Department) VALUES (@Name, @Department); SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await connection.QuerySingleAsync<int>(sql, new { employee.Name, employee.Department });
            return id;
        }
        public async Task<int> UpdateEmployee(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "UPDATE Employee SET Name = @Name, Department = @Department WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { employee.Name, employee.Department, employee.Id });
            return rowsAffected;
        }
        public async Task<int> DeleteEmployee(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Employee WHERE Id = @Id";
            var rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }
    }
}
