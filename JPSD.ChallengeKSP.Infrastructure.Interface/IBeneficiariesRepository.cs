using System.Collections.Generic;
using JPSD.ChallengeKSP.Domain.Entity;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Infrastructure.Interface
{
    public interface IBeneficiariesRepository
    {
        #region Métodos Asíncronos
        Task<bool> InsertAsync(Beneficiaries beneficiary);
        Task<bool> UpdateAsync(Beneficiaries beneficiary);
        Task<bool> DeleteAsync(int beneficiaryId);

        Task<Beneficiaries> GetAsync(int beneficiaryId);
        Task<Beneficiaries> GetByEmployeeAsync(int employeeID);
        Task<IEnumerable<Beneficiaries>> GetAllAsync();
        #endregion
    }
}
