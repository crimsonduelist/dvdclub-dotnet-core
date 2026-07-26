using DvdClub.Domain.Entities;
using DvdClub.Web.Areas.Register.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Register {
    [Area("Register")]
    [Route("Register/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class RegisterController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult Index() {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RegisterViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            if (model.Password != model.ConfirmPassword) {
                model.ErrorMessage = "Passwords do not match.";
                return View(model);
            }

            var user = new ApplicationUser {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) {
                await _userManager.AddToRoleAsync(user, "Employee");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            foreach (var error in result.Errors) {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            model.ErrorMessage = "Registration failed. Please check the errors below.";
            return View(model);
        }
    }
}
