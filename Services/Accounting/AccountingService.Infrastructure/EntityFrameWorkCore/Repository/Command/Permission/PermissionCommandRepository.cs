using AccountingService.Domain.Entities;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.InfrastructureContract.Interfaces.Command.Permission;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.Permission
{
    public class PermissionCommandRepository : IPermissionCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public PermissionCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(PermissionEntity permissionEntity)
        {
            _context.Permissions.Add(permissionEntity);
        }

        public void Delete(PermissionEntity permissionEntity)
        {
            _context.Permissions.Remove(permissionEntity);
        }

        public void Update(PermissionEntity permissionEntity)
        {
            var entry = _context.Entry(permissionEntity);
            var key = _context.Model.FindEntityType(typeof(PermissionEntity))?.FindPrimaryKey();
            if (key != null)
            {
                foreach (var property in key.Properties)
                {
                    entry.Property(property.Name).IsModified = false;
                }
            }
        }
    }
}
