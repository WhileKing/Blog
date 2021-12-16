﻿// <auto-generated />
using System;
using Blog.Core.Infrastructure.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Core.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20211216084833_addenable")]
    partial class addenable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Blog.Core.Domain.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Blog.Core.Domain.Classify", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Classify");
                });

            modelBuilder.Entity("Blog.Core.Domain.Content", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AuthorizeCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("NeedAuthorized")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("Blog.Core.Domain.CosProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<string>("AllowActions")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("AllowPrefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BucketName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("Enable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Region")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("CosProvider");
                });

            modelBuilder.Entity("Blog.Core.Domain.TencentCloudAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AppId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecretId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecretKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("TencentCloudAccount");
                });

            modelBuilder.Entity("Blog.Core.Domain.Article", b =>
                {
                    b.HasBaseType("Blog.Core.Domain.Content");

                    b.Property<string>("Categories")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Blog.Core.Domain.FavoriteLink", b =>
                {
                    b.HasBaseType("Blog.Core.Domain.Content");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.ToTable("FavoriteLink");
                });

            modelBuilder.Entity("Blog.Core.Domain.CosProvider", b =>
                {
                    b.HasOne("Blog.Core.Domain.TencentCloudAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Blog.Core.Domain.Article", b =>
                {
                    b.HasOne("Blog.Core.Domain.Content", null)
                        .WithOne()
                        .HasForeignKey("Blog.Core.Domain.Article", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blog.Core.Domain.FavoriteLink", b =>
                {
                    b.HasOne("Blog.Core.Domain.Content", null)
                        .WithOne()
                        .HasForeignKey("Blog.Core.Domain.FavoriteLink", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
