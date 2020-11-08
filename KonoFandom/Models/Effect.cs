using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public abstract class Effect
    {
        [Display(Name = "ID")]
        public int EffectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Image URL")]
        public string ImagePath { get; set; }
    }
}
