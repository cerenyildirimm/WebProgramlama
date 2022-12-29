using Microsoft.AspNetCore.Mvc;
using WebOdevDeneme.Data;
using WebOdevDeneme.Models;

namespace WebOdevDeneme.Controllers
{
    public class UserController : Controller
    {
        readonly ShoppingContext _context;

        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Signup(User u)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(u);
                return View(u);
            }
            return View();
        }
    }
}
