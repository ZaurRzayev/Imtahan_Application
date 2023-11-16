using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Umtahan_programii.Models
{
    public class ViewBagStudentSubject
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Class { get; set; }
        //public List<SelectListItem> Students { get; set; }
        public SelectList Students { get; set; }
        public SelectList Subjects { get; set; }
    }
}
