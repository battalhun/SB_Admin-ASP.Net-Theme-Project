using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SB_Admin.Models;
using System.Diagnostics;

namespace SB_Admin.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult layout_sidenav_light()
        {
            ViewData["SideNavClass"] = "sb-sidenav-light";
            return View("Index");
        }

        public IActionResult layout_static()
        {
            ViewData["SideNavClass"] = "sb-sidenav-dark";
            return View("Index");
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Password()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error401()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
