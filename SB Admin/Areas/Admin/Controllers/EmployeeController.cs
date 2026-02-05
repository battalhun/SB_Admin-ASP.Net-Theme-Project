using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SB_Admin.Models; 
using System.Linq;

namespace SB_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }
    }
}
