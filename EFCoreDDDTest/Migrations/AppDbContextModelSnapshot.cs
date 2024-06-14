﻿// <auto-generated />
using System;
using EFCoreDDDTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreDDDTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreDDDTest.DDD.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_User", (string)null);
                });

            modelBuilder.Entity("EFCoreDDDTest.DDDEnum.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_Product", (string)null);
                });

            modelBuilder.Entity("EFCoreDDDTest.DDDValueObject.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("T_Blog", (string)null);
                });

            modelBuilder.Entity("EFCoreDDDTest.DDDValueObject.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("T_Shop", (string)null);
                });

            modelBuilder.Entity("EFCoreDDDTest.DDDValueObject.Blog", b =>
                {
                    b.OwnsOne("EFCoreDDDTest.DDDValueObject.MultiLangString", "Body", b1 =>
                        {
                            b1.Property<int>("BlogId")
                                .HasColumnType("int");

                            b1.Property<string>("Chinese")
                                .HasMaxLength(255)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("English")
                                .HasMaxLength(50)
                                .IsUnicode(true)
                                .HasColumnType("varchar");

                            b1.HasKey("BlogId");

                            b1.ToTable("T_Blog");

                            b1.WithOwner()
                                .HasForeignKey("BlogId");
                        });

                    b.OwnsOne("EFCoreDDDTest.DDDValueObject.MultiLangString", "Title", b1 =>
                        {
                            b1.Property<int>("BlogId")
                                .HasColumnType("int");

                            b1.Property<string>("Chinese")
                                .HasMaxLength(255)
                                .IsUnicode(true)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("English")
                                .HasMaxLength(50)
                                .IsUnicode(true)
                                .HasColumnType("varchar");

                            b1.HasKey("BlogId");

                            b1.ToTable("T_Blog");

                            b1.WithOwner()
                                .HasForeignKey("BlogId");
                        });

                    b.Navigation("Body")
                        .IsRequired();

                    b.Navigation("Title")
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreDDDTest.DDDValueObject.Shop", b =>
                {
                    b.OwnsOne("EFCoreDDDTest.DDDValueObject.Geo", "Location", b1 =>
                        {
                            b1.Property<int>("ShopId")
                                .HasColumnType("int");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("ShopId");

                            b1.ToTable("T_Shop");

                            b1.WithOwner()
                                .HasForeignKey("ShopId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}