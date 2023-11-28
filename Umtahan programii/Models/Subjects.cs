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
        [Display(Name = "Dərsin adı")]
        public string NameOfSubject { get; set; }
        [Display(Name = "Sinif")]
        public int Class { get; set; }
        [MaxLength(20)]
        [Display(Name = "Müəllimin adı")]
        public string NameOfTeacher { get; set; }
        [MaxLength(20)]
        [Display(Name = "Müəllimin Soyadı")]
        public string SurnameOfTeacher { get; set; }

        public ICollection<Exam> Exams { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
