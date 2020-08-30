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
        public DbSet<Skill> Skill { get; set; }
        public DbSet<BasicSkill> BasicSkill { get; set; }
        public DbSet<CardBasicSkill> CardBasicSkill { get; set; }
        public DbSet<PassiveSkill> PassiveSkill { get; set; }
        public DbSet<UltimateSkill> UltimateSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardBasicSkill>()
                .HasKey(cbs => new { cbs.CardID, cbs.BasicSkillID });
        }
    }
}
