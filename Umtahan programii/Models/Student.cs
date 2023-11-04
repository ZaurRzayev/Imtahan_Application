using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(30)]
        public string NameOfStudent { get; set; }
        [MaxLength(30)]
        public string SurnameOfStudent { get; set; }
        public int Class { get; set; }
        public string FullName
        {
            get { return NameOfStudent + " " + SurnameOfStudent; }
        }

        public ICollection<Exam> Exams { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
