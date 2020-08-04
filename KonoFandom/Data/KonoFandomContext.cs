using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
{
    public class KonoFandomContext : DbContext
    {
        public KonoFandomContext(DbContextOptions<KonoFandomContext> options) : base(options)
        { 
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Card> Card { get; set; }
    }
}
