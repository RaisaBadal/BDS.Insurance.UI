using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Insurance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILog ilog;
        public LogController(ILog ilog)
        {
            this.ilog = ilog;
        }
        #region GetAllLog
        [HttpGet("GetAll")]
        public IActionResult GetAllLogs()
        {
            try
            {
                var res = ilog.GetAllLogs();
                if (res == null) return NotFound(" not found Logs");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(200, "SOMETHINGS UNUSUAL");
            }
        }
        #endregion

        #region AllBetweenDate

        [HttpPost("AllBetweenDate")]
        public IActionResult GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
            try
            {
                if (logsbetweendate == null) return BadRequest(" No argument  found");
                var result = ilog.GetAllLogsBetweenDate(logsbetweendate);
                if (result == null) return NotFound(" no log found For this date");
                return Ok(result);
            }
            catch (Exception)
            {

                return StatusCode(100, " unusual");
            }
        }

        #endregion
    }
}
