using KonoFandom.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.Identity.Data
{
    public enum Role
    {
        Admin, Moderator
    }

    public class SeedIdentityData
    {
        public static void CreateDefaultAdministrator(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<UserManager<KonoFandomUser>>();

            using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>()))
            {
                if (!context.KonoFandomUser.Any())
                {
                    var User = new KonoFandomUser
                    {
                        UserName = "admin",
                        PasswordHash = "admin",
                    };

                    UserManager.AddToRoleAsync(User, nameof(Role.Admin));

                    context.KonoFandomUser.Add(User);
                    context.SaveChanges();
                }
            }
        }
    }
}
