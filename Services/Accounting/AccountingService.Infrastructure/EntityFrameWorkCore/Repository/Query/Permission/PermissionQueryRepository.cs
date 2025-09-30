using AccountingService.Domain.Entities;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.InfrastructureContract.Interfaces.Query.Permission;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.Permission
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
