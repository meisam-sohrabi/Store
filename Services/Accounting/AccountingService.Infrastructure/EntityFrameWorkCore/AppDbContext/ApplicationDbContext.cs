using AccountingService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BaseConfig;
namespace AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<CustomUserEntity>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ApplicaitonConfiguration.connectionSqlString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<UserPermissoinEntity> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
