using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [MaxLength(3)]
        public string SubjectCode { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfExam { get; set; }
        public int FinalResult { get; set; }

        // Navigation properties
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
