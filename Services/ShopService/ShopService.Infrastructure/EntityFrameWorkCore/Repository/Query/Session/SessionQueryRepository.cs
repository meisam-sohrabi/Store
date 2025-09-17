using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Session;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Session
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
