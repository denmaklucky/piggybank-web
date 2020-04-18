using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace PiggyBank.IdentityServer.Infrastructure
{
    public class IdentityUserManager : UserManager<IdentityUser>
    {
        public IdentityUserManager(IUserStore<IdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<IdentityUser> passwordHasher,
            IEnumerable<IUserValidator<IdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<IdentityUser>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            
        }
    }
}
