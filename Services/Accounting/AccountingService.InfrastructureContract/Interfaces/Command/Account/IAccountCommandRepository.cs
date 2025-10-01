﻿using AccountingService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace AccountingService.InfrastructureContract.Interfaces.Command.Account
{
    public interface IAccountCommandRepository
    {
        Task<IdentityResult> Create(CustomUserEntity user, string password);
        void Update(CustomUserEntity user);
        Task<IdentityResult> Delete(CustomUserEntity user);
    }
}
