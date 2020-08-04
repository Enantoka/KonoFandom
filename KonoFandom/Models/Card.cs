using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class Card
    {
        public int CardID { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(1,5)]
        public int Rarity { get; set; }

        public string ImagePath { get; set; }

        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
