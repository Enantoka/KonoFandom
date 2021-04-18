using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.Admin.ViewModels
{
    // View Model for GET create in Cards controller
    public class CardCreate
    {
        public Card Card;

        public IEnumerable<PassiveSkill> PassiveSkills;
    }
}
