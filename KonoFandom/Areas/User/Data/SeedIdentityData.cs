using KonoFandom.Areas.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.User.Data
{
    public class SeedIdentityData
    {
        public static void CreateDefaultAdministrator(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<KonoFandomUser>>();
            PasswordHasher<KonoFandomUser> ph = new PasswordHasher<KonoFandomUser>();

            using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>()))
            {
                if (!context.KonoFandomUser.Any())
                {
                    var User = new KonoFandomUser
                    {
                        UserName = "admin",
                        EmailConfirmed = true
                        
                    };

                    // Assign Admin role to the user.
                    UserManager.AddToRoleAsync(User, nameof(Role.Admin));

                    // Hash our temporary password.
                    User.PasswordHash = ph.HashPassword(User, "admin");

                    // Add to user to the database and save.
                    context.KonoFandomUser.Add(User);
                    context.SaveChanges();
                }
            }
        }
    }
}
