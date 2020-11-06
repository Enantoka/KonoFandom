using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Models;
using KonoFandom.Areas.GameData.Models;
using KonoFandom.Areas.GameData.PageModels;

namespace KonoFandom.Controllers
{
    public class CharactersController : Controller
    {
        private readonly KonoFandomContext _context;

        public CharactersController(KonoFandomContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Character.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Cards)
                    .ThenInclude(c => c.PassiveSkill)
                .Include(c => c.Cards)
                    .ThenInclude(c => c.CardBasicSkills)
                    .ThenInclude(c => c.BasicSkill)
                .Include(c => c.UltimateSkill)
                .FirstOrDefaultAsync(m => m.CharacterID == id);

            if (character == null)
            {
                return NotFound();
            }

            CharacterDetails cdvm = new CharacterDetails();
            cdvm.Character = character;
            cdvm.Characters = await _context.Character.OrderBy(c => c.CharacterID).ToListAsync();

            return View(cdvm);
        }
    }
}
