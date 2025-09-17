using Second.Domain.Entities;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.InfrastructureContract.Interfaces.Command.Security;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Security
{
    public class RefreshTokenCommandRepository : IRefreshTokenCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public RefreshTokenCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(RefreshTokenEntity refreshToken)
        {
            await _context.RefreshToken.AddAsync(refreshToken);
        }

        public void Delete(RefreshTokenEntity refreshToken)
        {
            _context.RefreshToken.Remove(refreshToken);
        }

        public  void Update(RefreshTokenEntity refreshToken)
        {
             _context.RefreshToken.Update(refreshToken);
        }
    }
}
