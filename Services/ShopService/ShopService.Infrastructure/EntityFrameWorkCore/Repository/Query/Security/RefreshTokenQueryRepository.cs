using Microsoft.EntityFrameworkCore;
using Second.ApplicationContract.DTO.Security;
using Second.Domain.Entities;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.InfrastructureContract.Interfaces.Query.Security;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Security
{
    public class RefreshTokenQueryRepository : IRefreshTokenQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RefreshTokenEntity> GetRefreshToken(RefreshTokenRequestDto refreshToken)
        {
            return await _context.RefreshToken.FirstOrDefaultAsync(c => c.Token == refreshToken.RefreshToken);
        }

        public async Task<RefreshTokenEntity> GetRefreshTokenByUserId(string userId)
        {
            return await _context.RefreshToken.FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
