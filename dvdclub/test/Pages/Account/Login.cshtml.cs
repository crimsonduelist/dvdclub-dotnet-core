using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace test.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet()//this is on httpget
        {
            this.Credential = new Credential { UserName = "admin" };
        }
        public async Task<IActionResult> OnPostAsync()//this is on httppost
        {
            if( !ModelState.IsValid ) {
                return Page();
            }

            //verify credentials
            if (Credential.UserName == "admin" && Credential.Password == "pass" ) {
                //reate the security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@smthing.com"),
                    new Claim("Department", "HR"), //Claim type, Claim Value
                    //new Claim("Admin", "true") //Claim type, Claim Value here doesnt matter
                    new Claim("EmploymentDate", "2021-05-01")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");//2nd param is auth type
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);//we need to add the cookie service FLOW IS: Authentication -> IAuthenticationService -> i.e. Cookie,Token
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }

    public class Credential {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
