﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(HobbyDbContext))]
    partial class HobbyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.ArticleTag", b =>
                {
                    b.Property<int>("HobbyArticleId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("HobbyArticleId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTag");
                });

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("HobbySubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HobbySubCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("HobbyArticles");
                });

            modelBuilder.Entity("Hobby_Project.HobbyCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("HobbyCategories");
                });

            modelBuilder.Entity("Hobby_Project.HobbyComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HobbyArticleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HobbyArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("HobbyComments");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HobbyCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.HasIndex("HobbyCategoryId");

                    b.ToTable("HobbySubCategories");
                });

            modelBuilder.Entity("Hobby_Project.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Hobby_Project.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entity.ArticleTag", b =>
                {
                    b.HasOne("Domain.Entity.HobbyArticle", "HobbyArticle")
                        .WithMany("HobbyTags")
                        .HasForeignKey("HobbyArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hobby_Project.Tag", "Tag")
                        .WithMany("HobbyArticles")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbyArticle");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.HasOne("Hobby_Project.HobbySubCategory", "HobbySubCategory")
                        .WithMany("HobbyArticles")
                        .HasForeignKey("HobbySubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hobby_Project.User", "User")
                        .WithMany("Hobbies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbySubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hobby_Project.HobbyComment", b =>
                {
                    b.HasOne("Domain.Entity.HobbyArticle", "HobbyArticle")
                        .WithMany("HobbyComments")
                        .HasForeignKey("HobbyArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hobby_Project.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HobbyArticle");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.HasOne("Hobby_Project.HobbyCategory", "HobbyCategory")
                        .WithMany("HobbySubCategories")
                        .HasForeignKey("HobbyCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HobbyCategory");
                });

            modelBuilder.Entity("Domain.Entity.HobbyArticle", b =>
                {
                    b.Navigation("HobbyComments");

                    b.Navigation("HobbyTags");
                });

            modelBuilder.Entity("Hobby_Project.HobbyCategory", b =>
                {
                    b.Navigation("HobbySubCategories");
                });

            modelBuilder.Entity("Hobby_Project.HobbySubCategory", b =>
                {
                    b.Navigation("HobbyArticles");
                });

            modelBuilder.Entity("Hobby_Project.Tag", b =>
                {
                    b.Navigation("HobbyArticles");
                });

            modelBuilder.Entity("Hobby_Project.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Hobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
