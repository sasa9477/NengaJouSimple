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

            modelBuilder.Entity("NengaJouSimple.Models.Addresses.AddressCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAlreadyPrinted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPrintTarget")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MainName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MainNameKana")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PrintedDateTime")
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

            modelBuilder.Entity("NengaJouSimple.Models.Addresses.SenderAddressCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
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

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.AddressCardLayout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrintMarginLeft")
                        .HasColumnType("REAL");

                    b.Property<double>("PrintMarginTop")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("RegisterdDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AddressCardLayouts");
                });

            modelBuilder.Entity("NengaJouSimple.Models.Addresses.AddressCard", b =>
                {
                    b.HasOne("NengaJouSimple.Models.Addresses.SenderAddressCard", "SenderAddressCard")
                        .WithMany()
                        .HasForeignKey("SenderAddressCardId");

                    b.Navigation("SenderAddressCard");
                });

            modelBuilder.Entity("NengaJouSimple.Models.Layouts.AddressCardLayout", b =>
                {
                    b.OwnsOne("NengaJouSimple.Models.Layouts.PostalCodeTextLayout", "PostalCode", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<double>("SpaceBetweenMailWardAndTownWard")
                                .HasColumnType("REAL");

                            b1.Property<double>("SpaceBetweenMailWardEachWard")
                                .HasColumnType("REAL");

                            b1.Property<double>("SpaceBetweenTownWardEachWard")
                                .HasColumnType("REAL");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("PostalCodeTextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("PostalCodeTextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("PostalCodeTextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.OwnsOne("NengaJouSimple.Models.Layouts.PostalCodeTextLayout", "SenderPostalCode", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<double>("SpaceBetweenMailWardAndTownWard")
                                .HasColumnType("REAL");

                            b1.Property<double>("SpaceBetweenMailWardEachWard")
                                .HasColumnType("REAL");

                            b1.Property<double>("SpaceBetweenTownWardEachWard")
                                .HasColumnType("REAL");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("PostalCodeTextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("PostalCodeTextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("PostalCodeTextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.OwnsOne("NengaJouSimple.Models.Layouts.TextLayout", "Address", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("TextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("TextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("TextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.OwnsOne("NengaJouSimple.Models.Layouts.TextLayout", "Addressee", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("TextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("TextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("TextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.OwnsOne("NengaJouSimple.Models.Layouts.TextLayout", "Sender", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("TextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("TextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("TextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.OwnsOne("NengaJouSimple.Models.Layouts.TextLayout", "SenderAddress", b1 =>
                        {
                            b1.Property<int>("AddressCardLayoutId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Position")
                                .HasColumnType("TEXT");

                            b1.Property<int>("TextLayoutKind")
                                .HasColumnType("INTEGER");

                            b1.HasKey("AddressCardLayoutId");

                            b1.ToTable("AddressCardLayouts");

                            b1.WithOwner()
                                .HasForeignKey("AddressCardLayoutId");

                            b1.OwnsOne("NengaJouSimple.Models.Layouts.Font", "Font", b2 =>
                                {
                                    b2.Property<int>("TextLayoutAddressCardLayoutId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("FontFamilyName")
                                        .HasColumnType("TEXT");

                                    b2.Property<double>("FontSize")
                                        .HasColumnType("REAL");

                                    b2.Property<int>("FontStyle")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("FontWeight")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("VerticalAlignment")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("TextLayoutAddressCardLayoutId");

                                    b2.ToTable("AddressCardLayouts");

                                    b2.WithOwner()
                                        .HasForeignKey("TextLayoutAddressCardLayoutId");
                                });

                            b1.Navigation("Font");
                        });

                    b.Navigation("Address");

                    b.Navigation("Addressee");

                    b.Navigation("PostalCode");

                    b.Navigation("Sender");

                    b.Navigation("SenderAddress");

                    b.Navigation("SenderPostalCode");
                });
#pragma warning restore 612, 618
        }
    }
}
