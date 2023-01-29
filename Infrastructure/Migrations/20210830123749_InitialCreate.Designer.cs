﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20210830123749_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Core.Entities.Nezaobilazno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naziv")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Nezaobilazne");
                });

            modelBuilder.Entity("Core.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ZnamenitostId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ZnamenitostId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Core.Entities.Veomaznamenito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naziv")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Veomaznamenite");
                });

            modelBuilder.Entity("Core.Entities.Znamenitost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Aktivan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Koordinate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("NezaobilaznoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VeomaznamenitoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NezaobilaznoId");

                    b.HasIndex("VeomaznamenitoId");

                    b.ToTable("Znamenitosti");
                });

            modelBuilder.Entity("Core.Entities.Photo", b =>
                {
                    b.HasOne("Core.Entities.Znamenitost", "Znamenitost")
                        .WithMany("Photos")
                        .HasForeignKey("ZnamenitostId");

                    b.Navigation("Znamenitost");
                });

            modelBuilder.Entity("Core.Entities.Znamenitost", b =>
                {
                    b.HasOne("Core.Entities.Nezaobilazno", "Nezaobilazno")
                        .WithMany()
                        .HasForeignKey("NezaobilaznoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Veomaznamenito", "Veomaznamenito")
                        .WithMany()
                        .HasForeignKey("VeomaznamenitoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nezaobilazno");

                    b.Navigation("Veomaznamenito");
                });

            modelBuilder.Entity("Core.Entities.Znamenitost", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}