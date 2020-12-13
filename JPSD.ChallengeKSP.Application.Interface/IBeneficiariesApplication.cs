using System.Collections.Generic;
using JPSD.ChallengeKSP.Application.DTO;
using JPSD.ChallengeKSP.Transversal.Common;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Application.Interface
{
    public interface IBeneficiariesApplication
    {
        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(BeneficiariesDTO beneficiary);
        Task<Response<bool>> UpdateAsync(BeneficiariesDTO beneficiary);
        Task<Response<bool>> DeleteAsync(int beneficiaryId);

        Task<Response<BeneficiariesDTO>> GetAsync(int beneficiaryId);
        Task<Response<BeneficiariesDTO>> GetByEmployeeAsync(int employeeID);
        Task<Response<IEnumerable<BeneficiariesDTO>>> GetAllAsync();
        #endregion
    }
}
