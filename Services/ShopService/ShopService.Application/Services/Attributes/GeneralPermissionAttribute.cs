using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopService.InfrastructureContract.Interfaces.Query.UserPermission;
using System.Security.Claims;

namespace ShopService.Application.Services.Attributes
{
    public class GeneralPermissionAttribute : Attribute, IAsyncAuthorizationFilter
    {
        private readonly string _resource;
        private readonly string _action;
        public GeneralPermissionAttribute(string Resource, string Action)
        {
            _resource = Resource;
            _action = Action;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                context.Result = new ForbidResult();
                return;

            }
            var user = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user == null)
            {
                context.Result = new ForbidResult();
                return;
            }
            var userPermission = context.HttpContext.RequestServices.GetRequiredService<IUserPermissionQueryRepository>();
            var hasPermission = await userPermission.GetQueryable()
                .AnyAsync(e => e.UserId == user && e.Permission.Resource == _resource && e.Permission.Action == _action);
            if(!hasPermission)
            {
                context.Result = new ForbidResult();
                return;
            }

        }
    }
}

