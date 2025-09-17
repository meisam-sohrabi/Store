using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.Account;

namespace ShopService.Api.Controllers
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
