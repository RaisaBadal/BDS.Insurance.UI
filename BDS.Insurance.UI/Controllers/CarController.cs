using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BDS.Insurance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CarController : ControllerBase
    {
        private readonly ICar icar;
        public CarController(ICar icar)
        {
            this.icar = icar;
        }
        #region Insert

        [HttpPost("Insert")]
        public IActionResult InsertCar(InsertCar insertcar)
        {
            try
            {
                int userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                if (insertcar == null||userid==null) return BadRequest("Inicialize data  , at first");
                var result = icar.InsertCar(insertcar,userid);
                if (result == false) return NotFound("Unsucessfull");

                return Ok(" success Registration");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }
        #endregion

        #region GetAllCar
        [HttpGet("GetAll")]
        public List<Car> GetAllCar()
        {
            return icar.GetAllCar();
        }

        #endregion

        #region GetCarById
        [HttpPost("CarByID")]
        public IActionResult GetCarById(CarById car)
        {
            try
            {
                if (car == null) return BadRequest();
                var cardel = icar.GetCarById(car);
                if (cardel == null) return NotFound();
                return Ok(cardel);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region DeleteCarById
        [HttpDelete("DeleteByID")]
        public IActionResult  DeleteCarById(DeleteCar deletecar)
        {
            try
            {
                if (deletecar == null) return BadRequest();
                var deletcar = icar.DeleteCarById(deletecar);
                if (deletecar == null) return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(103);
            }
        }
        #endregion


    }
}
