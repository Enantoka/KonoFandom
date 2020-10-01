using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Areas.GameData.Models
{
    public class CardElement
    {
        public int CardID { get; set; }
        public Card Card { get; set; }
        public int ElementID { get; set; }
        public Element Element { get; set; }
    }
}
