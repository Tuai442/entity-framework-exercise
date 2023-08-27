﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkDataLayer;

#nullable disable

namespace ParkDataLayer.Migrations
{
    [DbContext(typeof(ParkbeheerContext))]
    [Migration("20230102163116_iniy")]
    partial class iniy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuisEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HuisActief")
                        .HasColumnType("bit");

                    b.Property<int>("Nummer")
                        .HasColumnType("int");

                    b.Property<string>("ParkId")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("ParkId");

                    b.ToTable("Huis");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuurderContractEF", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("AantalDagen")
                        .HasColumnType("int");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("HuisId")
                        .HasColumnType("int");

                    b.Property<int>("HuurderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HuisId");

                    b.HasIndex("HuurderId");

                    b.ToTable("HuurderContract");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuurderEF", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefoon")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Huurder");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.ParkEF", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ParkNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Park");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuisEF", b =>
                {
                    b.HasOne("ParkBeheerEFLayer.Model.ParkEF", "ParkEF")
                        .WithMany("HuizenEF")
                        .HasForeignKey("ParkId");

                    b.Navigation("ParkEF");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuurderContractEF", b =>
                {
                    b.HasOne("ParkBeheerEFLayer.Model.HuisEF", "HuisEF")
                        .WithMany()
                        .HasForeignKey("HuisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ParkBeheerEFLayer.Model.HuurderEF", "HuurderEF")
                        .WithMany("HuurderContractEF")
                        .HasForeignKey("HuurderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HuisEF");

                    b.Navigation("HuurderEF");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.HuurderEF", b =>
                {
                    b.Navigation("HuurderContractEF");
                });

            modelBuilder.Entity("ParkBeheerEFLayer.Model.ParkEF", b =>
                {
                    b.Navigation("HuizenEF");
                });
#pragma warning restore 612, 618
        }
    }
}