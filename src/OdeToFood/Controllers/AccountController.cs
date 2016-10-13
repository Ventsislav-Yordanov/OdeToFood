using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.ViewModels;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = new User() { UserName = model.Username };
                var createResult = await this.userManager.CreateAsync(user, model.Password);
                if (createResult.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, false);
                    return this.RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var loginResult = await this.signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe, false);
                if (loginResult.Succeeded)
                {
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return this.Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                }

            }

            ModelState.AddModelError(string.Empty, "Could not login");

            return this.View();
        }
    }
}
