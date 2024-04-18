﻿// <auto-generated />
using System;
using Lab10.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lab10.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240418072323_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Lab10.DataBase.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AviaryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Eats")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AviaryId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Lab10.DataBase.Aviary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Aviaries");
                });

            modelBuilder.Entity("Lab10.DataBase.Animal", b =>
                {
                    b.HasOne("Lab10.DataBase.Aviary", "Aviary")
                        .WithMany()
                        .HasForeignKey("AviaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aviary");
                });
#pragma warning restore 612, 618
        }
    }
}
