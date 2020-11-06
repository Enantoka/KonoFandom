using KonoFandom.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.Admin.Data
{
    public class RoleCreator
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (string r in Enum.GetNames(typeof(Role)))
            {
                if (!await RoleManager.RoleExistsAsync(r))
                {
                    IdentityResult result = RoleManager.CreateAsync(new IdentityRole(r)).Result;

                    if (result.Succeeded)
                    {
                        await RoleManager.CreateAsync(new IdentityRole(r));
                    }
                }
            }
        }
    }
}
