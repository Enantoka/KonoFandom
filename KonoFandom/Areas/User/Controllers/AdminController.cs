using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonoFandom.Areas.User.Models;
using KonoFandom.Areas.User.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;

namespace KonoFandom.Areas.Admin.Controllers
{
    [Area("User")]
    public class AdminController : Controller
    {
        private readonly UserManager<KonoFandomUser> _userManager;
        private readonly IdentityContext _context;

        public AdminController(UserManager<KonoFandomUser> userManager, IdentityContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: AdminController
        public IActionResult Index()
        {
            _context.KonoFandomUser.ToList();
            //var users = _userManager.Users;
            return View(_context.KonoFandomUser.ToList());
        }

        // GET: AdminController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, " +
                                                      "SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, " +
                                                      "LockoutEnd, LockoutEnabled, AccessFailedCount")] KonoFandomUser user)
        {
            if (ModelState.IsValid)
            {
                user.PasswordHash = new PasswordHasher<KonoFandomUser>().HashPassword(user, user.PasswordHash);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: AdminController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
