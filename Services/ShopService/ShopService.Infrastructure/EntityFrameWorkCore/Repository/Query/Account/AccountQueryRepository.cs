using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.Account;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Account
{
    public class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<CustomUserEntity> GetQueryable()
        {
            return _context.Users.AsQueryable();
        }
    }
}
