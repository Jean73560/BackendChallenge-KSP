using System.Collections.Generic;
using JPSD.ChallengeKSP.Application.DTO;
using JPSD.ChallengeKSP.Transversal.Common;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Application.Interface
{
    public interface IEmployeesApplication
    {
        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(EmployeesDTO employee);
        Task<Response<bool>> UpdateAsync(EmployeesDTO employee);
        Task<Response<bool>> DeleteAsync(int employeeId);

        Task<Response<EmployeesDTO>> GetAsync(int employeeId);
        Task<Response<IEnumerable<EmployeesDTO>>> GetAllAsync();
        #endregion
    }
}
