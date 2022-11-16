﻿// <auto-generated />
using System;
using DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DB.Migrations
{
    [DbContext(typeof(AplicationContext))]
    partial class AplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DB.Models.Pokemones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionPokemon")
                        .HasColumnType("int");

                    b.Property<int>("Type1")
                        .HasColumnType("int");

                    b.Property<int?>("Type2")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("RegionPokemon");

                    b.HasIndex("Type1");

                    b.HasIndex("Type2");

                    b.HasIndex("name")
                        .IsUnique();

                    b.ToTable("Pokemones", (string)null);
                });

            modelBuilder.Entity("DB.Models.Regiones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("NameRegion")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("NameRegion")
                        .IsUnique();

                    b.ToTable("Regiones", (string)null);
                });

            modelBuilder.Entity("DB.Models.Tipo2", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("NameTipos")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("NameTipos")
                        .IsUnique()
                        .HasFilter("[NameTipos] IS NOT NULL");

                    b.ToTable("Tipo2");
                });

            modelBuilder.Entity("DB.Models.Tipos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("NameTipos")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("NameTipos")
                        .IsUnique()
                        .HasFilter("[NameTipos] IS NOT NULL");

                    b.ToTable("Tipos", (string)null);
                });

            modelBuilder.Entity("DB.Models.Pokemones", b =>
                {
                    b.HasOne("DB.Models.Regiones", "Regiones")
                        .WithMany("Pokemones")
                        .HasForeignKey("RegionPokemon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Tipos", "Tipos")
                        .WithMany("Pokemones")
                        .HasForeignKey("Type1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DB.Models.Tipo2", "Tipos2")
                        .WithMany("Pokemones2")
                        .HasForeignKey("Type2")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Regiones");

                    b.Navigation("Tipos");

                    b.Navigation("Tipos2");
                });

            modelBuilder.Entity("DB.Models.Regiones", b =>
                {
                    b.Navigation("Pokemones");
                });

            modelBuilder.Entity("DB.Models.Tipo2", b =>
                {
                    b.Navigation("Pokemones2");
                });

            modelBuilder.Entity("DB.Models.Tipos", b =>
                {
                    b.Navigation("Pokemones");
                });
#pragma warning restore 612, 618
        }
    }
}