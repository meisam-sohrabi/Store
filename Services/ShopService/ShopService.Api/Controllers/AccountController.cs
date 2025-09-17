using Microsoft.AspNetCore.Mvc;
using Second.Application.Services.Account;

namespace Second.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountAppService _accountAppService;

        public AccountController(AccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }


    }
}
