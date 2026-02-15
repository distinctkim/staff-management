using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffManagementSystem.Data;
using StaffManagementSystem.Models;
using System.Linq;

namespace StaffManagementSystem.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var staff = from s in _context.Staff select s;

            if (!string.IsNullOrEmpty(search))
            {
                staff = staff.Where(s => s.FullNames.Contains(search));
            }

            return View(staff.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public IActionResult Edit(int id)
        {
            var staff = _context.Staff.Find(id);
            return View(staff);
        }

        [HttpPost]
        public IActionResult Edit(Staff staff)
        {
            _context.Update(staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var staff = _context.Staff.Find(id);
            _context.Remove(staff);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
