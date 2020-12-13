using Microsoft.AspNetCore.Mvc;
using JPSD.ChallengeKSP.Application.DTO;
using JPSD.ChallengeKSP.Application.Interface;
using System.Threading.Tasks;

namespace JPSD.ChallengeKSP.Services.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        public readonly IEmployeesApplication _employeesApplication;

        public EmployeesController(IEmployeesApplication employeesApplication)
        {
            _employeesApplication = employeesApplication;
        }

        #region "Métodos Asincronos"

        /// <summary>
        /// Insertamos a un Empleado
        /// </summary>
        /// <param name="employeesDTO"></param>
        /// <returns></returns>
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] EmployeesDTO employeesDTO)
        {
            if (employeesDTO == null)
            {
                return BadRequest();
            }
                
            var response = await _employeesApplication.InsertAsync(employeesDTO);
            
            if (response.IsSuccess) 
            { 
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Actualizamos un Empleado
        /// </summary>
        /// <param name="employeesDTO"></param>
        /// <returns></returns>
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] EmployeesDTO employeesDTO)
        {
            if (employeesDTO == null)
            {
                return BadRequest();
            }
                
            var response = await _employeesApplication.UpdateAsync(employeesDTO);
            
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Eliminamos a un Empleado, eliminado logico
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{employeeId}")]
        public async Task<IActionResult> DeleteAsync(int employeeId)
        {
            //if (string.IsNullOrEmpty(employeeId))
                //return BadRequest();
            var response = await _employeesApplication.DeleteAsync(employeeId);
            if (response.IsSuccess) 
            { 
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Llamada para obtener a un empleado
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("GetAsync/{employeeId}")]
        public async Task<IActionResult> GetAsync(int employeeId)
        {
            //if (string.IsNullOrEmpty(employeeId))
                //return BadRequest();
            var response = await _employeesApplication.GetAsync(employeeId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }           
            
            return BadRequest(response.Message);
        }

        /// <summary>
        /// Obtenemos todos los Empleado
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _employeesApplication.GetAllAsync();
            if (response.IsSuccess)
            {
                return Ok(response);
            }
                
            return BadRequest(response.Message);
        }
        #endregion

    }
}
