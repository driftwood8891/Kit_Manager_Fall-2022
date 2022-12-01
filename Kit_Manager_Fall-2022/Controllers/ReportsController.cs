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
	}
}
