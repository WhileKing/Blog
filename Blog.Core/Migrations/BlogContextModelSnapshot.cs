﻿// <auto-generated />
using System;
using Blog.Core.Infrastructure.Orm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Core.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Blog.Core.Domain.Content", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("AuthorizeCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime");

                    b.Property<bool>("NeedAuthorized")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("Blog.Core.Domain.FavoriteLink", b =>
                {
                    b.HasBaseType("Blog.Core.Domain.Content");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.ToTable("FavoriteLink");
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
