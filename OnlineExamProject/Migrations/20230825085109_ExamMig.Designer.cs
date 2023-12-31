﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineExamProject.Models;

#nullable disable

namespace OnlineExamProject.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    [Migration("20230825085109_ExamMig")]
    partial class ExamMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineExamProject.Models.ExamResult", b =>
                {
                    b.Property<int>("ExamResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamResultId"));

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("ExamResultId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("ExamResults");
                });

            modelBuilder.Entity("OnlineExamProject.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<int>("CorrectOption")
                        .HasColumnType("int");

                    b.Property<string>("OptionText1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionText2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionText3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionText4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("OnlineExamProject.Models.UserLogin", b =>
                {
                    b.Property<int>("UserLoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserLoginId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserLoginId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("OnlineExamProject.Models.UserResponse", b =>
                {
                    b.Property<int>("UserResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserResponseId"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedOptionId")
                        .HasColumnType("int");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("UserResponseId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("UserResponses");
                });

            modelBuilder.Entity("OnlineExamProject.Models.ExamResult", b =>
                {
                    b.HasOne("OnlineExamProject.Models.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("OnlineExamProject.Models.UserResponse", b =>
                {
                    b.HasOne("OnlineExamProject.Models.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}
