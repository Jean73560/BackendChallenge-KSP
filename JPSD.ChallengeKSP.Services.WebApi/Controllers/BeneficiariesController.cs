using Microsoft.AspNetCore.Mvc;
using JPSD.ChallengeKSP.Application.DTO;
using JPSD.ChallengeKSP.Application.Interface;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesController : Controller
    {
        public readonly IBeneficiariesApplication _beneficiariesApplication;

        public BeneficiariesController(IBeneficiariesApplication beneficiariesApplication)
        {
            _beneficiariesApplication = beneficiariesApplication;
        }


        #region "Métodos Asincronos"
        /// <summary>
        /// Insertamos un Beneficiario
        /// </summary>
        /// <param name="beneficiariesDTO"></param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] BeneficiariesDTO beneficiariesDTO)
        {
            if (beneficiariesDTO == null)
            {
                return BadRequest();
            }

            var response = await _beneficiariesApplication.InsertAsync(beneficiariesDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Actualizamos un Beneficiario
        /// </summary>
        /// <param name="beneficiariesDTO"></param>
        /// <returns></returns>
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] BeneficiariesDTO beneficiariesDTO)
        {
            if (beneficiariesDTO == null)
            {
                return BadRequest();
            }

            var response = await _beneficiariesApplication.UpdateAsync(beneficiariesDTO);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Eliminamos a un Beneficiario
        /// </summary>
        /// <param name="beneficiaryId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{beneficiaryId}")]
        public async Task<IActionResult> DeleteAsync(int beneficiaryId)
        {
            //if (string.IsNullOrEmpty(beneficiaryId))
            //return BadRequest();
            var response = await _beneficiariesApplication.DeleteAsync(beneficiaryId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Llamada para obtener a un beneficiario
        /// </summary>
        /// <param name="beneficiaryId"></param>
        /// <returns></returns>
        [HttpGet("GetAsync/{beneficiaryId}")]
        public async Task<IActionResult> GetAsync(int beneficiaryId)
        {
            //if (string.IsNullOrEmpty(beneficiaryId))
            //return BadRequest();
            var response = await _beneficiariesApplication.GetAsync(beneficiaryId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Llamada para obtener al beneficiario de un empleado
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("GetByEmployeeAsync/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeAsync(int employeeId)
        {
            //if (string.IsNullOrEmpty(beneficiaryId))
            //return BadRequest();
            var response = await _beneficiariesApplication.GetByEmployeeAsync(employeeId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }


        /// <summary>
        /// Obtenemos todos los Beneficiarios
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _beneficiariesApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }
        #endregion

    }
}
