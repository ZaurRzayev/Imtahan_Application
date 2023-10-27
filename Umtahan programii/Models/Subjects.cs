using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class Subject
    {
        [Key]
        [MaxLength(3)]
        public string SubjectCode { get; set; }
        [MaxLength(30)]
        public string NameOfSubject { get; set; }
        public int Class { get; set; }
        [MaxLength(20)]
        public string NameOfTeacher { get; set; }
        [MaxLength(20)]
        public string SurnameOfTeacher { get; set; }

        public ICollection<Exam> Exams { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
