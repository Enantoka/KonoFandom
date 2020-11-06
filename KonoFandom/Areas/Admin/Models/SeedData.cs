using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonoFandom.Data;
using KonoFandom.Models;

namespace KonoFandom.Areas.Admin.Models
{
    public class SeedData
    {
        public static void Intialize(IServiceProvider serviceProvider)
        {
            using (var context = new KonoFandomContext(serviceProvider.GetRequiredService<DbContextOptions<KonoFandomContext>>()))
            {
                if (!context.Character.Any())
                {
                    context.Character.AddRange(
                        new Character
                        {
                            CharacterID = 1,
                            Name = "Kazuma",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            CharacterID = 2,
                            Name = "Aqua",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            CharacterID = 3,
                            Name = "Megumin",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            CharacterID = 4,
                            Name = "Darkness",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            CharacterID = 5,
                            Name = "Wiz",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            CharacterID = 6,
                            Name = "Yunyun",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            CharacterID = 7,
                            Name = "Arue",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            CharacterID = 8,
                            Name = "Chris",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            CharacterID = 9,
                            Name = "Iris",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            CharacterID = 10,
                            Name = "Cecily",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            CharacterID = 11,
                            Name = "Mitsurugi",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            CharacterID = 12,
                            Name = "Dust",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            CharacterID = 13,
                            Name = "Rin",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            CharacterID = 14,
                            Name = "Lia",
                            Weapon = Weapon.Spear
                        },

                        new Character
                        {
                            CharacterID = 15,
                            Name = "Cielo",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            CharacterID = 16,
                            Name = "Erika",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            CharacterID = 17,
                            Name = "Melissa",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            CharacterID = 18,
                            Name = "Mia",
                            Weapon = Weapon.Spear
                        },

                        new Character
                        {
                            CharacterID = 19,
                            Name = "Amy",
                            Weapon = Weapon.Rod
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Skill.Any())
                {
                    context.AddRange(
                        new UltimateSkill
                        {
                            Name = "Ult1",
                            Description = "Desc1",
                            CharacterID = 1
                        },

                        new UltimateSkill
                        {
                            Name = "Ult2",
                            Description = "Desc2",
                            CharacterID = 2
                        },

                        new UltimateSkill
                        {
                            Name = "Ult3",
                            Description = "Desc3",
                            CharacterID = 3
                        },

                        new PassiveSkill
                        {
                            Name = "Passive1",
                            Description = "Desc1"
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.BasicSkill.Any())
                {
                    context.BasicSkill.AddRange(
                        new BasicSkill
                        {
                            Name = "Basic1",
                            Description = "Desc1"
                        }
                    );
                    context.SaveChanges();

                    context.CardBasicSkill.AddRange(
                        new CardBasicSkill
                        {
                            CardID = 1,
                            BasicSkillID = 1
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Card.Any())
                {
                    context.Card.AddRange(
                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 1,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Construction Site",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 1,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Adventurer",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 1,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 2,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Construction Site",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 2,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Arc Priest",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 2,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 3,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Plain Clothed",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 3,
                            PassiveSkillID = 1
                        },

                        new Card
                        {
                            Name = "Arc Wizard",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 3,
                            PassiveSkillID = 1
                        }
                    );
                    context.SaveChanges();
                }
            } 
        }
    }
}
