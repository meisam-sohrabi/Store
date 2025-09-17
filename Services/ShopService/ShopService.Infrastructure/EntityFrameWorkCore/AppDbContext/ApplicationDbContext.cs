using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Second.Domain.Entities;

namespace Second.Infrastructure.EntityFrameWorkCore.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<CustomUserEntity>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SecondAppDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<UserSessionEntity> UserSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().ToTable("Products");
            modelBuilder.Entity<CategoryEntity>().ToTable("Categories");
            modelBuilder.Entity<RefreshTokenEntity>().ToTable("RefreshToken");
            modelBuilder.Entity<UserSessionEntity>().ToTable("UserSessions");
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(300);
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<CustomUserEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.RefreshToken).WithOne(e => e.User).OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<RefreshTokenEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Token).IsRequired();
                entity.Property(e => e.UserId).IsRequired();
            });
            modelBuilder.Entity<UserSessionEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e=> e.User)
                .WithMany(e=> e.Sessions)
                .HasForeignKey(e=> e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
