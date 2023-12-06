using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Insurance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser iser;
        public UserController(IUser iser)
        {
            this.iser = iser;
        }

        [HttpPost("Insert")]
        public IActionResult InsertUser(InsertUser insertUser)
        {
            try
            {

                if (insertUser == null) return BadRequest("Inicialize data  , at first");
                var result = iser.InsertUser(insertUser);
                if (result == false) return NotFound("Unsucessfull");

                return Ok(" success Registration");

            }
            catch (Exception exp)
            {
                return StatusCode(234, " somethings unusual");
            }
        }

    }
}
