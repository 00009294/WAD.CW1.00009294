﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SampleDemoWebAPI.DbContexts;

#nullable disable

namespace SampleDemoWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SampleDemoWebAPI.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.StudentSubject", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("StudentId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.StudentTeacher", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("StudentId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentTeachers");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.StudentSubject", b =>
                {
                    b.HasOne("SampleDemoWebAPI.Models.Subject", "Subject")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleDemoWebAPI.Models.Student", "Student")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.StudentTeacher", b =>
                {
                    b.HasOne("SampleDemoWebAPI.Models.Teacher", "Teacher")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleDemoWebAPI.Models.Student", "Student")
                        .WithMany("StudentTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Teacher", b =>
                {
                    b.HasOne("SampleDemoWebAPI.Models.Subject", "Subject")
                        .WithMany("Teachers")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Student", b =>
                {
                    b.Navigation("StudentSubjects");

                    b.Navigation("StudentTeachers");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Subject", b =>
                {
                    b.Navigation("StudentSubjects");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("SampleDemoWebAPI.Models.Teacher", b =>
                {
                    b.Navigation("StudentTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
