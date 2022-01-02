﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OdinXSiteMVC2.Data;

namespace OdinXSiteMVC2.Migrations
{
    [DbContext(typeof(OdinXSiteMVC2Context))]
    [Migration("20220102005912_withseed3")]
    partial class withseed3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OdinXSiteMVC2.Models.Exec", b =>
                {
                    b.Property<int>("execID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("execFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("execGamingTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("execHierarchy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("execLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("execTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastLogin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("loginAmt")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("execID");

                    b.ToTable("Exec");

                    b.HasData(
                        new
                        {
                            execID = 1,
                            execFirstName = "Dammy",
                            execGamingTag = "Gobljnn",
                            execHierarchy = "Founding",
                            execLastName = "Adebayo",
                            execTitle = "Programmer",
                            lastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            username = "Gobljnn"
                        },
                        new
                        {
                            execID = 2,
                            execFirstName = "Kitan",
                            execGamingTag = "Kitan3000",
                            execHierarchy = "Founding",
                            execLastName = "Adebowale",
                            execTitle = "Photographer",
                            lastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            username = "Kitan3000"
                        },
                        new
                        {
                            execID = 3,
                            execFirstName = "Nathan",
                            execGamingTag = "Fishboy8383",
                            execHierarchy = "Founding",
                            execLastName = "Stayer",
                            execTitle = "Community Manager",
                            lastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            username = "Fishboy8383"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
