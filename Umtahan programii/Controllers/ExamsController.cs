using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Umtahan_programii.Data;
using Umtahan_programii.Models;
using Newtonsoft.Json;


namespace Umtahan_programii.Controllers
{
    public class ExamsController : Controller
    {
        private readonly SchoolContext _context;

        public ExamsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Exams
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Exams.Include(e => e.Student).Include(e => e.Subject);
            return View(await schoolContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            Exam exam = new Exam(); // Assuming Exam is a model class

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode");

            ViewBag.Subjects = _context.Subjects
                .Select(s => new SelectListItem { Value = s.SubjectCode.ToString(), Text = s.NameOfSubject })
                .ToList();

            ViewBag.Students = _context.Students
                .Select(s => new SelectListItem { Value = s.StudentId.ToString(), Text = s.FullName })
                .ToList();

            var selectedSubjectCode = Request.Query["SubjectCode"];
            var subjects = _context.Subjects.ToList();
            var students = _context.Students.ToList();

            if (!string.IsNullOrEmpty(selectedSubjectCode))
            {
                var selectedSubject = subjects.FirstOrDefault(s => s.SubjectCode == selectedSubjectCode);
                if (selectedSubject != null)
                {
                    var subjectClass = selectedSubject.Class;
                    students = students.Where(s => s.Class == subjectClass).ToList();
                }
            }

            ViewBag.FilteredStudents = new SelectList(students, "StudentId", "FullName");

            return View("Create", new ViewBagStudentSubject
            {
                Exam = exam,
                Students = new SelectList(students, "StudentId", "FullName"),
                Subjects = new SelectList(subjects, "SubjectCode", "NameOfSubject")
                // Other properties you might need in the view model
            });
        }


        //public IActionResult Create()
        //{
        //    Exam exam = new Exam(); // Assuming 'Exam' is a class and initializing a new instance
        //    ViewBagStudentSubject wbs = new ViewBagStudentSubject();

        //    // Retrieving subject codes from the database and setting up SelectList and ViewBag
        //    ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode");
        //    ViewBag.Subjects = _context.Subjects
        //        .Select(s => new SelectListItem { Value = s.SubjectCode.ToString(), Text = s.NameOfSubject })
        //        .ToList();

        //    var selectedSubjectCode = exam.SubjectCode;

        //    // Check if the selectedSubjectCode is not null or empty and fetch the subject
        //    if (!string.IsNullOrEmpty(selectedSubjectCode))
        //    {
        //        var selectedSubject = _context.Subjects.FirstOrDefault(s => s.SubjectCode == selectedSubjectCode);

        //        if (selectedSubject != null)
        //        {
        //            var subjectClass = selectedSubject.Class;

        //            // Log to check selectedSubjectCode, selectedSubject, and subjectClass
        //            Console.WriteLine($"selectedSubjectCode: {selectedSubjectCode}");
        //            Console.WriteLine($"selectedSubject: {selectedSubject}");
        //            Console.WriteLine($"subjectClass: {subjectClass}");

        //            var studentSubjectMappings = _context.Students
        //                .Where(s => s.Class == subjectClass)
        //                .Select(s => new ViewBagStudentSubject
        //                {
        //                    StudentId = s.StudentId,
        //                    SubjectCode = selectedSubjectCode,
        //                    Student = s,
        //                    Subject = selectedSubject,
        //                    Class = s.Class,
        //                    Exam = exam // Assigning the 'exam' object to the 'Exam' property
        //                })
        //                .ToList();

        //            // Log the number of students found
        //            Console.WriteLine($"Number of students found: {studentSubjectMappings.Count}");

        //            ViewBag.Students = studentSubjectMappings
        //                .Select(s => new SelectListItem { Value = s.StudentId.ToString(), Text = s.Student.FullName })
        //                .ToList();
        //        }
        //    }


        //    // Passing the entire ViewBagStudentSubject object to the view
        //    ViewBag.ViewBagStudentSubject = new ViewBagStudentSubject
        //    {
        //        Exam = exam,
        //        Students = ViewBag.Students
        //    };

        //    wbs.Students = ViewBag.Students; 
        //    return View(wbs); // Returning 'wbs' to the view
        //}








        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,SubjectCode,StudentId,DateOfExam,FinalResult")] Exam exam)
        {
           
                _context.Add(exam);
                
            
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode", exam.SubjectCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            

            var exam = await _context.Exams.FindAsync(id);
           
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode", exam.SubjectCode);
            return View(exam);
        }

        // POST: Exams/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExamId,SubjectCode,StudentId,DateOfExam,FinalResult")] Exam exam)
        {

            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", exam.StudentId);
            ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode", exam.SubjectCode);
            _context.Update(exam);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));

        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Exams == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Student)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Exams == null)
            {
                return Problem("Entity set 'SchoolContext.Exams'  is null.");
            }
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
          return (_context.Exams?.Any(e => e.ExamId == id)).GetValueOrDefault();
        }
    }
}
