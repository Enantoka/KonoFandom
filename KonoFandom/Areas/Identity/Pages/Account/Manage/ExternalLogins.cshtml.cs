using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonoFandom.Areas.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KonoFandom.Areas.Identity.Pages.Account.Manage
{
    public class ExternalLoginsModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult OnPostRemoveLogin()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult OnPostLinkLogin()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult OnGetLinkLoginCallback()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
