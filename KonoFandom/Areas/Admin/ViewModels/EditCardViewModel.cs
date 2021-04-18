using KonoFandom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.Admin.ViewModels
{
    // View Model for GET edit in Cards controller
    public class EditCardViewModel
    {
        public IEnumerable<Card> Cards;
        public IEnumerable<PassiveSkill> PassiveSkills;
    }
}
