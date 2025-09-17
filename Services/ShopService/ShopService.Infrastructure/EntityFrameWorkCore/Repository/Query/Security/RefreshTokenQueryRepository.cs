using Microsoft.EntityFrameworkCore;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Security;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Security
{
    public class RefreshTokenQueryRepository : IRefreshTokenQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  IQueryable<RefreshTokenEntity> GetRefreshTokenQueryable()
        {
            return  _context.RefreshToken.AsQueryable();
        }

    }
}
