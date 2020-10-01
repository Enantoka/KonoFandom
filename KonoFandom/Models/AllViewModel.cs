﻿using KonoFandom.Areas.GameData.Models;
using KonoFandom.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class AllViewModel
    {
        public IEnumerable<KonoFandomUser> Users;
        public IEnumerable<Character> Characters;
        public IEnumerable<Card> Cards;
        public IEnumerable<BasicSkill> BasicSkills;
        public IEnumerable<PassiveSkill> PassiveSkills;
        public IEnumerable<UltimateSkill> UltimateSkills;
        public IEnumerable<BuffEffect> BuffEffects;
        public IEnumerable<DebuffEffect> DebuffEffects;
        public IEnumerable<StatusEffect> StatusEffects;
        public IEnumerable<Element> Elements;
    }
}
