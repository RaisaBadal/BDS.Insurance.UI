﻿// <auto-generated />
using System;
using BDS.Insurance.Core.DBContexti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BDS.Insurance.Core.Migrations
{
    [DbContext(typeof(DbBds))]
    [Migration("20231209205019_ew")]
    partial class ew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BDS.Insurance.Core.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineType")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("VinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Error", b =>
                {
                    b.Property<int>("ErrorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ErrorID"));

                    b.Property<int>("ErrorType")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeofOccured")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorID");

                    b.ToTable("Errors");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeofOccured")
                        .HasColumnType("datetime2");

                    b.HasKey("LogId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CarAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("PolicyAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PolicyEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PolicyStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarID")
                        .IsUnique();

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.PolicySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.Property<decimal>("amount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicySchedule");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models._2StepVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GenerateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("jwtToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("_2StepVerification");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Car", b =>
                {
                    b.HasOne("BDS.Insurance.Core.Models.User", "user")
                        .WithMany("car")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Policy", b =>
                {
                    b.HasOne("BDS.Insurance.Core.Models.Car", "car")
                        .WithOne("policy")
                        .HasForeignKey("BDS.Insurance.Core.Models.Policy", "CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.PolicySchedule", b =>
                {
                    b.HasOne("BDS.Insurance.Core.Models.Policy", "policy")
                        .WithMany("Schedules")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("policy");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models._2StepVerification", b =>
                {
                    b.HasOne("BDS.Insurance.Core.Models.User", "user")
                        .WithMany("_2StepVerification")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Car", b =>
                {
                    b.Navigation("policy")
                        .IsRequired();
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.Policy", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("BDS.Insurance.Core.Models.User", b =>
                {
                    b.Navigation("_2StepVerification");

                    b.Navigation("car");
                });
#pragma warning restore 612, 618
        }
    }
}
