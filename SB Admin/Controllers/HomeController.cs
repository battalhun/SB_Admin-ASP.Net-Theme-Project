
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SB_Admin.Models;

namespace SB_Admin.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {     
            return View();
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

        public IActionResult Login()
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
