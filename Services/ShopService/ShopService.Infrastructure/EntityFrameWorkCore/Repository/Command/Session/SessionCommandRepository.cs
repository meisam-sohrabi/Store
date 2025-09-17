using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Session;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Session
{
    public class SessionCommandRepository : ISessionCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(UserSessionEntity userSession)
        {
            await _context.UserSessions.AddAsync(userSession);
        }

        public  void Update(UserSessionEntity userSession)
        {
             _context.UserSessions.Update(userSession);
        }
    }
}
