using Microsoft.AspNetCore.Mvc;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserViewModel model)
        {
            // TODO: Add the creation of the user
        }
    }
}
