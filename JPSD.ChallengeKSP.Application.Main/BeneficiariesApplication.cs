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
    public class BeneficiariesApplication : IBeneficiariesApplication
    {


        private readonly IBeneficiariesDomain _beneficiariesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<BeneficiariesApplication> _logger;

        public BeneficiariesApplication(IBeneficiariesDomain beneficiariesDomain, IMapper mapper, IAppLogger<BeneficiariesApplication> logger)
        {
            _beneficiariesDomain = beneficiariesDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Asíncronos 
        public async Task<Response<bool>> DeleteAsync(int beneficiaryId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _beneficiariesDomain.DeleteAsync(beneficiaryId);
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

        public async Task<Response<IEnumerable<BeneficiariesDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<BeneficiariesDTO>>();
            try
            {
                var beneficiaries = await _beneficiariesDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<BeneficiariesDTO>>(beneficiaries);
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

        public async Task<Response<BeneficiariesDTO>> GetAsync(int beneficiaryId)
        {
            var response = new Response<BeneficiariesDTO>();
            try
            {
                var beneficiaries = await _beneficiariesDomain.GetAsync(beneficiaryId);
                response.Data = _mapper.Map<BeneficiariesDTO>(beneficiaries);
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

        public async Task<Response<BeneficiariesDTO>> GetByEmployeeAsync(int employeeID)
        {
            var response = new Response<BeneficiariesDTO>();
            try
            {
                var beneficiaries = await _beneficiariesDomain.GetByEmployeeAsync(employeeID);
                response.Data = _mapper.Map<BeneficiariesDTO>(beneficiaries);
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

        public async Task<Response<bool>> InsertAsync(BeneficiariesDTO beneficiaryDTO)
        {
            var response = new Response<bool>();
            try
            {
                var beneficiaries = _mapper.Map<Beneficiaries>(beneficiaryDTO);
                response.Data = await _beneficiariesDomain.InsertAsync(beneficiaries);
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

        public async Task<Response<bool>> UpdateAsync(BeneficiariesDTO beneficiaryDTO)
        {
            var response = new Response<bool>();
            try
            {
                var beneficiaries = _mapper.Map<Beneficiaries>(beneficiaryDTO);
                response.Data = await _beneficiariesDomain.UpdateAsync(beneficiaries);
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
