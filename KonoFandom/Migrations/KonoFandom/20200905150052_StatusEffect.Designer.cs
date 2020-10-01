﻿// <auto-generated />
using System;
using KonoFandom.Areas.GameData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    [DbContext(typeof(KonoFandomContext))]
    [Migration("20200905150052_StatusEffect")]
    partial class StatusEffect
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("KonoFandom.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("card_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Agility")
                        .HasColumnName("agility")
                        .HasColumnType("integer");

                    b.Property<int>("CharacterID")
                        .HasColumnName("character_id")
                        .HasColumnType("integer");

                    b.Property<decimal>("DarkResistance")
                        .HasColumnName("dark_resistance")
                        .HasColumnType("numeric");

                    b.Property<int>("Dexterity")
                        .HasColumnName("dexterity")
                        .HasColumnType("integer");

                    b.Property<decimal>("EarthResistance")
                        .HasColumnName("earth_resistance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FireResistance")
                        .HasColumnName("fire_resistance")
                        .HasColumnType("numeric");

                    b.Property<int>("HealthPoints")
                        .HasColumnName("health_points")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .HasColumnName("image_path")
                        .HasColumnType("text");

                    b.Property<decimal>("LightResistance")
                        .HasColumnName("light_resistance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LightningResistance")
                        .HasColumnName("lightning_resistance")
                        .HasColumnType("numeric");

                    b.Property<int>("Luck")
                        .HasColumnName("luck")
                        .HasColumnType("integer");

                    b.Property<int>("MagicAttack")
                        .HasColumnName("magic_attack")
                        .HasColumnType("integer");

                    b.Property<int>("MagicDefense")
                        .HasColumnName("magic_defense")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.Property<int>("PassiveSkillID")
                        .HasColumnName("passive_skill_id")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalAttack")
                        .HasColumnName("physical_attack")
                        .HasColumnType("integer");

                    b.Property<int>("PhysicalDefense")
                        .HasColumnName("physical_defense")
                        .HasColumnType("integer");

                    b.Property<int>("Rarity")
                        .HasColumnName("rarity")
                        .HasColumnType("integer");

                    b.Property<decimal>("WaterResistance")
                        .HasColumnName("water_resistance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("WindResistance")
                        .HasColumnName("wind_resistance")
                        .HasColumnType("numeric");

                    b.HasKey("CardID")
                        .HasName("pk_card");

                    b.HasIndex("CharacterID")
                        .HasName("ix_card_character_id");

                    b.HasIndex("PassiveSkillID")
                        .HasName("ix_card_passive_skill_id");

                    b.ToTable("card");
                });

            modelBuilder.Entity("KonoFandom.Models.CardBasicSkill", b =>
                {
                    b.Property<int>("CardID")
                        .HasColumnName("card_id")
                        .HasColumnType("integer");

                    b.Property<int>("BasicSkillID")
                        .HasColumnName("basic_skill_id")
                        .HasColumnType("integer");

                    b.HasKey("CardID", "BasicSkillID")
                        .HasName("pk_card_basic_skill");

                    b.HasIndex("BasicSkillID")
                        .HasName("ix_card_basic_skill_basic_skill_id");

                    b.ToTable("card_basic_skill");
                });

            modelBuilder.Entity("KonoFandom.Models.CardElement", b =>
                {
                    b.Property<int>("CardID")
                        .HasColumnName("card_id")
                        .HasColumnType("integer");

                    b.Property<int>("ElementID")
                        .HasColumnName("element_id")
                        .HasColumnType("integer");

                    b.HasKey("CardID", "ElementID")
                        .HasName("pk_card_element");

                    b.HasIndex("ElementID")
                        .HasName("ix_card_element_element_id");

                    b.ToTable("card_element");
                });

            modelBuilder.Entity("KonoFandom.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("character_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Biography")
                        .HasColumnName("biography")
                        .HasColumnType("text");

                    b.Property<string>("CharacterImagePath")
                        .HasColumnName("character_image_path")
                        .HasColumnType("text");

                    b.Property<string>("IconImagePath")
                        .HasColumnName("icon_image_path")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Weapon")
                        .HasColumnName("weapon")
                        .HasColumnType("integer");

                    b.HasKey("CharacterID")
                        .HasName("pk_character");

                    b.ToTable("character");
                });

            modelBuilder.Entity("KonoFandom.Models.Effect", b =>
                {
                    b.Property<int>("EffectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("effect_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnName("discriminator")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnName("image_path")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("EffectID")
                        .HasName("pk_effect");

                    b.ToTable("effect");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Effect");
                });

            modelBuilder.Entity("KonoFandom.Models.Element", b =>
                {
                    b.Property<int>("ElementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("element_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnName("image_path")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnName("type")
                        .HasColumnType("text");

                    b.HasKey("ElementID")
                        .HasName("pk_element");

                    b.ToTable("element");
                });

            modelBuilder.Entity("KonoFandom.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("skill_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BuffEffectID")
                        .HasColumnName("buff_effect_id")
                        .HasColumnType("integer");

                    b.Property<int?>("DebuffEffectID")
                        .HasColumnName("debuff_effect_id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnName("discriminator")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnName("image_path")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(30)")
                        .HasMaxLength(30);

                    b.HasKey("SkillID")
                        .HasName("pk_skill");

                    b.HasIndex("BuffEffectID")
                        .HasName("ix_skill_buff_effect_id");

                    b.HasIndex("DebuffEffectID")
                        .HasName("ix_skill_debuff_effect_id");

                    b.ToTable("skill");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Skill");
                });

            modelBuilder.Entity("KonoFandom.Models.SkillStatusEffect", b =>
                {
                    b.Property<int>("SkillID")
                        .HasColumnName("skill_id")
                        .HasColumnType("integer");

                    b.Property<int>("StatusEffectID")
                        .HasColumnName("status_effect_id")
                        .HasColumnType("integer");

                    b.HasKey("SkillID", "StatusEffectID")
                        .HasName("pk_skill_status_effect");

                    b.HasIndex("StatusEffectID")
                        .HasName("ix_skill_status_effect_status_effect_id");

                    b.ToTable("skill_status_effect");
                });

            modelBuilder.Entity("KonoFandom.Models.BuffEffect", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Effect");

                    b.HasDiscriminator().HasValue("BuffEffect");
                });

            modelBuilder.Entity("KonoFandom.Models.DebuffEffect", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Effect");

                    b.HasDiscriminator().HasValue("DebuffEffect");
                });

            modelBuilder.Entity("KonoFandom.Models.StatusEffect", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Effect");

                    b.HasDiscriminator().HasValue("StatusEffect");
                });

            modelBuilder.Entity("KonoFandom.Models.BasicSkill", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Skill");

                    b.Property<int>("Cooldown")
                        .HasColumnName("cooldown")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("BasicSkill");
                });

            modelBuilder.Entity("KonoFandom.Models.PassiveSkill", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Skill");

                    b.HasDiscriminator().HasValue("PassiveSkill");
                });

            modelBuilder.Entity("KonoFandom.Models.UltimateSkill", b =>
                {
                    b.HasBaseType("KonoFandom.Models.Skill");

                    b.Property<int>("CharacterID")
                        .HasColumnName("character_id")
                        .HasColumnType("integer");

                    b.HasIndex("CharacterID")
                        .IsUnique()
                        .HasName("ix_skill_character_id");

                    b.HasDiscriminator().HasValue("UltimateSkill");
                });

            modelBuilder.Entity("KonoFandom.Models.Card", b =>
                {
                    b.HasOne("KonoFandom.Models.Character", "Character")
                        .WithMany("Cards")
                        .HasForeignKey("CharacterID")
                        .HasConstraintName("fk_card_character_character_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KonoFandom.Models.PassiveSkill", "PassiveSkill")
                        .WithMany("Cards")
                        .HasForeignKey("PassiveSkillID")
                        .HasConstraintName("fk_card_skill_passive_skill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KonoFandom.Models.CardBasicSkill", b =>
                {
                    b.HasOne("KonoFandom.Models.BasicSkill", "BasicSkill")
                        .WithMany("CardBasicSkills")
                        .HasForeignKey("BasicSkillID")
                        .HasConstraintName("fk_card_basic_skill_skill_basic_skill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KonoFandom.Models.Card", "Card")
                        .WithMany("CardBasicSkills")
                        .HasForeignKey("CardID")
                        .HasConstraintName("fk_card_basic_skill_card_card_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KonoFandom.Models.CardElement", b =>
                {
                    b.HasOne("KonoFandom.Models.Card", "Card")
                        .WithMany("CardElements")
                        .HasForeignKey("CardID")
                        .HasConstraintName("fk_card_element_card_card_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KonoFandom.Models.Element", "Element")
                        .WithMany("CardElements")
                        .HasForeignKey("ElementID")
                        .HasConstraintName("fk_card_element_element_element_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KonoFandom.Models.Skill", b =>
                {
                    b.HasOne("KonoFandom.Models.BuffEffect", "BuffEffect")
                        .WithMany("Skills")
                        .HasForeignKey("BuffEffectID")
                        .HasConstraintName("fk_skill_effect_buff_effect_id");

                    b.HasOne("KonoFandom.Models.DebuffEffect", "DebuffEffect")
                        .WithMany("Skills")
                        .HasForeignKey("DebuffEffectID")
                        .HasConstraintName("fk_skill_effect_debuff_effect_id");
                });

            modelBuilder.Entity("KonoFandom.Models.SkillStatusEffect", b =>
                {
                    b.HasOne("KonoFandom.Models.Skill", "Skill")
                        .WithMany("SkillStatusEffects")
                        .HasForeignKey("SkillID")
                        .HasConstraintName("fk_skill_status_effect_skill_skill_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KonoFandom.Models.StatusEffect", "StatusEffect")
                        .WithMany("SkillStatusEffects")
                        .HasForeignKey("StatusEffectID")
                        .HasConstraintName("fk_skill_status_effect_effect_status_effect_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KonoFandom.Models.UltimateSkill", b =>
                {
                    b.HasOne("KonoFandom.Models.Character", "Character")
                        .WithOne("UltimateSkill")
                        .HasForeignKey("KonoFandom.Models.UltimateSkill", "CharacterID")
                        .HasConstraintName("fk_skill_character_character_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
