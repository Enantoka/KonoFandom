﻿// <auto-generated />
using System;
using KonoFandom.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KonoFandom.Migrations.KonoFandom
{
    [DbContext(typeof(KonoFandomContext))]
    [Migration("20210326102323_DB_v1.01_Increase_str_length")]
    partial class DB_v101_Increase_str_length
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KonoFandom.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("card_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Agility")
                        .HasColumnType("integer")
                        .HasColumnName("agility");

                    b.Property<int>("CharacterID")
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.Property<decimal>("DarkResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("dark_resistance");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer")
                        .HasColumnName("dexterity");

                    b.Property<decimal>("EarthResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("earth_resistance");

                    b.Property<decimal>("FireResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("fire_resistance");

                    b.Property<int>("HealthPoints")
                        .HasColumnType("integer")
                        .HasColumnName("health_points");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text")
                        .HasColumnName("image_path");

                    b.Property<decimal>("LightResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("light_resistance");

                    b.Property<decimal>("LightningResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("lightning_resistance");

                    b.Property<int>("Luck")
                        .HasColumnType("integer")
                        .HasColumnName("luck");

                    b.Property<int>("MagicAttack")
                        .HasColumnType("integer")
                        .HasColumnName("magic_attack");

                    b.Property<int>("MagicDefense")
                        .HasColumnType("integer")
                        .HasColumnName("magic_defense");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int?>("PassiveSkillID")
                        .HasColumnType("integer")
                        .HasColumnName("passive_skill_id");

                    b.Property<int>("PhysicalAttack")
                        .HasColumnType("integer")
                        .HasColumnName("physical_attack");

                    b.Property<int>("PhysicalDefense")
                        .HasColumnType("integer")
                        .HasColumnName("physical_defense");

                    b.Property<int>("Rarity")
                        .HasColumnType("integer")
                        .HasColumnName("rarity");

                    b.Property<string>("RarityImagePath")
                        .HasColumnType("text")
                        .HasColumnName("rarity_image_path");

                    b.Property<decimal>("WaterResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("water_resistance");

                    b.Property<int>("Weapon")
                        .HasColumnType("integer")
                        .HasColumnName("weapon");

                    b.Property<decimal>("WindResistance")
                        .HasColumnType("numeric")
                        .HasColumnName("wind_resistance");

                    b.HasKey("CardID")
                        .HasName("pk_card");

                    b.HasIndex("CharacterID")
                        .HasDatabaseName("ix_card_character_id");

                    b.HasIndex("PassiveSkillID")
                        .HasDatabaseName("ix_card_passive_skill_id");

                    b.ToTable("card");
                });

            modelBuilder.Entity("KonoFandom.Models.CardBasicSkill", b =>
                {
                    b.Property<int>("CardID")
                        .HasColumnType("integer")
                        .HasColumnName("card_id");

                    b.Property<int>("BasicSkillID")
                        .HasColumnType("integer")
                        .HasColumnName("basic_skill_id");

                    b.HasKey("CardID", "BasicSkillID")
                        .HasName("pk_card_basic_skill");

                    b.HasIndex("BasicSkillID")
                        .HasDatabaseName("ix_card_basic_skill_basic_skill_id");

                    b.ToTable("card_basic_skill");
                });

            modelBuilder.Entity("KonoFandom.Models.CardElement", b =>
                {
                    b.Property<int>("CardID")
                        .HasColumnType("integer")
                        .HasColumnName("card_id");

                    b.Property<int>("ElementID")
                        .HasColumnType("integer")
                        .HasColumnName("element_id");

                    b.HasKey("CardID", "ElementID")
                        .HasName("pk_card_element");

                    b.HasIndex("ElementID")
                        .HasDatabaseName("ix_card_element_element_id");

                    b.ToTable("card_element");
                });

            modelBuilder.Entity("KonoFandom.Models.Character", b =>
                {
                    b.Property<int>("CharacterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("character_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("text")
                        .HasColumnName("biography");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birthday");

                    b.Property<string>("CharacterImagePath")
                        .HasColumnType("text")
                        .HasColumnName("character_image_path");

                    b.Property<string>("CharacterVoice")
                        .HasColumnType("text")
                        .HasColumnName("character_voice");

                    b.Property<string>("IconImagePath")
                        .HasColumnType("text")
                        .HasColumnName("icon_image_path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("CharacterID")
                        .HasName("pk_character");

                    b.ToTable("character");
                });

            modelBuilder.Entity("KonoFandom.Models.Effect", b =>
                {
                    b.Property<int>("EffectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("effect_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text")
                        .HasColumnName("image_path");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("EffectID")
                        .HasName("pk_effect");

                    b.ToTable("effect");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Effect");
                });

            modelBuilder.Entity("KonoFandom.Models.Element", b =>
                {
                    b.Property<int>("ElementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("element_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("text")
                        .HasColumnName("image_path");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("ElementID")
                        .HasName("pk_element");

                    b.ToTable("element");
                });

            modelBuilder.Entity("KonoFandom.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("skill_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BuffEffectID")
                        .HasColumnType("integer")
                        .HasColumnName("buff_effect_id");

                    b.Property<int?>("DebuffEffectID")
                        .HasColumnType("integer")
                        .HasColumnName("debuff_effect_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text")
                        .HasColumnName("image_path");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("SkillID")
                        .HasName("pk_skill");

                    b.HasIndex("BuffEffectID")
                        .HasDatabaseName("ix_skill_buff_effect_id");

                    b.HasIndex("DebuffEffectID")
                        .HasDatabaseName("ix_skill_debuff_effect_id");

                    b.ToTable("skill");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Skill");
                });

            modelBuilder.Entity("KonoFandom.Models.SkillStatusEffect", b =>
                {
                    b.Property<int>("SkillID")
                        .HasColumnType("integer")
                        .HasColumnName("skill_id");

                    b.Property<int>("StatusEffectID")
                        .HasColumnType("integer")
                        .HasColumnName("status_effect_id");

                    b.HasKey("SkillID", "StatusEffectID")
                        .HasName("pk_skill_status_effect");

                    b.HasIndex("StatusEffectID")
                        .HasDatabaseName("ix_skill_status_effect_status_effect_id");

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

                    b.Property<int>("ChargeTime")
                        .HasColumnType("integer")
                        .HasColumnName("charge_time");

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
                        .HasColumnType("integer")
                        .HasColumnName("character_id");

                    b.HasIndex("CharacterID")
                        .IsUnique()
                        .HasDatabaseName("ix_skill_character_id");

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
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Character");

                    b.Navigation("PassiveSkill");
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

                    b.Navigation("BasicSkill");

                    b.Navigation("Card");
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

                    b.Navigation("Card");

                    b.Navigation("Element");
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

                    b.Navigation("BuffEffect");

                    b.Navigation("DebuffEffect");
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

                    b.Navigation("Skill");

                    b.Navigation("StatusEffect");
                });

            modelBuilder.Entity("KonoFandom.Models.UltimateSkill", b =>
                {
                    b.HasOne("KonoFandom.Models.Character", "Character")
                        .WithOne("UltimateSkill")
                        .HasForeignKey("KonoFandom.Models.UltimateSkill", "CharacterID")
                        .HasConstraintName("fk_skill_character_character_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("KonoFandom.Models.Card", b =>
                {
                    b.Navigation("CardBasicSkills");

                    b.Navigation("CardElements");
                });

            modelBuilder.Entity("KonoFandom.Models.Character", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("UltimateSkill");
                });

            modelBuilder.Entity("KonoFandom.Models.Element", b =>
                {
                    b.Navigation("CardElements");
                });

            modelBuilder.Entity("KonoFandom.Models.Skill", b =>
                {
                    b.Navigation("SkillStatusEffects");
                });

            modelBuilder.Entity("KonoFandom.Models.BuffEffect", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("KonoFandom.Models.DebuffEffect", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("KonoFandom.Models.StatusEffect", b =>
                {
                    b.Navigation("SkillStatusEffects");
                });

            modelBuilder.Entity("KonoFandom.Models.BasicSkill", b =>
                {
                    b.Navigation("CardBasicSkills");
                });

            modelBuilder.Entity("KonoFandom.Models.PassiveSkill", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
