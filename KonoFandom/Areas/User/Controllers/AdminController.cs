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
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.KonoFandomUser
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
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
                                                      "LockoutEnd, LockoutEnabled, AccessFailedCount, Role")] KonoFandomUser user)
        {
            if (ModelState.IsValid)
            {
                // Create new user
                await _userManager.CreateAsync(user, new PasswordHasher<KonoFandomUser>().HashPassword(user, user.PasswordHash));

                // Assign user a role
                await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(Role), user.Role));

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: AdminController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.KonoFandomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, int role, [Bind("Id, UserName, NormalizedUserName, Email, NormalizedEmail, " +
                                                      "EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed" +
                                                      ", TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, Role")] KonoFandomUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbUser = await _userManager.FindByIdAsync(id);

                    // Remove existing role from user
                    await _userManager.RemoveFromRoleAsync(dbUser, Enum.GetName(typeof(Role), dbUser.Role));

                    // Assign user a role
                    dbUser.Role = user.Role;
                    await _userManager.AddToRoleAsync(dbUser, Enum.GetName(typeof(Role), user.Role));

                    // Update required fields
                    await _userManager.SetUserNameAsync(dbUser, user.UserName);
                    await _userManager.SetEmailAsync(dbUser, user.Email);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: AdminController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.KonoFandomUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: AdminController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.KonoFandomUser.FindAsync(id);
            _context.KonoFandomUser.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.KonoFandomUser.Any(e => e.Id == id);
        }
    }
}
