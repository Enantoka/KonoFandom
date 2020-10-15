using KonoFandom.Areas.GameData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.PageModels
{
    // View Model for GET details in Characters controller
    public class CharacterDetails
    {
        public Character Character;

        public IEnumerable<Character> Characters;
    }
}
