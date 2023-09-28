﻿// <auto-generated />
using System;
using Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(ItlaTvDbContext))]
    [Migration("20230928185846_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Database.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("Genres", (string)null);
                });

            modelBuilder.Entity("Database.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers", (string)null);
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("Database.Models.SeriesGenre", b =>
                {
                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("SeriesId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("SeriesGenres");
                });

            modelBuilder.Entity("Database.Models.Genre", b =>
                {
                    b.HasOne("Database.Models.Series", null)
                        .WithMany("Genres")
                        .HasForeignKey("SeriesId");
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.HasOne("Database.Models.Producer", "Producer")
                        .WithMany("Series")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Database.Models.SeriesGenre", b =>
                {
                    b.HasOne("Database.Models.Genre", "Genre")
                        .WithMany("SeriesGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Models.Series", "Series")
                        .WithMany("SeriesGenres")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Database.Models.Genre", b =>
                {
                    b.Navigation("SeriesGenres");
                });

            modelBuilder.Entity("Database.Models.Producer", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("Database.Models.Series", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("SeriesGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
