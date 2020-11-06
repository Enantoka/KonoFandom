using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class Element
    {
        public int ElementID { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }
        public ICollection<CardElement> CardElements { get; set; }
    }
}
