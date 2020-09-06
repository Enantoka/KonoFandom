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
    public class StatusEffectsController : Controller
    {
        private readonly KonoFandomContext _context;

        public StatusEffectsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: StatusEffects
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusEffect.ToListAsync());
        }

        // GET: StatusEffects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEffect = await _context.StatusEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (statusEffect == null)
            {
                return NotFound();
            }

            return View(statusEffect);
        }

        // GET: StatusEffects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusEffects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EffectID,Name,Description,ImagePath")] StatusEffect statusEffect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusEffect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusEffect);
        }

        // GET: StatusEffects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEffect = await _context.StatusEffect
                .Include(se => se.SkillStatusEffects)
                    .ThenInclude(se => se.Skill)
                    .FirstOrDefaultAsync(m => m.EffectID == id);

            if (statusEffect == null)
            {
                return NotFound();
            }
            PopulateSkillStatusEffectData(statusEffect);
            return View(statusEffect);
        }

        private void PopulateSkillStatusEffectData(StatusEffect statusEffect)
        {
            var skills = _context.Skill;
            var skillStatusEffects = new HashSet<int>(statusEffect.SkillStatusEffects.Select(s => s.SkillID));
            var viewModel = new List<AssignedStatusEffectData>();

            foreach (var skill in skills)
            {
                viewModel.Add(new AssignedStatusEffectData
                {
                    SkillID = skill.SkillID,
                    Name = skill.Name,
                    Assigned = skillStatusEffects.Contains(skill.SkillID)
                });
            }
            ViewData["Skills"] = viewModel;
        }

        // POST: StatusEffects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedSkills, [Bind("EffectID,Name,Description,ImagePath")] StatusEffect statusEffect)
        {
            if (id != statusEffect.EffectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusEffect);

                    // Update many to many relationship
                    var statusEffectToUpdate = await _context.StatusEffect
                                                .Include(se => se.SkillStatusEffects)
                                                    .ThenInclude(s => s.Skill)
                                                .FirstOrDefaultAsync(m => m.EffectID == id);

                    UpdateCardBasicSkills(selectedSkills, statusEffectToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusEffectExists(statusEffect.EffectID))
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
            return View(statusEffect);
        }

        private void UpdateCardBasicSkills(string[] selectedSkills, StatusEffect statusEffectToUpdate)
        {
            if (selectedSkills == null)
            {
                statusEffectToUpdate.SkillStatusEffects = new List<SkillStatusEffect>();
                return;
            }

            var selectedSkillHS = new HashSet<string>(selectedSkills);
            var skillStatusEffect = new HashSet<int>(statusEffectToUpdate.SkillStatusEffects.Select(s => s.Skill.SkillID));

            foreach (var skill in _context.Skill)
            {
                if (selectedSkillHS.Contains(skill.SkillID.ToString()))
                {
                    if (!skillStatusEffect.Contains(skill.SkillID))
                    {
                        statusEffectToUpdate.SkillStatusEffects.Add(new SkillStatusEffect
                        {
                            SkillID = skill.SkillID,
                            StatusEffectID = statusEffectToUpdate.EffectID
                        });
                    }
                }
                else
                {
                    if (skillStatusEffect.Contains(skill.SkillID))
                    {
                        SkillStatusEffect skillToRemove = statusEffectToUpdate.SkillStatusEffects.FirstOrDefault(s => s.SkillID == skill.SkillID);
                        _context.Remove(skillToRemove);
                    }
                }
            }
        }

        // GET: StatusEffects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusEffect = await _context.StatusEffect
                .FirstOrDefaultAsync(m => m.EffectID == id);
            if (statusEffect == null)
            {
                return NotFound();
            }

            return View(statusEffect);
        }

        // POST: StatusEffects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusEffect = await _context.StatusEffect.FindAsync(id);
            _context.StatusEffect.Remove(statusEffect);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusEffectExists(int id)
        {
            return _context.StatusEffect.Any(e => e.EffectID == id);
        }
    }
}
