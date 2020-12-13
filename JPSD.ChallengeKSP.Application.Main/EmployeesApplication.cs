using System;
using AutoMapper;
using JPSD.ChallengeKSP.Application.DTO;
using JPSD.ChallengeKSP.Application.Interface;
using JPSD.ChallengeKSP.Domain.Entity;
using JPSD.ChallengeKSP.Domain.Interface;
using JPSD.ChallengeKSP.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace JPSD.ChallengeKSP.Application.Main
{
    public class EmployeesApplication : IEmployeesApplication
    {

        private readonly IEmployeesDomain _employeesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<EmployeesApplication> _logger;

        public EmployeesApplication(IEmployeesDomain employeesDomain, IMapper mapper, IAppLogger<EmployeesApplication> logger) 
        {
            _employeesDomain = employeesDomain;
            _mapper = mapper;
            _logger = logger;
        }


        #region Métodos Asíncronos        
        public async Task<Response<bool>> DeleteAsync(int employeeId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _employeesDomain.DeleteAsync(employeeId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<EmployeesDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<EmployeesDTO>>();
            try
            {
                var employees = await _employeesDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<EmployeesDTO>>(employees);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<EmployeesDTO>> GetAsync(int employeeId)
        {
            var response = new Response<EmployeesDTO>();
            try
            {
                var employees = await _employeesDomain.GetAsync(employeeId);
                response.Data = _mapper.Map<EmployeesDTO>(employees);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> InsertAsync(EmployeesDTO employeeDTO)
        {
            var response = new Response<bool>();
            try
            {
                var employees = _mapper.Map<Employees>(employeeDTO);
                response.Data = await _employeesDomain.InsertAsync(employees);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(EmployeesDTO employeeDTO)
        {
            var response = new Response<bool>();
            try
            {
                var employees = _mapper.Map<Employees>(employeeDTO);
                response.Data = await _employeesDomain.UpdateAsync(employees);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }
        #endregion
    }
}
