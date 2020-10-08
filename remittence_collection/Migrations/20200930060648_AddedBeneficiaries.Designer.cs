﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using remittence_collection.Repository;

namespace remittence_collection.Migrations
{
    [DbContext(typeof(RemittenceCollectionContext))]
    [Migration("20200930060648_AddedBeneficiaries")]
    partial class AddedBeneficiaries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("remittence_collection.Models.Beneficiary", b =>
                {
                    b.Property<string>("BeneficiaryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("RelationWithRemitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RemitterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("BeneficiaryId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("RemitterId");

                    b.HasIndex("StateId");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("remittence_collection.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("remittence_collection.Models.ID", b =>
                {
                    b.Property<string>("IDNo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExpiryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDTypeId")
                        .HasColumnType("int");

                    b.Property<string>("IssueDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNo");

                    b.HasIndex("IDTypeId");

                    b.ToTable("IDs");
                });

            modelBuilder.Entity("remittence_collection.Models.IDType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IDTypes");
                });

            modelBuilder.Entity("remittence_collection.Models.Remitter", b =>
                {
                    b.Property<string>("RemitterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ActionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateofBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IncomeRange")
                        .HasColumnType("float");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.Property<string>("NatureOfJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryIDid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RemitterTypeId")
                        .HasColumnType("int");

                    b.Property<string>("SecondaryIDid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("YearlyExpVolOfRemittence")
                        .HasColumnType("float");

                    b.HasKey("RemitterId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("PrimaryIDid");

                    b.HasIndex("RemitterTypeId");

                    b.HasIndex("SecondaryIDid");

                    b.ToTable("Remitters");
                });

            modelBuilder.Entity("remittence_collection.Models.RemitterType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RemitterTypes");
                });

            modelBuilder.Entity("remittence_collection.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("remittence_collection.Models.Beneficiary", b =>
                {
                    b.HasOne("remittence_collection.Models.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("remittence_collection.Models.Remitter", "Remitter")
                        .WithMany()
                        .HasForeignKey("RemitterId");

                    b.HasOne("remittence_collection.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("remittence_collection.Models.ID", b =>
                {
                    b.HasOne("remittence_collection.Models.IDType", "IDType")
                        .WithMany()
                        .HasForeignKey("IDTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("remittence_collection.Models.Remitter", b =>
                {
                    b.HasOne("remittence_collection.Models.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("remittence_collection.Models.ID", "PrimaryID")
                        .WithMany()
                        .HasForeignKey("PrimaryIDid");

                    b.HasOne("remittence_collection.Models.RemitterType", "RemitterType")
                        .WithMany()
                        .HasForeignKey("RemitterTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("remittence_collection.Models.ID", "SecondaryID")
                        .WithMany()
                        .HasForeignKey("SecondaryIDid");
                });

            modelBuilder.Entity("remittence_collection.Models.State", b =>
                {
                    b.HasOne("remittence_collection.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
