using AccountingService.Domain.Entities;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.InfrastructureContract.Interfaces.Query.UserPermission;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Query.UserPermission
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
            return _context.UserPermissions.AsQueryable();
        }
    }
}
