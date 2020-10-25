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
        public async Task<IActionResult> Create([Bind("SkillID,Name,Description,ImagePath,Cooldown")] BasicSkill basicSkill)
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

            var basicSkill = await _context.BasicSkill
                .Include(bs => bs.CardBasicSkills)
                    .ThenInclude(bs => bs.Card)
                .FirstOrDefaultAsync(m => m.SkillID == id);

            if (basicSkill == null)
            {
                return NotFound();
            }
            PopulateCardBasicSkillData(basicSkill);
            return View(basicSkill);
        }

        private void PopulateCardBasicSkillData(BasicSkill basicSkill)
        {
            var allCards = _context.Card;
            var cardBasicSkills = new HashSet<int>(basicSkill.CardBasicSkills.Select(c => c.CardID));
            var viewModel = new List<AssignedBasicSkillData>();
            
            foreach (var card in allCards)
            {
                viewModel.Add(new AssignedBasicSkillData
                {
                    CardID = card.CardID,
                    Name = card.Name,
                    Assigned = cardBasicSkills.Contains(card.CardID)
                });
            }
            ViewData["Cards"] = viewModel;
        }

        // POST: BasicSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedCards, [Bind("SkillID,Name,Description,ImagePath,Cooldown")] BasicSkill basicSkill)
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

                    // Update many to many relationship
                    var skillToUpdate = await _context.BasicSkill
                                        .Include(bs => bs.CardBasicSkills)
                                            .ThenInclude(bs => bs.Card)
                                        .FirstOrDefaultAsync(m => m.SkillID == id);

                    UpdateCardBasicSkills(selectedCards, skillToUpdate);
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

        private void UpdateCardBasicSkills(string[] selectedCards, BasicSkill basicSkillToUpdate)
        {
            if (selectedCards == null)
            {
                basicSkillToUpdate.CardBasicSkills = new List<CardBasicSkill>();
                return;
            }

            var selectedCardsHS = new HashSet<string>(selectedCards);
            var cardBasicSkills = new HashSet<int>(basicSkillToUpdate.CardBasicSkills.Select(c => c.Card.CardID));

            foreach (var card in _context.Card)
            {
                if (selectedCardsHS.Contains(card.CardID.ToString()))
                {
                    if (!cardBasicSkills.Contains(card.CardID))
                    {
                        basicSkillToUpdate.CardBasicSkills.Add(new CardBasicSkill
                        {
                            CardID = card.CardID,
                            BasicSkillID = basicSkillToUpdate.SkillID
                        });
                    }
                }
                else
                {
                    if (cardBasicSkills.Contains(card.CardID))
                    {
                        CardBasicSkill cardToRemove = basicSkillToUpdate.CardBasicSkills.FirstOrDefault(c => c.CardID == card.CardID);
                        _context.Remove(cardToRemove);
                    }
                }
            }
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
