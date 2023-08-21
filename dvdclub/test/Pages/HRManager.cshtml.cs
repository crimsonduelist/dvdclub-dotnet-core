using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test.Pages
{
    [Authorize("HRManager")]
    public class HRManager : PageModel
    {
        public void OnGet()
        {
        }
    }
}
