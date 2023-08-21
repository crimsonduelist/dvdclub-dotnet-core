using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test.Pages.Account {
    public class LogoutModel : PageModel {
        public async Task<IActionResult> OnPostAsync() {
            HttpContext.SignOutAsync("MyCookie");
            return RedirectToPage("Index");
        }
    }
}
