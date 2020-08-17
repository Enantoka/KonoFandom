using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonoFandom.Models
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
                            FirstMidName = "Kazuma",
                            LastName = "Satou",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Aqua",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            FirstMidName = "Megumin",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            FirstMidName = "Darkness",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Wiz",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            FirstMidName = "Yunyun",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            FirstMidName = "Arue",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            FirstMidName = "Chris",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            FirstMidName = "Iris",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Cecily",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            FirstMidName = "Kyouya",
                            LastName = "Mitsurugi",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Dust",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Rin",
                            Weapon = Weapon.Staff
                        },

                        new Character
                        {
                            FirstMidName = "Lia",
                            Weapon = Weapon.Spear
                        },

                        new Character
                        {
                            FirstMidName = "Cielo",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            FirstMidName = "Erika",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            FirstMidName = "Melissa",
                            Weapon = Weapon.Dagger
                        },

                        new Character
                        {
                            FirstMidName = "Mia",
                            Weapon = Weapon.Spear
                        },

                        new Character
                        {
                            FirstMidName = "Amy",
                            Weapon = Weapon.Rod
                        }
                    );
                    context.SaveChanges();

                    context.Card.AddRange(
                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 1
                        },

                        new Card
                        {
                            Name = "Construction Site",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 1
                        },

                        new Card
                        {
                            Name = "Adventurer",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 1
                        },

                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 2
                        },

                        new Card
                        {
                            Name = "Construction Site",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 2
                        },

                        new Card
                        {
                            Name = "Arc Priest",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 2
                        },

                        new Card
                        {
                            Name = "Starter",
                            Rarity = 1,
                            ImagePath = "",
                            CharacterID = 1
                        },

                        new Card
                        {
                            Name = "Plain Clothed",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 1
                        },

                        new Card
                        {
                            Name = "Arc Wizard",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 3
                        }
                    );
                    context.SaveChanges();
                }
            } 
        }
    }
}
