using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.Identity.Data
{
    public class RoleCreator
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            IdentityResult roleResult;

            foreach (string r in Enum.GetNames(typeof(Role)))
            {
                if (!await RoleManager.RoleExistsAsync(r))
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(r));
                }
            }
        }
    }
}
