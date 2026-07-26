using DvdClub.Domain.Entities;
using DvdClub.Web.Areas.Login.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Login {
    [Area("Login")]
    [Route("Login/[controller]/[action]")]
    public class LoginController : Controller {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager) {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index() {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded) {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            model.ErrorMessage = "Invalid username or password.";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
