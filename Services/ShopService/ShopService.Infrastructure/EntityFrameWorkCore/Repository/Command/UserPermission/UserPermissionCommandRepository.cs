using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.UserPermission;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.UserPermission
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
