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
    }
}
