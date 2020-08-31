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
    public class BasicSkillsController : Controller
    {
        private readonly KonoFandomContext _context;

        public BasicSkillsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: BasicSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasicSkill.ToListAsync());
        }

        // GET: BasicSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicSkill = await _context.BasicSkill
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (basicSkill == null)
            {
                return NotFound();
            }

            return View(basicSkill);
        }

        // GET: BasicSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasicSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillID,Name,Description,ImagePath")] BasicSkill basicSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basicSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basicSkill);
        }

        // GET: BasicSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicSkill = await _context.BasicSkill.FindAsync(id);
            if (basicSkill == null)
            {
                return NotFound();
            }
            return View(basicSkill);
        }

        // POST: BasicSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillID,Name,Description,ImagePath")] BasicSkill basicSkill)
        {
            if (id != basicSkill.SkillID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicSkillExists(basicSkill.SkillID))
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
            return View(basicSkill);
        }

        // GET: BasicSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicSkill = await _context.BasicSkill
                .FirstOrDefaultAsync(m => m.SkillID == id);
            if (basicSkill == null)
            {
                return NotFound();
            }

            return View(basicSkill);
        }

        // POST: BasicSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicSkill = await _context.BasicSkill.FindAsync(id);
            _context.BasicSkill.Remove(basicSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicSkillExists(int id)
        {
            return _context.BasicSkill.Any(e => e.SkillID == id);
        }
    }
}
