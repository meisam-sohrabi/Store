using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Second.InfrastructureContract.Interfaces.Query.Account;

namespace Second.Application.Services.Permission
{
    public class PermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userId = context.HttpContext.Request.Cookies["UserId"];

            if (userId == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            var loadService = context.HttpContext.RequestServices.GetRequiredService<IAccountQueryRepository>();
            var userExist = await loadService.GetQueryableUsers().AnyAsync(e => e.Id == userId);
            if (!userExist)
            {
                context.Result = new ForbidResult();
            }
            return;
        }
    }
}

