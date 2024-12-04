﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using feedback.Data;

#nullable disable

namespace feedback.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241204052347_InitialCre")]
    partial class InitialCre
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("feedback.Models.Form", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question1EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions10EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions11EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions12EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions13EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions14EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions15EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions16EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions2EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions3EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions4EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions5EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions6EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions7EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions8EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Questions9EN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Form");
                });

            modelBuilder.Entity("feedback.Models.FormEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AgeGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Locale")
                        .HasColumnType("int");

                    b.Property<string>("OpenQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale10")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale11")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale12")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale13")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale6")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale7")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale8")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale9")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormEntry");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
