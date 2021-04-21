using KonoFandom.Models;
using System.Collections.Generic;

namespace KonoFandom.Areas.Admin.ViewModels
{
    // View Model for GET create in Cards controller
    public class CharacterViewModel
    {
        public Card Card;
        public IEnumerable<PassiveSkill> PassiveSkills;
        public IEnumerable<BasicSkill> BasicSkills;
    }
}
