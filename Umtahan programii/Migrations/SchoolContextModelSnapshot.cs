﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Umtahan_programii.Data;

#nullable disable

namespace Umtahan_programii.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Umtahan_programii.Models.Exam", b =>
                {
                    b.Property<int>("ExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamId"));

                    b.Property<DateTime>("DateOfExam")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinalResult")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("ExamId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectCode");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Umtahan_programii.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("NameOfStudent")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SurnameOfStudent")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Umtahan_programii.Models.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("StudentId", "SubjectCode");

                    b.HasIndex("SubjectCode");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("Umtahan_programii.Models.Subject", b =>
                {
                    b.Property<string>("SubjectCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("NameOfSubject")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NameOfTeacher")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SurnameOfTeacher")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SubjectCode");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Umtahan_programii.Models.Exam", b =>
                {
                    b.HasOne("Umtahan_programii.Models.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Umtahan_programii.Models.Subject", "Subject")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Umtahan_programii.Models.StudentSubject", b =>
                {
                    b.HasOne("Umtahan_programii.Models.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Umtahan_programii.Models.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Umtahan_programii.Models.Student", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("Umtahan_programii.Models.Subject", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("StudentSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
