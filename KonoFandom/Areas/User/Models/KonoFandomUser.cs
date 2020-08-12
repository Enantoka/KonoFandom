using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KonoFandom.Areas.Identity.Data
{
    // If required, add more roles here.
    public enum Role
    {
        Admin, Moderator
    }

    // Add profile data for application users by adding properties to the KonoFandomUser class
    public class KonoFandomUser : IdentityUser
    {
        //[Required]
        //[EnumDataType(typeof(Role))]
        //public Role Role { get; set; }
    }
}
