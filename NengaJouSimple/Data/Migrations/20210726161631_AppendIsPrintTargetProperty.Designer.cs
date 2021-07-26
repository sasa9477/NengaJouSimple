﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NengaJouSimple.Data;

namespace NengaJouSimple.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210726161631_AppendIsPrintTargetProperty")]
    partial class AppendIsPrintTargetProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("NengaJouSimple.Models.AddressCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address3")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPrintTarget")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainNameKana")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterdDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei5")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SenderAddressCardId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SenderAddressCardId");

                    b.ToTable("AddressCards");
                });

            modelBuilder.Entity("NengaJouSimple.Models.SenderAddressCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address3")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainNameKana")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterdDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei3")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei4")
                        .HasColumnType("TEXT");

                    b.Property<string>("Renmei5")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SenderAddressCards");
                });

            modelBuilder.Entity("NengaJouSimple.Models.AddressCard", b =>
                {
                    b.HasOne("NengaJouSimple.Models.SenderAddressCard", "SenderAddressCard")
                        .WithMany()
                        .HasForeignKey("SenderAddressCardId");

                    b.Navigation("SenderAddressCard");
                });
#pragma warning restore 612, 618
        }
    }
}
