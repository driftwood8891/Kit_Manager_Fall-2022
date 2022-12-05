using System.Linq;
using Kit_Manager_Fall_2022.Data;
using Kit_Manager_Fall_2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kit_Manager_Fall_2022.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        // The assign items page pulls data from both the equipment and student tables
        public IActionResult AssignItems()
        {

            var tables = new SharedData()
            {
                studentdetails = _context.Student.ToList(),
                equipmentdetails = _context.Equipment.ToList()
            };

            return View(tables);
        }

        
        // Server code for the Reports page - They are simple queries
        public IActionResult Checked_In()
        {
            // Fetch data

            var checked_in = from e in _context.Equipment where e.StatusCode == 1 select e;

            return View(checked_in);
        }

        public IActionResult Checked_Out()
        {
	        // Fetch data

	        var checked_out = from e in _context.Equipment where e.StatusCode == 2 select e;

	        return View(checked_out);
        }

        public IActionResult Lost()
        {
	        // Fetch data

	        var lost = from e in _context.Equipment where e.StatusCode == 4 select e;

	        return View(lost);
        }

        public IActionResult Unknown()
        {
	        // Fetch data

	        var unknown = from e in _context.Equipment where e.StatusCode == 9 select e;

	        return View(unknown);
        }

        public IActionResult Dead()
        {
            // Fetch data

            var dead = from e in _context.Equipment where e.StatusCode == 3 select e;

            return View(dead);
        }

        public IActionResult In_Transit()
        {
            // Fetch data

            var transit = from e in _context.Equipment where e.StatusCode == 5 select e;

            return View(transit);
        }

        public IActionResult Needs_Repair()
        {
            // Fetch data

            var repair = from e in _context.Equipment where e.StatusCode == 6 select e;

            return View(repair);
        }

        public IActionResult Pending()
        {
            // Fetch data

            var pending = from e in _context.Equipment where e.StatusCode == 7 select e;

            return View(pending);
        }

        public IActionResult Ready()
        {
            // Fetch data

            var ready = from e in _context.Equipment where e.StatusCode == 8 select e;

            return View(ready);
        }

        public IActionResult Past_User()
        {
            // Fetch data

            return View();
        }

        public IActionResult By_User()
        {
            // Fetch data

            return View();
        }

        public IActionResult Location()
        {
            // Fetch data

            return View();
        }
    }
}
