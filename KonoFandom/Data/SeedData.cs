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
                            CharacterID = 3
                        },

                        new Card
                        {
                            Name = "Plain Clothed",
                            Rarity = 2,
                            ImagePath = "",
                            CharacterID = 3
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
