using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonoFandom.Data;

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
            var konoFandomContext = _context.Card.Include(c => c.Character).Include(c => c.PassiveSkill);
            return View(await konoFandomContext.ToListAsync());
        }

        // GET: Cards/Details/5
        /*public async Task<IActionResult> Details(int? id)
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
        }*/
    }
}
