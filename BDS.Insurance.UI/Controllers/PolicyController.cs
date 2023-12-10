using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BDS.Insurance.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicy ipolicy;
        public PolicyController(IPolicy ipolicy)
        {
            this.ipolicy = ipolicy;
        }
        #region Insert
        [HttpPost("Insert")]
        public GetPolicyInfo InsertPolicy(InsertPolicy insertpolicy)
        {
            return ipolicy.InsertPolicy(insertpolicy);
        }
        #endregion

        #region SoftDelete
        [HttpPost("SoftDelete")]
        public IActionResult SoftDelete(PolicySoftDelete softdel)
        {
            try
            {
                if(softdel== null) { return BadRequest(); }
                var del=ipolicy.SoftDelete(softdel);
                if (del == false) { return NotFound(); }
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(103);
            }
        }
        #endregion

        #region GetPolicyByCarId
        [HttpPost("GetPolicyByCarId")]
        public IActionResult GetPolicyByCarId(CarById carid)
        {
            try
            {
            if(carid==null) { return BadRequest(); }
            var car=ipolicy.GetPolicyByCarId(carid);
            if (car==null)
            {
                return NotFound();
            }
                return Ok(car);

            }
            catch (Exception)
            {
                return StatusCode(103);
            }
        }
        #endregion

        #region GetAllPolicies
        [HttpGet("GetAllPolicies")]
        public List<Policy> GetAllPolicies()
        {
            return ipolicy.GetAllPolicies();
        }
        #endregion

        #region GetPolicysByPolicyId
        [HttpPost("GetPolicysByPolicyId")]
        public   IActionResult GetPolicysByPolicyId(GetPolicyById policyID)
        {
                try
                {
                if (policyID == null) return BadRequest();
                var car = ipolicy.GetPolicysByPolicyId(policyID);
                if (car == null) return NotFound();
                return Ok(car);
                }
                catch (Exception)
                {
                    return StatusCode(103);
                } 
        }
        #endregion

    }
}
