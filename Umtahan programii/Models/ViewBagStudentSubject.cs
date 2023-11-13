using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class ViewBagStudentSubject
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        [MaxLength(3)]
        public string SubjectCode { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public int ExamId;
        public Exam Exam;
        public List<SelectListItem> Students { get; set; }
    }
}
