using DvdClub.Domain.Entities;
using DvdClub.Web.Areas.Members.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DvdClub.Web.Areas.Members {
    [Area("Members")]
    [Route("Members/[controller]/[action]")]
    [Authorize(Roles = "Admin")]
    public class MembersController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;

        public MembersController(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult Index() {
            var users = _userManager.Users.ToList();
            var model = new MembersIndexViewModel(users);
            return View(model);
        }
    }
}
