﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContex))]
    [Migration("20240502003638_Locations")]
    partial class Locations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Main")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("URLImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("API.Entities.ClassificationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClassificationItems");
                });

            modelBuilder.Entity("API.Entities.Conversion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Factor")
                        .HasColumnType("real");

                    b.Property<string>("Formula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SourceUnitId")
                        .HasColumnType("int");

                    b.Property<int>("TargetUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SourceUnitId");

                    b.HasIndex("TargetUnitId");

                    b.ToTable("Conversions");
                });

            modelBuilder.Entity("API.Entities.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryCode");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("API.Entities.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abstrac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublisher")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserUploaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserUploaderId");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("itemId"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassificationItemId")
                        .HasColumnType("int");

                    b.Property<string>("MoreInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("itemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassificationItemId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("API.Entities.Place", b =>
                {
                    b.Property<int>("PlaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaceID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatLon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("PlaceID");

                    b.HasIndex("StateId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("API.Entities.Point", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PointId"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LatLon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("URLImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PointId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("API.Entities.QualityStandard", b =>
                {
                    b.Property<int>("QSId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QSId"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QSId");

                    b.ToTable("QualityStandards");
                });

            modelBuilder.Entity("API.Entities.QualityStandardItem", b =>
                {
                    b.Property<int>("QSIId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QSIId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("LatLog")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("LowerLim")
                        .HasColumnType("real");

                    b.Property<int>("QSId")
                        .HasColumnType("int");

                    b.Property<int?>("QualityStandardQSId")
                        .HasColumnType("int");

                    b.Property<int>("SemaphoreId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<float>("UpperLim")
                        .HasColumnType("real");

                    b.HasKey("QSIId");

                    b.HasIndex("ItemId");

                    b.HasIndex("QualityStandardQSId");

                    b.HasIndex("SemaphoreId");

                    b.HasIndex("UnitId");

                    b.ToTable("QualityStandardItems");
                });

            modelBuilder.Entity("API.Entities.Semaphore", b =>
                {
                    b.Property<int>("SemaphoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemaphoreId"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemaphoreId");

                    b.ToTable("Semaphore");
                });

            modelBuilder.Entity("API.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CountryCode1")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryCode1");

                    b.ToTable("State");
                });

            modelBuilder.Entity("API.Entities.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("API.Entities.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SurveyId"));

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("PointId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SurveyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SurveyId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("PointId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("API.Entities.SurveyItem", b =>
                {
                    b.Property<int>("SIId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SIId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("LabName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Preferent")
                        .HasColumnType("bit");

                    b.Property<string>("Responsible")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SurveyId")
                        .HasColumnType("int");

                    b.Property<int>("UnitBaseId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<float>("ValueBase")
                        .HasColumnType("real");

                    b.HasKey("SIId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UnitBaseId");

                    b.HasIndex("UnitId");

                    b.ToTable("SurveyItems");
                });

            modelBuilder.Entity("API.Entities.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Abbr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BaseUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnitId");

                    b.HasIndex("BaseUnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Conversion", b =>
                {
                    b.HasOne("API.Entities.Unit", "SourceUnit")
                        .WithMany("ConversionSources")
                        .HasForeignKey("SourceUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Entities.Unit", "TargetUnit")
                        .WithMany("ConversionTargets")
                        .HasForeignKey("TargetUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SourceUnit");

                    b.Navigation("TargetUnit");
                });

            modelBuilder.Entity("API.Entities.Documento", b =>
                {
                    b.HasOne("API.Entities.User", null)
                        .WithMany("DocumentUpdates")
                        .HasForeignKey("UserId");

                    b.HasOne("API.Entities.User", "UserUploader")
                        .WithMany("Documents")
                        .HasForeignKey("UserUploaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserUploader");
                });

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.HasOne("API.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.ClassificationItem", "Classification")
                        .WithMany("Items")
                        .HasForeignKey("ClassificationItemId");

                    b.HasOne("API.Entities.Unit", "Unit")
                        .WithMany("Items")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Classification");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Entities.Place", b =>
                {
                    b.HasOne("API.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.SubCategory", "SubCategory")
                        .WithMany("Places")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("API.Entities.Point", b =>
                {
                    b.HasOne("API.Entities.Place", "Place")
                        .WithMany("Points")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("API.Entities.QualityStandardItem", b =>
                {
                    b.HasOne("API.Entities.Item", "Item")
                        .WithMany("QualityStandardItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.QualityStandard", "QualityStandard")
                        .WithMany("QualityStandardItems")
                        .HasForeignKey("QualityStandardQSId");

                    b.HasOne("API.Entities.Semaphore", "Semaphore")
                        .WithMany("QualityStandardItems")
                        .HasForeignKey("SemaphoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Unit", "Unit")
                        .WithMany("QualityStandardItems")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("QualityStandard");

                    b.Navigation("Semaphore");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("API.Entities.State", b =>
                {
                    b.HasOne("API.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryCode1");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("API.Entities.SubCategory", b =>
                {
                    b.HasOne("API.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("API.Entities.Survey", b =>
                {
                    b.HasOne("API.Entities.User", "CreatedBy")
                        .WithMany("Surveys")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Point", "Point")
                        .WithMany("Surveries")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("API.Entities.SurveyItem", b =>
                {
                    b.HasOne("API.Entities.Item", "Item")
                        .WithMany("SurveyItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Survey", "Survey")
                        .WithMany("SurveyItems")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Unit", "UnitBase")
                        .WithMany("SurveyItemBases")
                        .HasForeignKey("UnitBaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Entities.Unit", "Unit")
                        .WithMany("SurveyItems")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Survey");

                    b.Navigation("Unit");

                    b.Navigation("UnitBase");
                });

            modelBuilder.Entity("API.Entities.Unit", b =>
                {
                    b.HasOne("API.Entities.Unit", "BaseUnit")
                        .WithMany()
                        .HasForeignKey("BaseUnitId");

                    b.Navigation("BaseUnit");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("API.Entities.ClassificationItem", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("API.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("API.Entities.Item", b =>
                {
                    b.Navigation("QualityStandardItems");

                    b.Navigation("SurveyItems");
                });

            modelBuilder.Entity("API.Entities.Place", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("API.Entities.Point", b =>
                {
                    b.Navigation("Surveries");
                });

            modelBuilder.Entity("API.Entities.QualityStandard", b =>
                {
                    b.Navigation("QualityStandardItems");
                });

            modelBuilder.Entity("API.Entities.Semaphore", b =>
                {
                    b.Navigation("QualityStandardItems");
                });

            modelBuilder.Entity("API.Entities.SubCategory", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("API.Entities.Survey", b =>
                {
                    b.Navigation("SurveyItems");
                });

            modelBuilder.Entity("API.Entities.Unit", b =>
                {
                    b.Navigation("ConversionSources");

                    b.Navigation("ConversionTargets");

                    b.Navigation("Items");

                    b.Navigation("QualityStandardItems");

                    b.Navigation("SurveyItemBases");

                    b.Navigation("SurveyItems");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Navigation("DocumentUpdates");

                    b.Navigation("Documents");

                    b.Navigation("Surveys");
                });
#pragma warning restore 612, 618
        }
    }
}
