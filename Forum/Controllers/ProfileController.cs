using Microsoft.AspNetCore.Mvc;

namespace CrimerForum.Controllers
{
    public class ProfileController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        // GET
        public IActionResult Create()
        {
            return View();
        }
        // GET
        public IActionResult Detail()
        {
            return View();
        }
    }
}