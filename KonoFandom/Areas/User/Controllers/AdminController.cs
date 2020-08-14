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
        public async Task<IActionResult> Edit(string id, [Bind("Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, " +
                                                      "SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, " +
                                                      "LockoutEnd, LockoutEnabled, AccessFailedCount")] KonoFandomUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is KonoFandomUser)
                        {
                            var proposedValues = entry.CurrentValues;
                            var dbValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                Console.WriteLine("CURRENT >>>>>" + proposedValues[property]);
                                Console.WriteLine("DB >>>>>> " + dbValues[property]);
                            }
                        }
                    }
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
        public async Task<IActionResult> Delete(string? id)
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
