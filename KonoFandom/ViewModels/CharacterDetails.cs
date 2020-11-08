using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.ViewModels
{
    // View Model for GET details in Characters controller
    public class CharacterDetails
    {
        public Character Character;

        public IEnumerable<Character> Characters;
    }
}
