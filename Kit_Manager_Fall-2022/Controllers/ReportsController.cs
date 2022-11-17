using System.Linq;
using Kit_Manager_Fall_2022.Data;
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

        public IActionResult Checked_In()
        {
            // Fetch data

            var checked_in = from e in _context.Equipment where e.StatusCode == 1 select e;

            return View(checked_in);
        }
    }
}
