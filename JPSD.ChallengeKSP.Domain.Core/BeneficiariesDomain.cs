using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Domain.Interface;
using JPSD.ChallengeKSP.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JPSD.ChallengeKSP.Domain.Core
{
    public class BeneficiariesDomain : IBeneficiariesDomain
    {

        private readonly IBeneficiariesRepository _beneficiariesRepository;
        public BeneficiariesDomain(IBeneficiariesRepository beneficiariesRepository)
        {
            _beneficiariesRepository = beneficiariesRepository;
        }


        #region Métodos Asíncronos        
        public async Task<bool> DeleteAsync(int beneficiaryId)
        {
            return await _beneficiariesRepository.DeleteAsync(beneficiaryId);
        }

        public async Task<IEnumerable<Beneficiaries>> GetAllAsync()
        {
            return await _beneficiariesRepository.GetAllAsync();
        }

        public async Task<Beneficiaries> GetAsync(int beneficiaryId)
        {
            return await _beneficiariesRepository.GetAsync(beneficiaryId);
        }

        public async Task<Beneficiaries> GetByEmployeeAsync(int employeeID)
        {
            return await _beneficiariesRepository.GetByEmployeeAsync(employeeID);
        }

        public async Task<bool> InsertAsync(Beneficiaries beneficiary)
        {
            return await _beneficiariesRepository.InsertAsync(beneficiary);
        }

        public async Task<bool> UpdateAsync(Beneficiaries beneficiary)
        {
            return await _beneficiariesRepository.UpdateAsync(beneficiary);
        }
        #endregion
    }
}
