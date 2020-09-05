using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class BuffEffect : Effect
    {
        public ICollection<Skill> Skills { get; set; }
    }
}
