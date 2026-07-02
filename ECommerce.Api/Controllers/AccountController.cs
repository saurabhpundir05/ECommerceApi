using ECommerce.BusinessLogic.Interfaces;
using ECommerce.Core.Constants;
using ECommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] AccountSignUpDTO requestData)
        {
            var user = await _accountService.CreateUser(requestData);
            if (!user)
            {
                return Conflict(new { AppMessages.Account.Exists });
            }
            return Created("", new { AppMessages.Account.Created });
        }
    }
}
