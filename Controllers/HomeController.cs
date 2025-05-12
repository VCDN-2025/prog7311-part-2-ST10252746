using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PROG7311_POE_PART_2.Controllers
{
    public class HomeController : Controller
    {
        // Public Welcome Page
        [AllowAnonymous]
        public IActionResult PublicWelcome()
        {
            return View();
        }

        // Authenticated Dashboard Landing Page
        [Authorize]
        public IActionResult Index()
        {
            return View();
        } 
    }
}