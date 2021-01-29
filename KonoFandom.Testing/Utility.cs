using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using KonoFandom.Models;

namespace KonoFandom.Data {
    public class Utility
    {
        private static readonly object _lock = new object();
        public static void Intialize(IServiceProvider serviceProvider)
        {
            using (var context = new KonoFandomContext(serviceProvider.GetRequiredService<DbContextOptions<KonoFandomContext>>()))
            {
                string query;

                lock (_lock) {

                    // Add characters
                    if (!context.Character.Any())
                    {
                        context.Character.AddRange(
                            new Character
                            {
                                Name = "Kazuma",
                                CharacterVoice = "Fukushima Jun",
                                Birthday = new DateTime(2020, 6, 7),
                                Biography = "A boy reincarnated from Japan who originally was a shut-in " +
                                "that loves games. He has the worst job - an adventurer, but with his high " +
                                "luck stats, quick-wittedness and strength of his comrades he stands evenly " +
                                "matched when contending against the Demon Army Generals.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1fImzqGmYvNJwpq1f2XdokNHttKhzLdUC",
                                CharacterImagePath = "https://drive.google.com/uc?export=view&id=1ZPreciFaaJ_aZ8G16uL6kvrgFFyAcfZS"
                            },

                            new Character
                            {
                                Name = "Aqua",
                                CharacterVoice = "Amamiya Sora",
                                Birthday = new DateTime(2020, 8, 1),
                                Biography = "A goddess that was brought along as part of Kazuma’s reincarnation " +
                                "privileges. Her job is an arch priest. Majority of her abilities have high " +
                                "stats however, her intelligence is below average, she has the worst luck " +
                                "stats and often draws the short end of the stick. She’s also good at " +
                                "performing party tricks.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1mlaNGcRJvZmbyc5K7FjqcJQaEsHbkKk3",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Megumin",
                                CharacterVoice = "Takahashi Rie",
                                Birthday = new DateTime(2020, 12, 4),
                                Biography = "A sorceress of the Crimson Demon Clan that is innate with " +
                                "extremely high magical abilities and intelligence. Her job is an arch " +
                                "wizard. She is a user of explosion magic - the strongest offensive magic. " +
                                "She’s unable to use any other magic.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1sIOiljhk7XQcEvbgphbM8THePBDbWRYw",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Darkness",
                                CharacterVoice = "Kayano Ai",
                                Birthday = new DateTime(2020, 4, 6),
                                Biography = "A beautiful looking crusader with blonde hair and blue eyes. " +
                                "Her defensive abilities are extremely high however, she’s a very " +
                                "masochistic tank who enjoys taking attacks. In reality, she’s the " +
                                "daughter of the Dustiness household, a noble family.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1Zw1POgT1WWwbPWpOyRFQwo004E1Fdgsc",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Wiz",
                                CharacterVoice = "Horie Yui",
                                Birthday = new DateTime(),
                                Biography = "A woman who sells magic tools in Axel Town. She’s a hard worker, " +
                                "but is misfortunate as she becomes poorer the more she works. In fact she’s " +
                                "a lich, king of the undead, that is one of the Demon Army Generals.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1vV5dnwuHPUNeAaLbhqsJgD_KOhqoHoas",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Yunyun",
                                CharacterVoice = "Toyosaki Aki",
                                Birthday = new DateTime(2020, 2, 29),
                                Biography = "An arch wizard that is Megumin’s self-proclaimed rival. " +
                                "She’s a rare case with common sense within the Crimson Demon Clan " +
                                "where many possess chuunibyou behaviour. However, she has no " +
                                "friends and is constantly looking for friends.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1de9b8zMRdRZ1oRRgGzO1FBRHDX43qpRQ",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Arue",
                                CharacterVoice = "Nazuka Kaori",
                                Birthday = new DateTime(2020, 3, 28),
                                Biography = "A classmate of Megumin and Yunyun with a job as an arch wizard. " +
                                "With an ambition of becoming a novelist she writes questionable manuscripts " +
                                "and sends profound letters to Megumin and Yunyun.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1nhvG7ZtmnZ7xnhSdRVLvXfn0BJdbjxdw",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Chris",
                                CharacterVoice = "Suwa Ayaka",
                                Birthday = new DateTime(2020, 12, 25),
                                Biography = "A girl with silver hair and is Darkness’ friend. Her job " +
                                "is a thief and she teaches Kazuma various thief skills such as steal " +
                                "and bind. However, because of this relationship her underwear gets " +
                                "stolen time after time.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1xdpvV663ww7D2k0ZsijFzn2rwg44pVju",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Iris",
                                CharacterVoice = "Takao Kanon",
                                Birthday = new DateTime(2020, 9, 6),
                                Biography = "A princess of the Belzerg Kingdom. She possesses knowledge " +
                                "and elegance befitting of royalty, but has an innocent side as she is " +
                                "fascinated by commoner’s food and is intrigued by Kazuma’s stories.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=187Ypa5VgVj3xPEn2Z_ZzIj5TxnPrdqp1",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Cecily",
                                CharacterVoice = "Fairouz Ai",
                                Birthday = new DateTime(2020, 1, 12),
                                Biography = "A believer of the Axis Order and self-proclaimed beautiful priest. " +
                                "She has very strong beliefs and is free-spirited. She has a weakness for " +
                                "beautiful looking men and women and enjoys making Megumin call her “Onee-san”.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1uPxlyahDOc83lInGfW-pC58wEtk-EwWu",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Mitsurugi",
                                CharacterVoice = "Eguchi Takuya",
                                Birthday = new DateTime(2020, 6, 6),
                                Biography = "A man who reincarnated from Japan as a sword master. " +
                                "He reveres Aqua and devotes everyday to become a hero befitting " +
                                "her however, she seems to never remember his name.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1nqkq1tIZhQpD2ro78jwfr98J5wj71ZXx",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Dust",
                                CharacterVoice = "Majima Junji",
                                Birthday = new DateTime(2020, 9, 28),
                                Biography = "A man in Axel Town whose job is a fighter. He’s well " +
                                "known as a hoodlum who picks fights with new adventurers, dine " +
                                "and dash and blows all his borrowed funds in gambling.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1M7DsLyRBAl7PgU1AZGywTeNOs8bY-LjW",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Rin",
                                CharacterVoice = "Hanamori Yumiri",
                                Birthday = new DateTime(2020, 10, 6),
                                Biography = "A wizard who graduated from a magic academy as an " +
                                "orthodox magic user and can use intermediate magic. She’s in " +
                                "a party with Dust. She’s also a hard worker who’s often " +
                                "manipulated by the troublemaker Dust.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1J4Xeq2SJguR72-nc21G_5OCtDyOW5eOz",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Lia",
                                CharacterVoice = "Kawase Maki",
                                Birthday = new DateTime(2020, 7, 4),
                                Biography = "A lancer who’s good at singing and is also the leader " +
                                "of the dance group - Axel Hearts. She’s a hard worker with a " +
                                "serious demeanor, but at times can be careless. She treasures " +
                                "her stuffed doll - Koujirou.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1zJznBPKznE4WYYO6CgzQ3tbGaQQFE40e",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Cielo",
                                CharacterVoice = "Isobe Karin",
                                Birthday = new DateTime(2020, 11, 19),
                                Biography = "An arch priest who’s good at dancing and is also a member " +
                                "of the dance group - Axel Hearts. She’s shy and indecisive, but " +
                                "because of her androphobia when touched by men she hits them on reflex.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=12vBF-Tn5DBE7dQQBf2Dga-LgxM4pDl7P",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Erika",
                                CharacterVoice = "Narumi Runa",
                                Birthday = new DateTime(2020, 5, 17),
                                Biography = "A ranger who’s obsessed with being cute and is also a " +
                                "member of the dance group - Axel Hearts. She’s egotistic and does " +
                                "things at her own pace, but easily gets carried away when praised.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1_UMl1OVRpfN5N9PDQvNm8Lg0686vLPTf",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Melissa",
                                CharacterVoice = "Takano Marika",
                                Birthday = new DateTime(2020, 10, 28),
                                Biography = "She’s seductive yet well known for being an outstanding " +
                                "treasure hunter. She’s always looking down on others and is prideful, " +
                                "but she loves cute animals and when encountering pets she suddenly " +
                                "speaks in baby talk.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1csbMK8VGNKPSgRnHIW0UOH6qYMWWUHO_",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Mia",
                                CharacterVoice = "Waki Azumi",
                                Birthday = new DateTime(2020, 4, 26),
                                Biography = "A young human beast with a dialect accent. She’s a " +
                                "glutton that is pure and innocent yet filled with curiosity. She " +
                                "touches objects that are not meant to be touched, eats food that " +
                                "is not meant to be eaten and causes all sorts of trouble.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=1hvNhIgY1u9nJMo1Gm-7pHfc932J8F0Kp",
                                CharacterImagePath = ""
                            },

                            new Character
                            {
                                Name = "Amy",
                                CharacterVoice = "Oozora Naomi",
                                Birthday = new DateTime(2020, 2, 8),
                                Biography = "An older human beast from the northern lands. " +
                                "She’s overprotective, enjoys looking after others more than " +
                                "anything and often takes care of Mia like a little sister, " +
                                "but she spoils her too much that it has adverse effects.",
                                IconImagePath = "https://drive.google.com/uc?export=view&id=18qtofW26asHStshiG4LwUV9tmWKCO4rE",
                                CharacterImagePath = ""
                            }
                        );
                        context.SaveChanges();

                        // Set the value of the character id to current value
                        query = "SELECT setval('public.character_character_id_seq', max(character_id)) FROM public.character";
                        context.Database.ExecuteSqlRaw(query);
                    }

                    // Add elements
                    if (!context.Element.Any())
                    {
                        context.AddRange(
                            new Element
                            {
                                ElementID = 1,
                                Name = "Fire",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1zs-o5OyRvFxWOC1s9AjOD_l96pLqjpTp"
                            },

                            new Element
                            {
                                ElementID = 2,
                                Name = "Water",
                                ImagePath = "https://drive.google.com/uc?export=view&id=143pAC7heEZ2bVvckuw1R5m0rjEiDA4wi"
                            },

                            new Element
                            {
                                ElementID = 3,
                                Name = "Lightning",
                                ImagePath = "https://drive.google.com/uc?export=view&id=15LujTvvyODjLoV581p4WPWB7hmkixrvD"
                            },

                            new Element
                            {
                                ElementID = 4,
                                Name = "Earth",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1J3rH8Qn4goCwLNsUdxUi4PSDDj1DzBu7"
                            },

                            new Element
                            {
                                ElementID = 5,
                                Name = "Wind",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1gfP8aLWwKVt7o45LpAu_k8xVEO9f3INW"
                            },

                            new Element
                            {
                                ElementID = 6,
                                Name = "Light",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1goxJfL8Xyn_uv4Y5NYXqugw8VRcjyTS6"
                            },

                            new Element
                            {
                                ElementID = 7,
                                Name = "Dark",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1uSYgzp3On3pF5EdcQ65eKZ-3JONm4owz"
                            }
                        );
                        context.SaveChanges();

                        // Set the value of the element id to current value
                        query = "SELECT setval('public.element_element_id_seq', max(element_id)) FROM public.element";
                        context.Database.ExecuteSqlRaw(query);
                    }

                    // Add passive skills
                    if (!context.PassiveSkill.Any())
                    {
                        context.AddRange(
                            new PassiveSkill
                            {
                                SkillID = 1,
                                Name = "Water-type Attack Up",
                                Description = "Increase attack power by 5% when using water-type attacks",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1b3xqdYkk5LTLZIrKATDjT2GA2isEeAxS"
                            },

                            new PassiveSkill
                            {
                                SkillID = 2,
                                Name = "Bind Resistance Up",
                                Description = "Increase resistance against bind by 12%",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1pREW6V1wEilRe2SIfj3MHvxdNx1XSuAA"
                            },

                            new PassiveSkill
                            {
                                SkillID = 3,
                                Name = "Poison Resistance Up",
                                Description = "Increase resistance against poison by 15%",
                                ImagePath = "https://drive.google.com/uc?export=view&id=11INbvxK2_uifMwO-cOYyeCIU5puKwc2j"
                            },

                            new PassiveSkill
                            {
                                SkillID = 4,
                                Name = "Healing Skill Effect Up",
                                Description = "Increase healing skill effects by 7%",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1P-lwOOz-QKx5QXKUljLh25vGrGLFwjXR"
                            },

                            new PassiveSkill
                            {
                                SkillID = 5,
                                Name = "Seal Resistance Up",
                                Description = "Increase resistance against seal by 12%",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1a-3mLIDEGQxXW02Ht85miUY3CoWPkfNX"
                            },

                            new PassiveSkill
                            {
                                SkillID = 6,
                                Name = "Recover Per Action",
                                Description = "Heal 50 HP for every action",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1o3L-znTh1H6-5T3FeFzV69rZogS9YJy1"
                            },

                            new PassiveSkill
                            {
                                SkillID = 7,
                                Name = "Fire-type Attack Up",
                                Description = "Increase attack power by 5% when using fire-type attacks",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1l3BiJE8IMG6uM4AdSDJPpPHfdeI5FWJh"
                            },

                            new PassiveSkill
                            {
                                SkillID = 8,
                                Name = "Lightning Attack Up",
                                Description = "Increase attack power by 5% when using lightning-type attacks",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1xmCumN_JAiSJ6PhPMRQyxvQBAd5fIjkB"
                            }

                        );
                        context.SaveChanges();
                    }

                    // Add cards for characters
                    if (!context.Card.Any())
                    {
                        var rarityOneImagePath = "https://drive.google.com/uc?export=view&id=1-gQnvlvkEES2pAdAWGp3ClMfk8NeJ499";
                        var rarityTwoImagePath = "https://drive.google.com/uc?export=view&id=1ceXr7wyf4KMEad316zFApcb-N2iYqAP7";
                        var rarityThreeImagePath = "https://drive.google.com/uc?export=view&id=1UCFALfB8sn9RFopP7qiXq-hqGEWPGkT_";
                        var rarityFourImagePath = "https://drive.google.com/uc?export=view&id=1efnJ_hoF6YOwq85JjpzUJFBAPFPfSPzR";


                        context.Card.AddRange(
                            // Kazuma
                            new Card
                            {
                                Name = "Starter",
                                Rarity = 1,
                                RarityImagePath = rarityOneImagePath,
                                Weapon = Weapon.Sword,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1fnRdWThSdLkGtuFSn6yqNLKmZp9KLJ-D",
                            
                                HealthPoints = 1391,
                                PhysicalAttack = 206,
                                MagicAttack = 204,
                                PhysicalDefense = 147,
                                MagicDefense = 141,
                                Agility = 72,
                                Dexterity = 78,
                                Luck = 88,

                                FireResistance = 0.2m,
                                WaterResistance = 0,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 1,
                                PassiveSkillID = 1,
                                CardID = 1
                            },

                            new Card
                            {
                                Name = "Adventurer",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Sword,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1dIWgIlaYZotWV9kPZNRD4Wx0ebxtMrih",

                                HealthPoints = 1483,
                                PhysicalAttack = 220,
                                MagicAttack = 217,
                                PhysicalDefense = 157,
                                MagicDefense = 150,
                                Agility = 72,
                                Dexterity = 78,
                                Luck = 88,

                                FireResistance = 0,
                                WaterResistance = 0,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0.2m,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 1,
                                PassiveSkillID = 2,
                                CardID = 2
                            },

                            new Card
                            {
                                Name = "Construction Site",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Sword,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1jimlOadqb-2RODiLnHvoax7d58P1tKMr",

                                HealthPoints = 1468,
                                PhysicalAttack = 221,
                                MagicAttack = 215,
                                PhysicalDefense = 156,
                                MagicDefense = 149,
                                Agility = 73,
                                Dexterity = 79,
                                Luck = 87,

                                FireResistance = 0,
                                WaterResistance = 0,
                                LightningResistance = 0.2m,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 1,
                                PassiveSkillID = 2,
                                CardID = 3
                            },

                            // Aqua
                            new Card
                            {
                                Name = "Starter",
                                Rarity = 1,
                                RarityImagePath = rarityOneImagePath,
                                Weapon = Weapon.Rod,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1K8G-mulEc3fgmuxJTZV3_Oife9YURqPn",

                                HealthPoints = 1431,
                                PhysicalAttack = 218,
                                MagicAttack = 237,
                                PhysicalDefense = 158,
                                MagicDefense = 167,
                                Agility = 66,
                                Dexterity = 76,
                                Luck = 10,

                                FireResistance = 0.2m,
                                WaterResistance = 0.2m,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 2,
                                PassiveSkillID = 4,
                                CardID = 4
                            },

                            new Card
                            {
                                Name = "Arc Priest",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Rod,
                                ImagePath = "https://drive.google.com/uc?export=view&id=12i-tb4pDEBkmR5FGaLKFyn-terfF84SI",

                                HealthPoints = 1526,
                                PhysicalAttack = 233,
                                MagicAttack = 253,
                                PhysicalDefense = 168,
                                MagicDefense = 178,
                                Agility = 66,
                                Dexterity = 76,
                                Luck = 10,

                                FireResistance = 0,
                                WaterResistance = 0.2m,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0.2m,

                                CharacterID = 2,
                                PassiveSkillID = 5,
                                CardID = 5
                            },

                            new Card
                            {
                                Name = "Construction Site",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Rod,
                                ImagePath = "https://drive.google.com/uc?export=view&id=17lWtcTygiw6Y1LFJVWeZAIvV2J00qYnT",

                                HealthPoints = 1511,
                                PhysicalAttack = 235,
                                MagicAttack = 254,
                                PhysicalDefense = 166,
                                MagicDefense = 177,
                                Agility = 67,
                                Dexterity = 77,
                                Luck = 10,

                                FireResistance = 0,
                                WaterResistance = 0.2m,
                                LightningResistance = 0.2m,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 2,
                                PassiveSkillID = 6,
                                CardID = 6
                            },

                            // Megumin
                            new Card
                            {
                                Name = "Starter",
                                Rarity = 1,
                                RarityImagePath = rarityOneImagePath,
                                Weapon = Weapon.Staff,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1gSUJ-9Bcg_jn2Eaxd3ec2N4MOuTfQoMY",

                                HealthPoints = 1148,
                                PhysicalAttack = 200,
                                MagicAttack = 233,
                                PhysicalDefense = 132,
                                MagicDefense = 158,
                                Agility = 68,
                                Dexterity = 71,
                                Luck = 72,

                                FireResistance = 0,
                                WaterResistance = 0,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0.2m,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 3,
                                PassiveSkillID = 7,
                                CardID = 7
                            },

                            new Card
                            {
                                Name = "Arc Wizard",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Staff,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1DWPQGuYP17cwbBML_baY-1udChvxu213",

                                HealthPoints = 1224,
                                PhysicalAttack = 213,
                                MagicAttack = 249,
                                PhysicalDefense = 141,
                                MagicDefense = 168,
                                Agility = 68,
                                Dexterity = 71,
                                Luck = 72,

                                FireResistance = 0,
                                WaterResistance = 0,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0.2m,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 3,
                                PassiveSkillID = 8,
                                CardID = 8
                            },

                            new Card
                            {
                                Name = "Plain Clothed",
                                Rarity = 2,
                                RarityImagePath = rarityTwoImagePath,
                                Weapon = Weapon.Staff,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1IbNsPATCze0ZqiXv3vY5FS_8PR5Eh2NK",

                                HealthPoints = 1212,
                                PhysicalAttack = 211,
                                MagicAttack = 251,
                                PhysicalDefense = 139,
                                MagicDefense = 167,
                                Agility = 69,
                                Dexterity = 72,
                                Luck = 71,

                                FireResistance = 0,
                                WaterResistance = 0.2m,
                                LightningResistance = 0,
                                EarthResistance = 0,
                                WindResistance = 0,
                                LightResistance = 0,
                                DarkResistance = 0,

                                CharacterID = 3,
                                PassiveSkillID = 7,
                                CardID = 9
                            }
                        );
                        context.SaveChanges();

                        // Set the value of the card id to current value
                        query = "SELECT setval('public.card_card_id_seq', max(card_id)) FROM public.card";
                        context.Database.ExecuteSqlRaw(query);
                    }

                    // Assign element to cards
                    if (!context.CardElement.Any())
                    {
                        context.CardElement.AddRange(
                            new CardElement
                            {
                                CardID = 1,
                                ElementID = 2
                            },

                            new CardElement
                            {
                                CardID = 2,
                                ElementID = 1
                            },

                            new CardElement
                            {
                                CardID = 3,
                                ElementID = 4
                            },

                            new CardElement
                            {
                                CardID = 4,
                                ElementID = 2
                            },

                            new CardElement
                            {
                                CardID = 5,
                                ElementID = 6
                            },

                            new CardElement
                            {
                                CardID = 6,
                                ElementID = 4
                            },

                            new CardElement
                            {
                                CardID = 7,
                                ElementID = 1
                            },

                            new CardElement
                            {
                                CardID = 8,
                                ElementID = 1
                            },

                            new CardElement
                            {
                                CardID = 9,
                                ElementID = 3
                            }
                        );
                        context.SaveChanges();
                    }

                    // Add basic skills
                    if (!context.BasicSkill.Any())
                    {
                        context.BasicSkill.AddRange(
                            new BasicSkill
                            {
                                SkillID = 9,
                                Name = "Attack",
                                Description = "Deal 126% non-elemental physical damage to an enemy",
                                ChargeTime = 0,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1qEY7ALGVT5rf4vVZ6LK_QUyHNK8LlOjU"
                            },

                            new BasicSkill
                            {
                                SkillID = 10,
                                Name = "Create Water",
                                Description = "Deal 151% water magic damage to an enemy",
                                ChargeTime = 9,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1S2ph_9tSKEBLY1__UiB_roWWM7HbS2ru"
                            },

                            new BasicSkill
                            {
                                SkillID = 11,
                                Name = "Bind",
                                Description = "A high chance of applying bind to an enemy (7 seconds)",
                                ChargeTime = 14,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1Nt1m5sQdtn8sW-lskri79RGQMz6B6iD2"
                            },

                            new BasicSkill
                            {
                                SkillID = 12,
                                Name = "Fire Slash",
                                Description = "Deal 190% fire physical damage to an enemy",
                                ChargeTime = 17,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1oJ9XDha5olvODxoQUABv27PhnIZrBkG5"
                            },

                            new BasicSkill
                            {
                                SkillID = 13,
                                Name = "Guard Down",
                                Description = "Slightly reduce the physical defence of all enemies (16 seconds)",
                                ChargeTime = 16,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1SY_JaffmPQg-hLUgo1JQ7k_1JdrPCj7W"
                            },

                            new BasicSkill
                            {
                                SkillID = 14,
                                Name = "Create Earth",
                                Description = "Deal 151% earth magic damage to an enemy",
                                ChargeTime = 9,
                                ImagePath = "https://drive.google.com/uc?export=view&id=19JPMy8VzyTSznsXvhYoMd5WqvGpoMdpk"
                            },

                            new BasicSkill
                            {
                                SkillID = 15,
                                Name = "Speed Down",
                                Description = "Slightly reduce the speed of all enemies (16 seconds)",
                                ChargeTime = 16,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1yT9gDJuH1rQHpdj8TFdoah10VwkODeBm"
                            },

                            new BasicSkill
                            {
                                SkillID = 16,
                                Name = "Marine Attack",
                                Description = "Deal 180% water physical damage to an enemy",
                                ChargeTime = 15,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1TX6pZJ4QaOl4IZxHACJn2tYpfzGqH7jY"
                            },

                            new BasicSkill
                            {
                                SkillID = 17,
                                Name = "Heal",
                                Description = "Moderately heal an ally ",
                                ChargeTime = 13,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1YUvosdGDdyEzxfxHNYkSFWdngG1ZJysB"
                            },

                            new BasicSkill
                            {
                                SkillID = 18,
                                Name = "Bright Attack+",
                                Description = "Deal 128% light physical damage to an enemy and slightly heal all allies",
                                ChargeTime = 18,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1-kQ3FGDeiWpd3CAqOeT91sFx4r9CVCG_"
                            },

                            new BasicSkill
                            {
                                SkillID = 19,
                                Name = "Purification+",
                                Description = "Remove all negative effects from an ally and slightly heal",
                                ChargeTime = 16,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1boALmHKQDnJyFKVP8bOh55qvYb3EXupE"
                            },

                            new BasicSkill
                            {
                                SkillID = 20,
                                Name = "Rock Attack",
                                Description = "Deal 180% earth physical damage to an enemy",
                                ChargeTime = 15,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1eE_wPiB8w47jJmJtM9PXoI_sEJn7nZO3"
                            },

                            new BasicSkill
                            {
                                SkillID = 21,
                                Name = "Fire Potion",
                                Description = "Deal 180% fire magic damage to an enemy",
                                ChargeTime = 15,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1kLG_SyBypa2XDSrJHfP9m3WhVhfNmz6O"
                            },

                            new BasicSkill
                            {
                                SkillID = 22,
                                Name = "Enhance Magic Power",
                                Description = "Moderately increase your magic attack (16 seconds)",
                                ChargeTime = 14,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1RNXXinxXZ8-4VsbIJBCrkbYCMyMeyFCq"
                            },

                            new BasicSkill
                            {
                                SkillID = 23,
                                Name = "Fire Potions",
                                Description = "Deal 142% fire magic attack damage to all enemies",
                                ChargeTime = 17,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1HtGKUrP-2pjTigDELxfo4ivynQlncKIr"
                            },

                            new BasicSkill
                            {
                                SkillID = 24,
                                Name = "Enhance Speed",
                                Description = "Moderately increase your speed (16 seconds)",
                                ChargeTime = 14,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1QyQII_Gziwr4hbmH7z4x1L14MfsqqwqB"
                            },

                            new BasicSkill
                            {
                                SkillID = 25,
                                Name = "Thunder Potions",
                                Description = "Deal 142% lightning magic damage to all enemies",
                                ChargeTime = 17,
                                ImagePath = "https://drive.google.com/uc?export=view&id=1ewXPDrzECTz6FqtjC2Fwc7yp0hmzVPpL"
                            }
                        );
                        context.SaveChanges();

                        // Set the value of the skill id to current value
                        query = "SELECT setval('public.skill_skill_id_seq', max(skill_id)) FROM public.skill";
                        context.Database.ExecuteSqlRaw(query);
                    }

                    // Assign basic skills to cards
                    if (!context.CardBasicSkill.Any())
                    {
                        context.CardBasicSkill.AddRange(
                            // Kazuma - Beginner
                            new CardBasicSkill
                            {
                                CardID = 1,
                                BasicSkillID = 10
                            },

                            new CardBasicSkill
                            {
                                CardID = 1,
                                BasicSkillID = 11
                            },

                            new CardBasicSkill
                            {
                                CardID = 1,
                                BasicSkillID = 9
                            },

                            // Kazuma - Adventurer
                            new CardBasicSkill
                            {
                                CardID = 2,
                                BasicSkillID = 12
                            },

                            new CardBasicSkill
                            {
                                CardID = 2,
                                BasicSkillID = 13
                            },

                            new CardBasicSkill
                            {
                                CardID = 2,
                                BasicSkillID = 9
                            },

                            // Kazuma - Construction Site
                            new CardBasicSkill
                            {
                                CardID = 3,
                                BasicSkillID = 14
                            },

                            new CardBasicSkill
                            {
                                CardID = 3,
                                BasicSkillID = 15
                            },

                            new CardBasicSkill
                            {
                                CardID = 3,
                                BasicSkillID = 9
                            },

                            // Aqua - Beginner
                            new CardBasicSkill
                            {
                                CardID = 4,
                                BasicSkillID = 16
                            },

                            new CardBasicSkill
                            {
                                CardID = 4,
                                BasicSkillID = 17
                            },

                            new CardBasicSkill
                            {
                                CardID = 4,
                                BasicSkillID = 9
                            },

                            // Aqua - Arch Priest
                            new CardBasicSkill
                            {
                                CardID = 5,
                                BasicSkillID = 18
                            },

                            new CardBasicSkill
                            {
                                CardID = 5,
                                BasicSkillID = 19
                            },

                            new CardBasicSkill
                            {
                                CardID = 5,
                                BasicSkillID = 9
                            },

                            // Aqua - Construction Site
                            new CardBasicSkill
                            {
                                CardID = 6,
                                BasicSkillID = 20
                            },

                            new CardBasicSkill
                            {
                                CardID = 6,
                                BasicSkillID = 17
                            },

                            new CardBasicSkill
                            {
                                CardID = 6,
                                BasicSkillID = 9
                            },

                            // Megumin - Starter
                            new CardBasicSkill
                            {
                                CardID = 7,
                                BasicSkillID = 21
                            },

                            new CardBasicSkill
                            {
                                CardID = 7,
                                BasicSkillID = 22
                            },

                            new CardBasicSkill
                            {
                                CardID = 7,
                                BasicSkillID = 9
                            },

                            // Megumin - Arch Wizard
                            new CardBasicSkill
                            {
                                CardID = 8,
                                BasicSkillID = 23
                            },

                            new CardBasicSkill
                            {
                                CardID = 8,
                                BasicSkillID = 24
                            },

                            new CardBasicSkill
                            {
                                CardID = 8,
                                BasicSkillID = 9
                            },

                            // Megumin - Plain Clothed
                            new CardBasicSkill
                            {
                                CardID = 9,
                                BasicSkillID = 25
                            },

                            new CardBasicSkill
                            {
                                CardID = 9,
                                BasicSkillID = 22
                            },

                            new CardBasicSkill
                            {
                                CardID = 9,
                                BasicSkillID = 9
                            }
                        );
                        context.SaveChanges();
                    }

                    // Add ultimate skill for characters
                    if (!context.UltimateSkill.Any())
                    {
                        context.AddRange(
                            new UltimateSkill
                            {
                                Name = "Double Drain Touch",
                                Description = "Deals 344% non-elemental magic damage to an enemy " +
                                "and moderately heals allies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=13NvY9RUCpW9-sFu5AT36slzClTMbfPIM",
                                CharacterID = 1
                            },

                            new UltimateSkill
                            {
                                Name = "God Blow",
                                Description = "Deals 338% light physical damage to an enemy.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1yNqg_xy-ZvdAO_3h6FtzT6OP4FzjCuhF",
                                CharacterID = 2
                            },

                            new UltimateSkill
                            {
                                Name = "Explosion",
                                Description = "Deals 433% fire magic damage to all enemies and " +
                                "becomes unable to fight after use.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1LDQ8-bzC-oGtTx9YparOOTOtWMM4EY99",
                                CharacterID = 3
                            },

                            new UltimateSkill
                            {
                                Name = "Use me as a wall",
                                Description = "Highly increases chances of drawing enemy attacks " +
                                "and greatly increases your physical and magical defence (20 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1MifOwFO0Jb9AA2LVmsH4U2RQX7EALTmJ",
                                CharacterID = 4
                            },

                            new UltimateSkill
                            {
                                Name = "Cursed Crystal Prison",
                                Description = "Deals 252% water magic damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1uv8rZgsEyZzHSveAYsjCaWT2JD8eMeA0",
                                CharacterID = 5
                            },

                            new UltimateSkill
                            {
                                Name = "Light of Saber",
                                Description = "Deals 252% light magic damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1iEQChkt-bG9bmTka3L1KNtJ9WpAEGudI",
                                CharacterID = 6
                            },

                            new UltimateSkill
                            {
                                Name = "Cursed Lightning",
                                Description = "Deals 252% dark magic damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1Zhzm4ePRVdIn6W8uHgUgwdKy-lLPwOgO",
                                CharacterID = 7
                            },

                            new UltimateSkill
                            {
                                Name = "Wire Tornado",
                                Description = "Deals 256% non-elemental physical damage to all " +
                                "enemies and greatly reduces their agility (16 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1_a_k4nJrsgYKsBU_FJp1lLJjLej55yWL",
                                CharacterID = 8
                            },

                            new UltimateSkill
                            {
                                Name = "Exterion",
                                Description = "Deals 252% light physical damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1I8WjrjbXH1vFc8nwIcN-Gfmz87cHK2zB",
                                CharacterID = 9
                            },

                            new UltimateSkill
                            {
                                Name = "Axis Order Attack",
                                Description = "Deals 256% non-elemental physical damage to all " +
                                "enemies and greatly reduces their magic defence (16 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1EuQS-ebOD_fWBjC14dDIe9OLNz6dz6sd",
                                CharacterID = 10
                            },

                            new UltimateSkill
                            {
                                Name = "Sword of the Chosen Hero",
                                Description = "Deals 344% non-elemental physical damage to an " +
                                "enemy and greatly increases the physical defence of all allies " +
                                "(16 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1AdVzAhy0AvDZ8ac0bAnUJU5d5jJ7RYJt",
                                CharacterID = 11
                            },

                            new UltimateSkill
                            {
                                Name = "I Can Do It When I Try",
                                Description = "Deals 292% non-elemental physical damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=16V-VtMkgKm8dylSB5nCwqPbs5wGmiqAN",
                                CharacterID = 12
                            },

                            new UltimateSkill
                            {
                                Name = "Blade of Wind",
                                Description = "Deals 252% wind magic damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1EPIOUtHOue0WHSk4tI7ffJ5apjoeoLWS",
                                CharacterID = 13
                            },

                            new UltimateSkill
                            {
                                Name = "Prelude Defence",
                                Description = "Greatly increases the physical and magic defence of " +
                                "all allies (12 seconds) and moderately fills their ultimate skill gauge.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1mN3DS68Ol_4fZj0nyrkONiFkOelSI-Xh",
                                CharacterID = 14
                            },

                            new UltimateSkill
                            {
                                Name = "Sacred Highness Heal",
                                Description = "Heals all allies for an extremely large amount and " +
                                "greatly increases physical and magic attack (12 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=183GYZyKitScQoSqwdW_z6-27mqCf6J2Q",
                                CharacterID = 15
                            },

                            new UltimateSkill
                            {
                                Name = "Self-call and Response",
                                Description = "Deals 344% non-elemental physical damage to an enemy " +
                                "and greatly increases the physical attack of all allies (16 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=14_xI936iOlJXMCh4Fo-DHfh7HQI6Q2TK",
                                CharacterID = 16
                            },

                            new UltimateSkill
                            {
                                Name = "Midnight Edge",
                                Description = "Deals 344% non-elemental physical damage to an enemy " +
                                "and greatly reduces their physical defence (20 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1Y8SnzkecAcJu8RO3htnhXy3_0L6mC9eJ",
                                CharacterID = 17
                            },

                            new UltimateSkill
                            {
                                Name = "Rock Bomber",
                                Description = "Deals 252% earth physical damage to all enemies.",
                                ImagePath = "https://drive.google.com/uc?export=view&id=11qJzzIZVgA23cfC5z7G1vDG7w_Tj7gVo",
                                CharacterID = 18
                            },

                            new UltimateSkill
                            {
                                Name = "Pain, Pain Fly Away",
                                Description = "Heals all allies for an extremely large amount " +
                                "and greatly increases their magic attack (16 seconds).",
                                ImagePath = "https://drive.google.com/uc?export=view&id=1RLk0rAZPf9FvaWgEVvO4N50qNi69QidQ",
                                CharacterID = 19
                            }
                        );
                        context.SaveChanges();

                        // Set the value of the skill id to current value
                        query = "SELECT setval('public.skill_skill_id_seq', max(skill_id)) FROM public.skill";
                        context.Database.ExecuteSqlRaw(query);
                    }
                }
            } 
        }
    }
}
