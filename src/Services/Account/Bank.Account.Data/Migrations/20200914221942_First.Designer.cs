﻿// <auto-generated />
using System;
using Bank.Account.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bank.Account.Data.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20200914221942_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bank.Account.Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AccountBalance")
                        .HasColumnType("decimal(18,3)");

                    b.Property<string>("AccountHolder")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("AgencyNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Account","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea48010f-9301-498d-a903-11a9d0edf110"),
                            AccountBalance = 10m,
                            AccountHolder = "João da Silva",
                            AccountNumber = "12345-x",
                            AgencyNumber = "1234-0"
                        });
                });

            modelBuilder.Entity("Bank.Account.Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int16");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Transaction","dbo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("327ac7f3-8f96-431e-8523-c83a6132bf2b"),
                            AccountId = new Guid("ea48010f-9301-498d-a903-11a9d0edf110"),
                            CreateAt = new DateTime(2020, 9, 14, 19, 19, 42, 151, DateTimeKind.Local).AddTicks(5920),
                            TransactionType = 2,
                            Value = 10m
                        });
                });

            modelBuilder.Entity("Bank.Account.Domain.Models.Transaction", b =>
                {
                    b.HasOne("Bank.Account.Domain.Models.Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
