using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Context;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class SchoolController : Controller
    {
        private readonly AppDbContext _context;

        public SchoolController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var schools = _context.Schools.ToList();
            return View(schools);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(School school)
        {
            if (ModelState.IsValid)
            {
                _context.Schools.Add(school);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(school);
        }

        public IActionResult Delete(int id)
        {
            var school = _context.Schools.FirstOrDefault(a => a.Id == id);
            _context.Schools.Remove(school);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var school = _context.Schools.FirstOrDefault(a => a.Id == id);
            return View(school);
        }

        [HttpPost]
        public IActionResult Update(School school)
        {
            var existingSchool = _context.Schools.FirstOrDefault(a => a.Id == school.Id);

            if (existingSchool != null)
            {
                existingSchool.Name = school.Name;
                existingSchool.Address = school.Address;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
