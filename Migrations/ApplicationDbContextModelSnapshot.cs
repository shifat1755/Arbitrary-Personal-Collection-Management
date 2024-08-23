﻿// <auto-generated />
using System;
using APCM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APCM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APCM.Models.Entities.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("APCM.Models.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("APCM.Models.Entities.CustomField", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("CustomFields");
                });

            modelBuilder.Entity("APCM.Models.Entities.CustomFieldValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("CustomFieldValues");
                });

            modelBuilder.Entity("APCM.Models.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("APCM.Models.Entities.Like", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("APCM.Models.Entities.Tag", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("hashTags");
                });

            modelBuilder.Entity("APCM.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.Property<string>("TagsName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("itemsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TagsName", "itemsId");

                    b.HasIndex("itemsId");

                    b.ToTable("ItemTag");
                });

            modelBuilder.Entity("APCM.Models.Entities.Collection", b =>
                {
                    b.HasOne("APCM.Models.Entities.User", null)
                        .WithMany("Collections")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APCM.Models.Entities.Comment", b =>
                {
                    b.HasOne("APCM.Models.Entities.Item", null)
                        .WithMany("Comments")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APCM.Models.Entities.CustomField", b =>
                {
                    b.HasOne("APCM.Models.Entities.Collection", null)
                        .WithMany("CustomFields")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APCM.Models.Entities.CustomFieldValue", b =>
                {
                    b.HasOne("APCM.Models.Entities.Item", null)
                        .WithMany("CustomFieldValues")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("APCM.Models.Entities.Item", b =>
                {
                    b.HasOne("APCM.Models.Entities.Collection", null)
                        .WithMany("Items")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APCM.Models.Entities.Like", b =>
                {
                    b.HasOne("APCM.Models.Entities.Item", null)
                        .WithMany("Likes")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItemTag", b =>
                {
                    b.HasOne("APCM.Models.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APCM.Models.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("itemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APCM.Models.Entities.Collection", b =>
                {
                    b.Navigation("CustomFields");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("APCM.Models.Entities.Item", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("CustomFieldValues");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("APCM.Models.Entities.User", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
