using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MaxLength(30)]
        [Display(Name = "Şagirdin Adı")]
        public string NameOfStudent { get; set; }
        [MaxLength(30)]
        [Display(Name = "Şagirdin Soyadı")]
        public string SurnameOfStudent { get; set; }
        [Display(Name = "Sinif")]
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
