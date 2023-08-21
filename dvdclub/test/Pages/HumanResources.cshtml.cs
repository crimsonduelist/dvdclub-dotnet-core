using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace test.Pages
{
    [Authorize("MustBelongToHRDep")]
    public class HumanResourcesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
