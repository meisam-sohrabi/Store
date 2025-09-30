using AccountingService.Domain.Entities;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.InfrastructureContract.Interfaces.Command.UserPermission;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.UserPermission
{
    public class UserPermissionCommandRepository : IUserPermissionCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public UserPermissionCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AssignPermissionToUser(UserPermissoinEntity userPermissoinEntity)
        {
            await _context.UserPermissions.AddAsync(userPermissoinEntity);
        }

        public void RevokePermissionFromUser(UserPermissoinEntity userPermissoinEntity)
        {
             _context.UserPermissions.Remove(userPermissoinEntity);
        }
    }
}
