using Dapper;
using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Infrastructure.Interface;
using JPSD.ChallengeKSP.Transversal.Common;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JPSD.ChallengeKSP.Infrastructure.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public EmployeesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Employees employees)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesInsert";
                var parameters = new DynamicParameters();

                //parameters.Add("EmployeeID", employees.EmployeeID);
                parameters.Add("FullName", employees.FullName);
                parameters.Add("Work", employees.Work);
                parameters.Add("Salary", employees.Salary);
                parameters.Add("Status", employees.Status);
                parameters.Add("HireDate", employees.HireDate);
                parameters.Add("PhotoPath", employees.PhotoPath);
                parameters.Add("Phone", employees.Phone);

                var result = await connection.ExecuteAsync(query,param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Employees employees)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("EmployeeID", employees.EmployeeID);
                parameters.Add("FullName", employees.FullName);
                parameters.Add("Work", employees.Work);
                parameters.Add("Salary", employees.Salary);
                parameters.Add("Status", employees.Status);
                parameters.Add("HireDate", employees.HireDate);
                parameters.Add("PhotoPath", employees.PhotoPath);
                parameters.Add("Phone", employees.Phone);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int employeesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesDelete";
                var parameters = new DynamicParameters();

                parameters.Add("EmployeeID", employeesId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Employees> GetAsync(int employeesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesGetByID";
                var parameters = new DynamicParameters();

                parameters.Add("EmployeeID", employeesId);

                var employee = await connection.QuerySingleAsync<Employees>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return employee;
            }
        }

        public async Task<IEnumerable<Employees>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "EmployeesGetAll";

                var employees = await connection.QueryAsync<Employees>(query, commandType: CommandType.StoredProcedure);
                return employees;
            }
        }

    }
}
