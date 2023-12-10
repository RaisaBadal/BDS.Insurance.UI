using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Insurance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IError ierror;
        public ErrorController(IError ierror)
        {
            this.ierror = ierror;
        }
        #region GetAllError
        [HttpGet("AllError")]
        public IActionResult GetAllError()
        {
            try
            {
                var res=ierror.GetAllError();
                if(res==null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        #endregion

        #region GetAllErrorBetweenDate
        [HttpPost("GetAllErrorBetweenDate")]
        public IActionResult GetAllErrorsBetweenDate(ErrorsBetweenDate errorsBetweenDate)
        {
            try
            {
                if (errorsBetweenDate == null) return BadRequest("No Argument Found");
                   var res = ierror.GetAllErrorsBetweenDate(errorsBetweenDate);
                if (res == null)
                {
                    return NotFound() ;
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(100, " unusual");
            }
        }

        #endregion
    }
}
