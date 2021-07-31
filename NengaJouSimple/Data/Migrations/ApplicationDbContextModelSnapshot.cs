﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NengaJouSimple.Data;

namespace NengaJouSimple.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsPrintTarget")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainNameKana")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
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

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.AddressCardLayout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddresseeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FontFamilyName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PostalCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegisterdDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SenderAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SenderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SenderPostalCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AddresseeId");

                    b.HasIndex("PostalCodeId");

                    b.HasIndex("SenderAddressId");

                    b.HasIndex("SenderId");

                    b.HasIndex("SenderPostalCodeId");

                    b.ToTable("AddressCardLayouts");
                });

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.TextLayout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegisterdDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TextLayoutKind")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TextLayouts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TextLayout");
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

                    b.Property<string>("MainName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainNameKana")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
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

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.PostalCodeTextLayout", b =>
                {
                    b.HasBaseType("NengaJouSimple.Models.Layouts.TextLayout");

                    b.Property<double>("SpaceBetweenEachWard")
                        .HasColumnType("REAL");

                    b.Property<double>("SpaceBetweenMainWardAndTownWard")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("PostalCodeTextLayout");
                });

            modelBuilder.Entity("NengaJouSimple.Models.AddressCard", b =>
                {
                    b.HasOne("NengaJouSimple.Models.SenderAddressCard", "SenderAddressCard")
                        .WithMany()
                        .HasForeignKey("SenderAddressCardId");

                    b.Navigation("SenderAddressCard");
                });

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.AddressCardLayout", b =>
                {
                    b.HasOne("NengaJouSimple.Models.Layouts.TextLayout", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("NengaJouSimple.Models.Layouts.TextLayout", "Addressee")
                        .WithMany()
                        .HasForeignKey("AddresseeId");

                    b.HasOne("NengaJouSimple.Models.Layouts.PostalCodeTextLayout", "PostalCode")
                        .WithMany()
                        .HasForeignKey("PostalCodeId");

                    b.HasOne("NengaJouSimple.Models.Layouts.TextLayout", "SenderAddress")
                        .WithMany()
                        .HasForeignKey("SenderAddressId");

                    b.HasOne("NengaJouSimple.Models.Layouts.TextLayout", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("NengaJouSimple.Models.Layouts.PostalCodeTextLayout", "SenderPostalCode")
                        .WithMany()
                        .HasForeignKey("SenderPostalCodeId");

                    b.Navigation("Address");

                    b.Navigation("Addressee");

                    b.Navigation("PostalCode");

                    b.Navigation("Sender");

                    b.Navigation("SenderAddress");

                    b.Navigation("SenderPostalCode");
                });

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.TextLayout", b =>
                {
                    b.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b1 =>
                        {
                            b1.Property<int>("TextLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<double>("FontSize")
                                .HasColumnType("REAL");

                            b1.Property<int>("FontStyle")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("FontWeight")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("VerticalAlignment")
                                .HasColumnType("INTEGER");

                            b1.HasKey("TextLayoutId");

                            b1.ToTable("Fonts");

                            b1.WithOwner()
                                .HasForeignKey("TextLayoutId");
                        });

                    b.Navigation("Font");
                });
#pragma warning restore 612, 618
        }
    }
}
