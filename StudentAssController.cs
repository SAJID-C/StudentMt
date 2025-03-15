using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentWeb.Data;
using StudentWeb.Models;

namespace StudentWeb.Controllers
{
    public class StudentAssController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentAssController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentAss
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StdDeptAss.Include(s => s.Dept).Include(s => s.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentAss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdDeptAss = await _context.StdDeptAss
                .Include(s => s.Dept)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdDeptAss == null)
            {
                return NotFound();
            }

            return View(stdDeptAss);
        }

        // GET: StudentAss/Create
        public IActionResult Create()
        {
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: StudentAss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,DeptId")] StdDeptAss stdDeptAss)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(stdDeptAss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Id", stdDeptAss.DeptId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", stdDeptAss.StudentId);
            return View(stdDeptAss);
        }

        // GET: StudentAss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdDeptAss = await _context.StdDeptAss.FindAsync(id);
            if (stdDeptAss == null)
            {
                return NotFound();
            }
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Id", stdDeptAss.DeptId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", stdDeptAss.StudentId);
            return View(stdDeptAss);
        }

        // POST: StudentAss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,DeptId")] StdDeptAss stdDeptAss)
        {
            if (id != stdDeptAss.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdDeptAss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdDeptAssExists(stdDeptAss.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeptId"] = new SelectList(_context.Dept, "Id", "Id", stdDeptAss.DeptId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", stdDeptAss.StudentId);
            return View(stdDeptAss);
        }

        // GET: StudentAss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdDeptAss = await _context.StdDeptAss
                .Include(s => s.Dept)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdDeptAss == null)
            {
                return NotFound();
            }

            return View(stdDeptAss);
        }

        // POST: StudentAss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdDeptAss = await _context.StdDeptAss.FindAsync(id);
            if (stdDeptAss != null)
            {
                _context.StdDeptAss.Remove(stdDeptAss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StdDeptAssExists(int id)
        {
            return _context.StdDeptAss.Any(e => e.Id == id);
        }
    }
}
