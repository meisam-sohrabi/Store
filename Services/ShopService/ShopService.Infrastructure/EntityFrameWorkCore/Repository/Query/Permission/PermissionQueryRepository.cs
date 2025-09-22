using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.Permission;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Permission
{
    public class PermissionQueryRepository : IPermissionQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<PermissionEntity> GetQueryable()
        {
            return _context.Permissions.AsQueryable();
        }
    }
}
