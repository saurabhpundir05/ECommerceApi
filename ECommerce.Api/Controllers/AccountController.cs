#region imports
using ECommerce.BusinessLogic.Interfaces;
using ECommerce.Core.Constants;
using ECommerce.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
#endregion

#region Accounts
namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Signup
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] AccountSignUpDTO signUpData)
        {
            var user = await _accountService.Create(signUpData);
            if (!user)
            {
                return Conflict(new { AppMessages.Account.Exists });
            }
            return Created("", new { AppMessages.Account.Created });
        }

        /// <summary>
        /// login account
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountLoginDTO loginData)
        {
            var loginUser = await _accountService.Login(loginData);
            if (loginUser == null)
            {
                return NotFound(new { AppMessages.Account.NotExists });
            }
            return Ok(loginUser);
        }

        /// <summary>
        /// User update
        /// </summary>
        /// <param name="updateData"></param>
        /// <returns></returns>
        [HttpPatch("update")]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> Update([FromBody] AccountUpdateDTO updateData)
        {
            var updateUser = await _accountService.Update(updateData);
            if (!updateUser)
            {
                return BadRequest(new { AppMessages.Account.UpdateFail });
            }
            return Ok(new { AppMessages.Account.UpdateSuccess });
        }
        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="updateData"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        [Authorize(Roles = "0,1,2")]
        public async Task<IActionResult> Delete([FromBody] AccountLoginDTO deleteData)
        {
            var deleteUser = await _accountService.Delete(deleteData);
            if (!deleteUser)
            {
                return BadRequest(new { AppMessages.Account.DeleteFail });
            }
            return Ok(new { AppMessages.Account.DeleteSuccess });
        }
    }
}
#endregion