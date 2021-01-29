using KonoFandom.Areas.Admin.Data;
using KonoFandom.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KonoFandom.Testing
{
    public class FakeUser
    {
        private static readonly object _lock = new object();
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IdentityContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityContext>>()))
            {
                lock (_lock)
                {
                    if (!context.KonoFandomUser.Any())
                    {
                        // Add admin user
                        var admin = new KonoFandomUser
                        {
                            UserName = "admin",
                            NormalizedUserName = "ADMIN",
                            EmailConfirmed = true,
                            Role = Role.Admin
                        };

                        var role = new IdentityRole
                        {
                            Name = Enum.GetName(typeof(Role), Role.Admin),
                            NormalizedName = Enum.GetName(typeof(Role), Role.Admin).ToUpper()
                        };

                        var userRole = new IdentityUserRole<string>()
                        {
                            UserId = admin.Id,
                            RoleId = role.Id
                        };

                        context.KonoFandomUser.Add(admin);
                        context.Roles.Add(role);
                        context.UserRoles.Add(userRole);
                        context.SaveChanges();

                        // Add moderator user
                        var mod = new KonoFandomUser
                        {
                            UserName = "mod",
                            NormalizedUserName = "MOD",
                            EmailConfirmed = true,
                            Role = Role.Moderator
                        };

                        role = new IdentityRole
                        {
                            Name = Enum.GetName(typeof(Role), Role.Moderator),
                            NormalizedName = Enum.GetName(typeof(Role), Role.Moderator).ToUpper()
                        };

                        userRole = new IdentityUserRole<string>()
                        {
                            UserId = mod.Id,
                            RoleId = role.Id
                        };

                        context.KonoFandomUser.Add(mod);
                        context.Roles.Add(role);
                        context.UserRoles.Add(userRole);
                        context.SaveChanges();

                        // Add a user
                        var user = new KonoFandomUser
                        {
                            UserName = "user",
                            NormalizedUserName = "USER",
                            EmailConfirmed = true,
                            Role = Role.User
                        };

                        role = new IdentityRole
                        {
                            Name = Enum.GetName(typeof(Role), Role.User),
                            NormalizedName = Enum.GetName(typeof(Role), Role.User).ToUpper()
                        };

                        userRole = new IdentityUserRole<string>()
                        {
                            UserId = mod.Id,
                            RoleId = role.Id
                        };

                        context.KonoFandomUser.Add(user);
                        context.Roles.Add(role);
                        context.UserRoles.Add(userRole);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
