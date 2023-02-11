using System;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.Authorization.IdentityServer.Data
{
    public static class DatabaseInitializer
    {
        public static void Init(IServiceProvider scopeServiceProvider)
        {
            var userManager = scopeServiceProvider.GetService<UserManager<IdentityUser>>();

            var user = new IdentityUser
            {
                UserName = "User"
            };

            var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();
                userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Scope, "OrdersAPI")).GetAwaiter().GetResult();
            }
        }
    }
}