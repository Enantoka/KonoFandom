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
            using (var context = new KonoFandomContext(serviceProvider.GetRequiredService <DbContextOptions<KonoFandomContext>>()))
            {
                if (context.Character.Any())
                {
                    return; // Db Seeded
                }
                else
                {
                    context.Character.AddRange(
                        new Character
                        {
                            FirstMidName = "Kazuma",
                            LastName = "Satou",
                            Biography = "1",
                            Weapon = Weapon.Sword
                        },

                        new Character
                        {
                            FirstMidName = "Aqua",
                            LastName = "",
                            Biography = "2",
                            Weapon = Weapon.Rod
                        },

                        new Character
                        {
                            FirstMidName = "Megumin",
                            LastName = "",
                            Biography = "3",
                            Weapon = Weapon.Staff
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
