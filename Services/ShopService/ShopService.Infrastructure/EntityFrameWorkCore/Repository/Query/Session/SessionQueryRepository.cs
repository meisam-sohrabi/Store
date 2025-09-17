using Second.Domain.Entities;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.InfrastructureContract.Interfaces.Query.Session;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Session
{
    public class SessionQueryRepository : ISessionQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public  IQueryable<UserSessionEntity> GetSessionQueryable()
        {
             return _context.UserSessions.AsQueryable();
        }
    }
}
