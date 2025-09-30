using AccountingService.Domain.Entities;
using AccountingService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using AccountingService.InfrastructureContract.Interfaces.Command.Account;
using Microsoft.AspNetCore.Identity;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.Repository.Command.Account
{
    public class AccountCommandRepository : IAccountCommandRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;
        private readonly ApplicationDbContext _context;

        public AccountCommandRepository(UserManager<CustomUserEntity> userManager,ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> Create(CustomUserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task Delete(CustomUserEntity user)
        {
            await _userManager.DeleteAsync(user);
        }


        public void Update(CustomUserEntity user)
        {
            var entry = _context.Entry(user);
            var key = _context.Model.FindEntityType(typeof(CustomUserEntity))?.FindPrimaryKey();
            if (key != null)
            {
                foreach (var property in key.Properties)
                {
                    entry.Property(property.Name).IsModified = false;
                }
            }
        }

    }
}
