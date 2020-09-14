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
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //Add a private field to hold our user manager
        private readonly UserManager<ApplicationUser> _userManager;

        //Inject the userManager into our controller

        public InstructorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Get the currently logged in user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Instructors
        public async Task<IActionResult> Index()
        {
            // Get the current user
            ApplicationUser loggedInUser = await GetCurrentUserAsync();
            var Instructor = await _context.Instructor.Include(i => i.Cohort).Where(instructor => instructor.UserId == loggedInUser.Id).ToListAsync();
            
            return View(Instructor);
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //TODO:: GET STUDENT NAMES TO DISPLAY IN DETAILS VIEW
            var instructor = await _context.Instructor
                .Include(i => i.Cohort)
                .Include(m => m.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            //create an instance of your viewModel to view a list of cohorts with the instructors
            InstructorCohortViewModel ViewModel = new InstructorCohortViewModel();
            //Then use the view model rather than view data for more flexibility
            ViewModel.cohorts = _context.Cohort.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }
            ).ToList();

            return View(ViewModel);
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,SlackHandle,Specialty,CohortId")] Instructor instructor)
        {
            InstructorCohortViewModel ViewModel = new InstructorCohortViewModel();
            if (ModelState.IsValid)
            {
                // get the current user 
                var user = await GetCurrentUserAsync();
                instructor.UserId = user.Id;
                _context.Add(instructor);
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

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            InstructorCohortViewModel ViewModel = new InstructorCohortViewModel();
            if (id == null)
            {
                return NotFound();
            }

            ViewModel.instructor = await _context.Instructor.FindAsync(id);
            if (ViewModel.instructor == null)
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

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,SlackHandle,Specialty,CohortId")] Instructor instructor)
        {
            InstructorCohortViewModel ViewModel = new InstructorCohortViewModel();
            if (id != instructor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.Id))
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

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructor
                .Include(i => i.Cohort)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructor.FindAsync(id);
            _context.Instructor.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructor.Any(e => e.Id == id);
        }
    }
}
