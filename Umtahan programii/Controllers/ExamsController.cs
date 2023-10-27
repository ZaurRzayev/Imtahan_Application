using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Umtahan_programii.Data;
using Umtahan_programii.Models;

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
            Exam exam = new();
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            ViewData["SubjectCode"] = new SelectList(_context.Subjects, "SubjectCode", "SubjectCode");
            return View(exam);
        }

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

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
