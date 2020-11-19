using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.ViewModels
{
    // View Model for GET details in Characters controller
    public class CardIndex
    {
        public IEnumerable<Card> Cards;

        public IEnumerable<Character> Characters;

        public IEnumerable<Element> Elements;
    }
}
