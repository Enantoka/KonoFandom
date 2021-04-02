using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KonoFandom.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace KonoFandom.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult OnPostAsync()
        {
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
