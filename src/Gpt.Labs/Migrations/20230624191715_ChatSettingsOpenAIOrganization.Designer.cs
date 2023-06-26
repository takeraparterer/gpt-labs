﻿// <auto-generated />
using System;
using Gpt.Labs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gpt.Labs.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230624191715_ChatSettingsOpenAIOrganization")]
    partial class ChatSettingsOpenAIOrganization
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIChat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(0);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Title");

                    b.HasIndex("Type");

                    b.ToTable("Chats", (string)null);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAILogitBias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Bias")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SettingsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SettingsId");

                    b.ToTable("LogitBias", (string)null);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("Messages", (string)null);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAISettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("N")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(1);

                    b.Property<string>("OpenAIOrganization")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("User")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatId")
                        .IsUnique();

                    b.ToTable("Settings", (string)null);

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SettingsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SettingsId");

                    b.ToTable("Stops", (string)null);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIChatSettings", b =>
                {
                    b.HasBaseType("Gpt.Labs.Models.OpenAISettings");

                    b.Property<float>("FrequencyPenalty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(0f);

                    b.Property<int>("LastNMessagesToInclude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(5);

                    b.Property<int?>("MaxTokens")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelId")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<float>("PresencePenalty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(0f);

                    b.Property<bool>("Stream")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SystemMessage")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("TEXT");

                    b.Property<float>("Temperature")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(1f);

                    b.Property<float>("TopP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(1f);

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIImageSettings", b =>
                {
                    b.HasBaseType("Gpt.Labs.Models.OpenAISettings");

                    b.Property<int>("Size")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(2);

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAILogitBias", b =>
                {
                    b.HasOne("Gpt.Labs.Models.OpenAIChatSettings", "Settings")
                        .WithMany("LogitBias")
                        .HasForeignKey("SettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIMessage", b =>
                {
                    b.HasOne("Gpt.Labs.Models.OpenAIChat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAISettings", b =>
                {
                    b.HasOne("Gpt.Labs.Models.OpenAIChat", "Chat")
                        .WithOne("Settings")
                        .HasForeignKey("Gpt.Labs.Models.OpenAISettings", "ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIStop", b =>
                {
                    b.HasOne("Gpt.Labs.Models.OpenAIChatSettings", "Settings")
                        .WithMany("Stop")
                        .HasForeignKey("SettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIChat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Gpt.Labs.Models.OpenAIChatSettings", b =>
                {
                    b.Navigation("LogitBias");

                    b.Navigation("Stop");
                });
#pragma warning restore 612, 618
        }
    }
}
