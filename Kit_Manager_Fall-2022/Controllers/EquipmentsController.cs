using System;
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
    public class EquipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index(string SearchText = "")
        {
            //var applicationDbContext = _context.Equipment.Include(e => e.Student);
            //return View(await applicationDbContext.ToListAsync());

            List<Equipment> equipments;

            if (SearchText != "" && SearchText != null)
            {
                equipments = _context.Equipment
                    .Where(p => p.ItemName.Contains(SearchText))
                    .ToList();
            }
            else
                equipments = _context.Equipment.ToList();
            return View(equipments);

        }

        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Equipment.Include(e => e.Student);
        //    return View(await applicationDbContext.ToListAsync());
        //}

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            ViewBag.InstructorName = new List<string>() {"Rich Bright", "David Pence","Semi Necibi"};
            ViewBag.ItemType = new List<string>() { "Network Kit", "Backpack Kit", "Raspberry Pi Kit", "BuilderBox", "Single Item" };

            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemType,ItemName,ItemCost,KitId,StatusCode,StudentId,LastEdit,InstructorName,Course,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", equipment.StudentId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", equipment.StudentId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemType,ItemName,ItemCost,KitId,StatusCode,StudentId,LastEdit,InstructorName,Course,Active")] Equipment equipment)
        {
            if (id != equipment.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.ItemId))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", equipment.StudentId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipment.FindAsync(id);
            _context.Equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipment.Any(e => e.ItemId == id);
        }

        public async Task<IActionResult> AddItem([Bind("ItemId,ItemType,ItemName,ItemCost,KitId,StatusCode,StudentId,LastEdit,InstructorName,Course,Active")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", equipment.StudentId);
            return View(equipment);
        }
    }
}
