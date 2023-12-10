using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
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

        #region Insert
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
        #endregion

        #region SignIn
     
        [HttpPost("SignIn")]
       public IActionResult SignIn(UserSignIn usersignIn)
        {
            try
            {
                if (usersignIn == null) return BadRequest("Please enter Email");
                var usersign=iser.SignIn(usersignIn);
                if (usersign == false) return NotFound();
                return Ok("Succsesfull validation");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(100, "Error");
               
            }
        }
        #endregion

        #region Verification
        [HttpPost("Verification")]
        public IActionResult Verification(VerificationRequest verRequest)
        {
            try
            {
                if (verRequest == null) return BadRequest("Empty");
                var userver = iser.Verification(verRequest);
                if (userver == null) return NotFound();
                return Ok(userver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(100, "Error");

            }
        }
        #endregion

        #region GetAllUser
        [HttpGet("AllUsers")]
        public List<User> GetAllUser()
        {
            return iser.GetAllUser();
        }
        #endregion

        #region GetUserById
        [HttpPost("UserByID")]
        public  IActionResult GetUserById(UserID userid)
        {
            try
            {
                if (userid == null) return BadRequest();
                var user = iser.GetUserById(userid);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(103);
            }
        }
        #endregion




    }
}
