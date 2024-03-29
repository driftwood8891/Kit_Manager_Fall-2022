﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kit_Manager_Fall_2022.Data;
using Kit_Manager_Fall_2022.Models;

namespace Kit_Manager_Fall_2022.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string SearchText = "")
        {
            // This is code for the search bar of the Student's Index page
            List<Student> students;

            if (SearchText != "" && SearchText != null)
            {
                students = _context.Student
                    .Where(p => p.StudentId.Contains(SearchText)) // Here we search by student ID number
                    .ToList();
            }
            else 
                students = _context.Student.ToList();
            return View(students);

        }



        // DETAILS ACTION

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }



        // CREATE ACTION

        // GET: Students/Create
        public IActionResult Create()
        {
            // Creating list boxes for the Student Create page so we maintain data integrity  
	        ViewBag.Campus = new List<string>() { "Columbia", "Hannibal", "Kirksville","Mexico", "Moberly" };
			return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FName,LName,CollegeEmail,PersonalEmail,Phone,Address,Campus,Active,HasItem,LastEdit,EmergencyContact")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();

                //Create Alert
                TempData["success"] = "Student was created successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }



        // EDIT ACTION

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,FName,LName,CollegeEmail,PersonalEmail,Phone,Address,Campus,Active,HasItem,LastEdit,EmergencyContact")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //Create Alert
                TempData["success"] = "Student was updated successfully";

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }



        // DELETE ACTION

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            //Create Alert
            TempData["success"] = "Student was deleted successfully";

            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
