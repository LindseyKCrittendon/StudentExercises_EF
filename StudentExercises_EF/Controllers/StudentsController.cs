using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentExercises_EF.Data;
using StudentExercises_EF.Models;
using StudentExercises_EF.Models.ViewModels;

namespace StudentExercises_EF.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        // Add private field to hold the user manager
        private readonly UserManager<ApplicationUser> _userManager;

        //Inject the user manager into the controller

        public StudentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Get the currently logged in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Students
        public async Task<IActionResult> Index()
        {
            // Get the current user
            ApplicationUser loggedInUser = await GetCurrentUserAsync();
            return View(await _context.Student.Include(i => i.Cohort).Where(student => student.UserId == loggedInUser.Id).ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Cohort)
                .Include(i => i.AssignedExercises)
                .ThenInclude(e => e.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            //create an instance of your viewModel to view a list of cohorts with the instructors
            StudentCohortViewModel ViewModel = new StudentCohortViewModel();
            //Then use the view model rather than view data for more flexibility
            ViewModel.cohorts = _context.Cohort.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }
            ).ToList();

            return View(ViewModel);
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,SlackHandle,CohortId")] Student student)
        {
            StudentCohortViewModel ViewModel = new StudentCohortViewModel();
            if (ModelState.IsValid)
            {
                //get the current user
                var user = await GetCurrentUserAsync();
                student.UserId = user.Id;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewModel.cohorts = _context.Cohort.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }
         ).ToList();

            return View(ViewModel);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            StudentCohortViewModel ViewModel = new StudentCohortViewModel();
            if (id == null)
            {
                return NotFound();
            }

            ViewModel.student = await _context.Student.FindAsync(id);
            if (ViewModel.student == null)
            {
                return NotFound();
            }
            ViewModel.cohorts = _context.Cohort.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }
            ).ToList();

            return View(ViewModel);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,SlackHandle,CohortId")] Student student)
        {
            StudentCohortViewModel ViewModel = new StudentCohortViewModel();
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();
                    student.UserId = user.Id;
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewModel.cohorts = _context.Cohort.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }
                 ).ToList();

            return View(ViewModel);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Cohort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            var user = await GetCurrentUserAsync();
            student.UserId = user.Id;
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
