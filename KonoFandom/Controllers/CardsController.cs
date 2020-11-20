using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Data;
using KonoFandom.ViewModels;

namespace KonoFandom.Controllers
{
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
            var cards = await _context.Card
                .Include(c => c.PassiveSkill)
                .Include(c => c.CardBasicSkills)
                    .ThenInclude(c => c.BasicSkill)
                .Include(c => c.CardElements)
                .ToListAsync();
            var characters = await _context.Character.ToListAsync();
            var elements = await _context.Element.ToListAsync();

            CardIndex ci = new CardIndex();
            ci.Cards = cards;
            ci.Characters = characters;
            ci.Elements = elements;

            return View(ci);
        }
    }
}
