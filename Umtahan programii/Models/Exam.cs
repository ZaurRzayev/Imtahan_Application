using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [MaxLength(3)]
        [Display(Name = "Dərsin Kodu")]
        public string SubjectCode { get; set; }
        [Display(Name = "Şagird")]
        public int StudentId { get; set; }
        [Display(Name = "İmtahanın Tarixi")]
        public DateTime DateOfExam { get; set; }
        [Display(Name = "Yekun Qiymət")]
        public int FinalResult { get; set; }

        // Navigation properties
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
