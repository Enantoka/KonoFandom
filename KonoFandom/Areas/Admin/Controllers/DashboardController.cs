using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KonoFandom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class DashboardController : Controller
    {
        // GET: DashboardController
        public IActionResult Index()
        {
            return View();
        }
    }
}
