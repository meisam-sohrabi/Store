using Second.Domain.Entities;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.InfrastructureContract.Interfaces.Command.Session;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Session
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
