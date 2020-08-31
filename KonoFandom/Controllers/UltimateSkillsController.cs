using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Models;

namespace KonoFandom.Controllers
{
    public class UltimateSkillsController : Controller
    {
        private readonly KonoFandomContext _context;

        public UltimateSkillsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: UltimateSkills
        public async Task<IActionResult> Index()
        {
            var konoFandomContext = _context.UltimateSkill.Include(u => u.Character);
            return View(await konoFandomContext.ToListAsync());
        }

        // GET: UltimateSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultimateSkill = await _context.UltimateSkill
                .Include(u => u.Character)
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (ultimateSkill == null)
            {
                return NotFound();
            }

            return View(ultimateSkill);
        }

        // GET: UltimateSkills/Create
        public IActionResult Create()
        {
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID");
            return View();
        }

        // POST: UltimateSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterID,SkillID,Name,Description,ImagePath")] UltimateSkill ultimateSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ultimateSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", ultimateSkill.CharacterID);
            return View(ultimateSkill);
        }

        // GET: UltimateSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultimateSkill = await _context.UltimateSkill.FindAsync(id);
            if (ultimateSkill == null)
            {
                return NotFound();
            }
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", ultimateSkill.CharacterID);
            return View(ultimateSkill);
        }

        // POST: UltimateSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterID,SkillID,Name,Description,ImagePath")] UltimateSkill ultimateSkill)
        {
            if (id != ultimateSkill.SkillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ultimateSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UltimateSkillExists(ultimateSkill.SkillID))
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
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", ultimateSkill.CharacterID);
            return View(ultimateSkill);
        }

        // GET: UltimateSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ultimateSkill = await _context.UltimateSkill
                .Include(u => u.Character)
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (ultimateSkill == null)
            {
                return NotFound();
            }

            return View(ultimateSkill);
        }

        // POST: UltimateSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ultimateSkill = await _context.UltimateSkill.FindAsync(id);
            _context.UltimateSkill.Remove(ultimateSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UltimateSkillExists(int id)
        {
            return _context.UltimateSkill.Any(e => e.SkillID == id);
        }
    }
}
