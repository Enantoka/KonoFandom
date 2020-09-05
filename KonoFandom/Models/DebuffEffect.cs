using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class DebuffEffect : Effect
    {
        public ICollection<Skill> Skills { get; set; }
    }
}
