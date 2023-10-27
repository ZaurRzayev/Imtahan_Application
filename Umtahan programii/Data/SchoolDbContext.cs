using Microsoft.EntityFrameworkCore;
using Umtahan_programii.Models;

namespace Umtahan_programii.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }


        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationships between entities

            // Many-to-Many relationship between Student and Subject
            modelBuilder.Entity<StudentSubject>()
        .HasKey(ss => new { ss.StudentId, ss.SubjectCode });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(sub => sub.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectCode);

            // One-to-Many relationship between Subject and Exam
            modelBuilder.Entity<Subject>()
                .HasMany(sub => sub.Exams)
                .WithOne(exam => exam.Subject)
                .HasForeignKey(exam => exam.SubjectCode);

            // One-to-Many relationship between Student and Exam
            modelBuilder.Entity<Student>()
                .HasMany(st => st.Exams)
                .WithOne(exam => exam.Student)
                .HasForeignKey(exam => exam.StudentId);
        }

    }
}
