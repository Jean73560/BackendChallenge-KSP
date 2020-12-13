using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Domain.Interface;
using JPSD.ChallengeKSP.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JPSD.ChallengeKSP.Domain.Core
{
    public class EmployeesDomain : IEmployeesDomain
    {

        private readonly IEmployeesRepository _employeesRepository;
        public EmployeesDomain(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }


        #region Métodos Asíncronos
        
        public async Task<bool> DeleteAsync(int employeeId)
        {
            return await _employeesRepository.DeleteAsync(employeeId);
        }

        public async Task<IEnumerable<Employees>> GetAllAsync()
        {
            return await _employeesRepository.GetAllAsync();
        }

        public async Task<Employees> GetAsync(int employeeId)
        {
            return await _employeesRepository.GetAsync(employeeId);
        }

        public async Task<bool> InsertAsync(Employees employee)
        {
            return await _employeesRepository.InsertAsync(employee);
        }

        public async Task<bool> UpdateAsync(Employees employee)
        {
            return await _employeesRepository.UpdateAsync(employee);
        }
        #endregion
    }
}
