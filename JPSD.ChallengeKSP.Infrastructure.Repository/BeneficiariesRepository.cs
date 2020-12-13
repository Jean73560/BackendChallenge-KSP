using Dapper;
using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Infrastructure.Interface;
using JPSD.ChallengeKSP.Transversal.Common;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JPSD.ChallengeKSP.Infrastructure.Repository
{
    public class BeneficiariesRepository : IBeneficiariesRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public BeneficiariesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Beneficiaries beneficiary)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesInsert";
                var parameters = new DynamicParameters();

                //parameters.Add("BeneficiaryID", beneficiary.BeneficiaryID);
                parameters.Add("EmployeeID", beneficiary.EmployeeID);
                parameters.Add("FullName", beneficiary.FullName);
                parameters.Add("Relationship", beneficiary.Relationship);
                parameters.Add("BirthDate", beneficiary.BirthDate);
                parameters.Add("Gender", beneficiary.Gender);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Beneficiaries beneficiary)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("BeneficiaryID", beneficiary.BeneficiaryID);
                parameters.Add("EmployeeID", beneficiary.EmployeeID);
                parameters.Add("FullName", beneficiary.FullName);
                parameters.Add("Relationship", beneficiary.Relationship);
                parameters.Add("BirthDate", beneficiary.BirthDate);
                parameters.Add("Gender", beneficiary.Gender);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(int beneficiaryId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesDelete";
                var parameters = new DynamicParameters();

                parameters.Add("BeneficiaryID", beneficiaryId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Beneficiaries> GetAsync(int beneficiaryId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesGetByID";
                var parameters = new DynamicParameters();

                parameters.Add("BeneficiaryID", beneficiaryId);

                var beneficiary = await connection.QuerySingleAsync<Beneficiaries>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return beneficiary;
            }
        }

        public async Task<Beneficiaries> GetByEmployeeAsync(int employeeID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesGetByEmployeeID";
                var parameters = new DynamicParameters();

                parameters.Add("EmployeeID", employeeID);

                var beneficiary = await connection.QuerySingleAsync<Beneficiaries>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return beneficiary;
            }
        }

        public async Task<IEnumerable<Beneficiaries>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "BeneficiariesGetAll";

                var beneficiaries = await connection.QueryAsync<Beneficiaries>(query, commandType: CommandType.StoredProcedure);
                return beneficiaries;
            }
        }

    }
}
