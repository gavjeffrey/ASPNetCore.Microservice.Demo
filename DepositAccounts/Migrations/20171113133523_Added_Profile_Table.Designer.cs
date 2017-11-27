﻿// <auto-generated />
using DepositAccounts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DepositAccounts.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20171113133523_Added_Profile_Table")]
    partial class Added_Profile_Table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DepositAccounts.Models.Account", b =>
                {
                    b.Property<Guid>("AccountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNo");

                    b.Property<string>("AccountOwner");

                    b.Property<string>("AccountType");

                    b.Property<bool>("Active");

                    b.Property<string>("AltAccountNo");

                    b.Property<string>("BranchCode");

                    b.Property<string>("BranchName");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DisplayName");

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<bool>("IsPrimary");

                    b.Property<string>("ProductCode");

                    b.Property<string>("ProductDisplayName");

                    b.Property<string>("ProductType");

                    b.Property<Guid>("ProfileID");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DepositAccounts.Models.Profile", b =>
                {
                    b.Property<Guid>("ProfileID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AccountCreationEnabled");

                    b.HasKey("ProfileID");

                    b.ToTable("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}