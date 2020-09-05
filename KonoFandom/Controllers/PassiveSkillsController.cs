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
    public class PassiveSkillsController : Controller
    {
        private readonly KonoFandomContext _context;

        public PassiveSkillsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: PassiveSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.PassiveSkill.ToListAsync());
        }

        // GET: PassiveSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passiveSkill = await _context.PassiveSkill
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (passiveSkill == null)
            {
                return NotFound();
            }

            return View(passiveSkill);
        }

        // GET: PassiveSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PassiveSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillID,Name,Description,ImagePath")] PassiveSkill passiveSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passiveSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passiveSkill);
        }

        // GET: PassiveSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passiveSkill = await _context.PassiveSkill.FindAsync(id);
            if (passiveSkill == null)
            {
                return NotFound();
            }
            return View(passiveSkill);
        }

        // POST: PassiveSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillID,Name,Description,ImagePath")] PassiveSkill passiveSkill)
        {
            if (id != passiveSkill.SkillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passiveSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassiveSkillExists(passiveSkill.SkillID))
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
            return View(passiveSkill);
        }

        // GET: PassiveSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passiveSkill = await _context.PassiveSkill
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (passiveSkill == null)
            {
                return NotFound();
            }

            return View(passiveSkill);
        }

        // POST: PassiveSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passiveSkill = await _context.PassiveSkill.FindAsync(id);
            _context.PassiveSkill.Remove(passiveSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassiveSkillExists(int id)
        {
            return _context.PassiveSkill.Any(e => e.SkillID == id);
        }
    }
}
