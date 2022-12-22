using Microsoft.AspNetCore.Mvc;

namespace WebOdevDeneme.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
