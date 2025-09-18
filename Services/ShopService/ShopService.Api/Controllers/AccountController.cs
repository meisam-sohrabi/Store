using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.Interfaces.Account;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }


    }
}
