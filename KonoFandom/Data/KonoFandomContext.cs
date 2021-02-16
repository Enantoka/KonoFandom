using KonoFandom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Data
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
        public DbSet<Effect> Effect { get; set; }
        public DbSet<BuffEffect> BuffEffect { get; set; }
        public DbSet<DebuffEffect> DebuffEffect { get; set; }
        public DbSet<StatusEffect> StatusEffect { get; set; }
        public DbSet<SkillStatusEffect> SkillStatusEffect { get; set; }
        public DbSet<Element> Element { get; set; }
        public DbSet<CardElement> CardElement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardBasicSkill>()
                .HasKey(cbs => new { cbs.CardID, cbs.BasicSkillID });
            modelBuilder.Entity<CardElement>()
                .HasKey(ce => new { ce.CardID, ce.ElementID });
            modelBuilder.Entity<SkillStatusEffect>()
                .HasKey(sse => new { sse.SkillID, sse.StatusEffectID });

            modelBuilder.Entity<PassiveSkill>()
                .HasMany(c => c.Cards)
                .WithOne(p => p.PassiveSkill)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
