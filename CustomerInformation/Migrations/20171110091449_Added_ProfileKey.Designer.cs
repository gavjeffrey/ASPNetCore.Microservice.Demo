﻿// <auto-generated />
using CustomerInformation.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CustomerInformation.Migrations
{
    [DbContext(typeof(ProfileContext))]
    [Migration("20171110091449_Added_ProfileKey")]
    partial class Added_ProfileKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerInformation.Models.Individual", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Gender")
                        .HasMaxLength(1);

                    b.Property<string>("HomeLanguage")
                        .HasMaxLength(50);

                    b.Property<string>("Initials")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("KnownAs")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("MaidenName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("MaritalStatus")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("MarriageDate");

                    b.Property<string>("MiddleNames")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("TaxNumber")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("ProfileID");

                    b.ToTable("Individual");
                });

            modelBuilder.Entity("CustomerInformation.Models.Profile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<DateTime?>("EffectiveDate");

                    b.Property<string>("KYCStatus");

                    b.Property<string>("ProfileType");

                    b.HasKey("ProfileID");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("CustomerInformation.Models.ProfileKey", b =>
                {
                    b.Property<Guid>("ProfileKeyID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProfileID");

                    b.Property<string>("ProfileKeyValue")
                        .HasMaxLength(50);

                    b.HasKey("ProfileKeyID");

                    b.ToTable("ProfileKeys");
                });

            modelBuilder.Entity("CustomerInformation.Models.Individual", b =>
                {
                    b.HasOne("CustomerInformation.Models.Profile")
                        .WithOne("Individual")
                        .HasForeignKey("CustomerInformation.Models.Individual", "ProfileID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
