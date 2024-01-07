using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Context;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.School).ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Schools = new SelectList(_context.Schools, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.School = _context.Schools.FirstOrDefault(s => s.Id == student.SchoolId);
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Schools = new SelectList(_context.Schools, "Id", "Name", student.SchoolId);
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            ViewBag.Schools = new SelectList(_context.Schools, "Id", "Name", student.SchoolId);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.SchoolId = student.SchoolId;
                existingStudent.School = _context.Schools.FirstOrDefault(s => s.Id == student.SchoolId);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
