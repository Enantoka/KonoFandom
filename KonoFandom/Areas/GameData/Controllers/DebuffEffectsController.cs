using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Models;
using KonoFandom.Areas.GameData.Models;

namespace KonoFandom.Areas.GameData.Controllers
{
    [Area("GameData")]
    public class DebuffEffectsController : Controller
    {
        private readonly KonoFandomContext _context;

        public DebuffEffectsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: DebuffEffects
        public async Task<IActionResult> Index()
        {
            return View(await _context.DebuffEffect.ToListAsync());
        }

        // GET: DebuffEffects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debuffEffect = await _context.DebuffEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (debuffEffect == null)
            {
                return NotFound();
            }

            return View(debuffEffect);
        }

        // GET: DebuffEffects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DebuffEffects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EffectID,Name,Description,ImagePath")] DebuffEffect debuffEffect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(debuffEffect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(debuffEffect);
        }

        // GET: DebuffEffects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debuffEffect = await _context.DebuffEffect.FindAsync(id);
            if (debuffEffect == null)
            {
                return NotFound();
            }
            return View(debuffEffect);
        }

        // POST: DebuffEffects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EffectID,Name,Description,ImagePath")] DebuffEffect debuffEffect)
        {
            if (id != debuffEffect.EffectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debuffEffect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebuffEffectExists(debuffEffect.EffectID))
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
            return View(debuffEffect);
        }

        // GET: DebuffEffects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var debuffEffect = await _context.DebuffEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (debuffEffect == null)
            {
                return NotFound();
            }

            return View(debuffEffect);
        }

        // POST: DebuffEffects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var debuffEffect = await _context.DebuffEffect.FindAsync(id);
            _context.DebuffEffect.Remove(debuffEffect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DebuffEffectExists(int id)
        {
            return _context.DebuffEffect.Any(e => e.EffectID == id);
        }
    }
}
