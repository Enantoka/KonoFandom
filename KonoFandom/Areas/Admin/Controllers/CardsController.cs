using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Models;
using KonoFandom.Data;
using KonoFandom.Areas.Admin.ViewModels;

namespace KonoFandom.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class CardsController : Controller
    {
        private readonly KonoFandomContext _context;

        public CardsController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            var card = _context.Card;
            return View(await card.ToListAsync());
        }

        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.Character)
                .Include(c => c.PassiveSkill)
                .FirstOrDefaultAsync(m => m.CardID == id);

            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID");
            PopulateCardElementData2();

            var passiveSkills = _context.PassiveSkill;
            var basicSkills = _context.BasicSkill;

            CreateCardViewModel vm = new();
            vm.Card = new Card();
            vm.PassiveSkills = passiveSkills;
            vm.BasicSkills = basicSkills;

            return View(vm);
        }

        private void PopulateCardElementData2()
        {
            var elements = _context.Element;
            var cardElements = new HashSet<int>();
            var viewModel = new List<AssignedElementData>();

            foreach (var element in elements)
            {
                viewModel.Add(new AssignedElementData
                {
                    ElementID = element.ElementID,
                    Type = element.Name,
                    Assigned = cardElements.Contains(element.ElementID)
                });
            }
            ViewData["Elements"] = viewModel;
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string[] selectedElements, [Bind("CardID, Name, Rarity, RarityImagePath, Weapon, ImagePath, " +
                                                      "CharacterID, PassiveSkillID, HealthPoints, PhysicalAttack," +
                                                      "MagicAttack, PhysicalDefense, MagicDefense, Agility," +
                                                      "Dexterity, Luck, FireResistance, WaterResistance," +
                                                      "LightningResistance, EarthResistance, WindResistance," +
                                                      "LightResistance, DarkResistance")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();

                ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", card.CharacterID);

                // Update many to many relationship
                var cardToUpdate = await _context.Card
                                    .Include(c => c.CardElements)
                                        .ThenInclude(c => c.Element)
                                    .FirstOrDefaultAsync(m => m.CardID == card.CardID);

                UpdateCardElements(selectedElements, cardToUpdate);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                        .Include(c => c.PassiveSkill)
                        .Include(c => c.CardElements)
                            .ThenInclude(c => c.Element)
                        .FirstOrDefaultAsync(m => m.CardID == id);
            var passiveSkills = _context.PassiveSkill;

            if (card == null)
            {
                return NotFound();
            }
            ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", card.CharacterID);
            //ViewData["PassiveSkillID"] = new SelectList(_context.PassiveSkill, "SkillID", "SkillID", card.PassiveSkillID);
            PopulateCardElementData(card);

            CreateCardViewModel vm = new();
            vm.Card = card;
            vm.PassiveSkills = passiveSkills;

            return View(vm);
        }

        private void PopulateCardElementData(Card card)
        {
            var elements = _context.Element;
            var cardElements = new HashSet<int>(card.CardElements.Select(e => e.ElementID));
            var viewModel = new List<AssignedElementData>();

            foreach (var element in elements)
            {
                viewModel.Add(new AssignedElementData
                {
                    ElementID = element.ElementID,
                    Type = element.Name,
                    Assigned = cardElements.Contains(element.ElementID)
                });
            }
            ViewData["Elements"] = viewModel;
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedElements, 
                [Bind("CardID, Name, Rarity, RarityImagePath, Weapon, ImagePath, " +
                "CharacterID, PassiveSkillID, HealthPoints, PhysicalAttack," +
                "MagicAttack, PhysicalDefense, MagicDefense, Agility," +
                "Dexterity, Luck, FireResistance, WaterResistance," +
                "LightningResistance, EarthResistance, WindResistance," +
                "LightResistance, DarkResistance")] Card card)
        {
            if (id != card.CardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);

                    // Update many to many relationship
                    var cardToUpdate = await _context.Card
                                        .Include(c => c.CardElements)
                                            .ThenInclude(c => c.Element)
                                        .FirstOrDefaultAsync(m => m.CardID == id);

                    UpdateCardElements(selectedElements, cardToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.CardID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["CharacterID"] = new SelectList(_context.Character, "CharacterID", "CharacterID", card.CharacterID);
                //ViewData["PassiveSkillID"] = new SelectList(_context.PassiveSkill, "SkillID", "SkillID", card.PassiveSkillID);

                return RedirectToAction(nameof(Index));
            }
            return BadRequest(ModelState);
        }

        private void UpdateCardElements(string[] selectedElements, Card cardToUpdate)
        {
            if (selectedElements == null)
            {
                cardToUpdate.CardElements = new List<CardElement>();
                return;
            }

            var selectedElementsHS = new HashSet<string>(selectedElements);
            var cardElements = new HashSet<int>(cardToUpdate.CardElements.Select(e => e.Element.ElementID));

            foreach (var element in _context.Element)
            {
                if (selectedElementsHS.Contains(element.ElementID.ToString()))
                {
                    if (!cardElements.Contains(element.ElementID))
                    {
                        cardToUpdate.CardElements.Add(new CardElement
                        {
                            ElementID = element.ElementID,
                            CardID = cardToUpdate.CardID
                        });
                    }
                }
                else
                {
                    if (cardElements.Contains(element.ElementID))
                    {
                        CardElement elementToRemove = cardToUpdate.CardElements.FirstOrDefault(e => e.ElementID == element.ElementID);
                        _context.Remove(elementToRemove);
                    }
                }
            }
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.Character)
                .Include(c => c.PassiveSkill)
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var card = await _context.Card.FindAsync(id);
            _context.Card.Remove(card);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.CardID == id);
        }
    }
}
