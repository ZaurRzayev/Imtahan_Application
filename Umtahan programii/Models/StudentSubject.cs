using System.ComponentModel.DataAnnotations;

namespace Umtahan_programii.Models
{
    public class StudentSubject
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        [MaxLength(3)]
        public string SubjectCode { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
