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
using Microsoft.AspNetCore.Authorization;
using KonoFandom.Models;

namespace KonoFandom.Areas.Admin.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminController : Controller
    {
        private readonly UserManager<KonoFandomUser> _userManager;
        private readonly IdentityContext _identityContext;
        private readonly KonoFandomContext _konoFandomContext;

        public AdminController(UserManager<KonoFandomUser> userManager, IdentityContext identityContext, KonoFandomContext konoFandomContext)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _konoFandomContext = konoFandomContext;
        }

        // GET: AdminController
        public async Task<IActionResult> Index()
        {
            AllViewModel allViewModel = new AllViewModel();
            allViewModel.Users = await _identityContext.KonoFandomUser.ToListAsync();
            allViewModel.Characters = await _konoFandomContext.Character.ToListAsync();
            allViewModel.Cards = await _konoFandomContext.Card.ToListAsync();
            allViewModel.BasicSkills = await _konoFandomContext.BasicSkill.ToListAsync();
            allViewModel.PassiveSkills = await _konoFandomContext.PassiveSkill.ToListAsync();
            allViewModel.UltimateSkills = await _konoFandomContext.UltimateSkill.ToListAsync();
            allViewModel.BuffEffects = await _konoFandomContext.BuffEffect.ToListAsync();
            allViewModel.DebuffEffects = await _konoFandomContext.DebuffEffect.ToListAsync();
            allViewModel.StatusEffects = await _konoFandomContext.StatusEffect.ToListAsync();
            allViewModel.Elements = await _konoFandomContext.Element.ToListAsync();
            return View(allViewModel);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminController/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.KonoFandomUser
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminController/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
                //await _userManager.CreateAsync(user, user.PasswordHash);
                user.PasswordHash = new PasswordHasher<KonoFandomUser>().HashPassword(user, user.PasswordHash);
                _identityContext.KonoFandomUser.Add(user);
                await _identityContext.SaveChangesAsync();

                // Assign user a role
                await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(Role), user.Role));

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // GET: AdminController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.KonoFandomUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        // GET: AdminController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _identityContext.KonoFandomUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if ( user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        // POST: AdminController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _identityContext.KonoFandomUser.FindAsync(id);
            _identityContext.KonoFandomUser.Remove(user);
            await _identityContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _identityContext.KonoFandomUser.Any(e => e.Id == id);
        }
    }
}
