using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test.Pages
{
    [Authorize("AdminOnly")]
    public class AdminOnly : PageModel
    {
        public void OnGet()
        {
        }
    }
}
