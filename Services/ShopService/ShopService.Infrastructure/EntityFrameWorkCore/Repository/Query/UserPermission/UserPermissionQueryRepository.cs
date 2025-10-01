using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.UserPermission;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.UserPermission
{
    public class UserPermissionQueryRepository : IUserPermissionQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public UserPermissionQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<UserPermissoinEntity> GetQueryable()
        {
            return _context.UserPermissoins.AsQueryable();
        }
    }
}
