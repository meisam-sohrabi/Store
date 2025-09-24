﻿using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.Permission;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Permission
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
            var key = _context.Model.FindEntityType(typeof(ProductEntity))?.FindPrimaryKey();
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
