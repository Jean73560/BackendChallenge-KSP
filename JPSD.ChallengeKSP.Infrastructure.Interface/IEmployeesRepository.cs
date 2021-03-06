﻿using System.Collections.Generic;
using JPSD.ChallengeKSP.Domain.Entity;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Infrastructure.Interface
{
    public interface IEmployeesRepository
    {
        #region Métodos Asíncronos
        Task<bool> InsertAsync(Employees employee);
        Task<bool> UpdateAsync(Employees employee);
        Task<bool> DeleteAsync(int employeeId);

        Task<Employees> GetAsync(int employeeId);
        Task<IEnumerable<Employees>> GetAllAsync();
        #endregion
    }
}
