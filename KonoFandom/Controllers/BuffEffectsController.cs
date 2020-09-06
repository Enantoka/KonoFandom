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
    public class BuffEffectsController : Controller
    {
        private readonly KonoFandomContext _context;

        public BuffEffectsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: BuffEffects
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuffEffect.ToListAsync());
        }

        // GET: BuffEffects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffEffect = await _context.BuffEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (buffEffect == null)
            {
                return NotFound();
            }

            return View(buffEffect);
        }

        // GET: BuffEffects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuffEffects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EffectID,Name,Description,ImagePath")] BuffEffect buffEffect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buffEffect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buffEffect);
        }

        // GET: BuffEffects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffEffect = await _context.BuffEffect.FindAsync(id);
            if (buffEffect == null)
            {
                return NotFound();
            }
            return View(buffEffect);
        }

        // POST: BuffEffects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EffectID,Name,Description,ImagePath")] BuffEffect buffEffect)
        {
            if (id != buffEffect.EffectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buffEffect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuffEffectExists(buffEffect.EffectID))
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
            return View(buffEffect);
        }

        // GET: BuffEffects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buffEffect = await _context.BuffEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (buffEffect == null)
            {
                return NotFound();
            }

            return View(buffEffect);
        }

        // POST: BuffEffects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buffEffect = await _context.BuffEffect.FindAsync(id);
            _context.BuffEffect.Remove(buffEffect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuffEffectExists(int id)
        {
            return _context.BuffEffect.Any(e => e.EffectID == id);
        }
    }
}
