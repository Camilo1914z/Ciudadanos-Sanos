 using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Ciudadanos_Sanos.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {
        }

      

        public async Task<IActionResult> OnPostAsync() { 
        if(!ModelState.IsValid) return Page();
            if (User.Email == "consulta@gmail.com" && User.Password == "12345") {

                var claims = new List<Claim>
                 { 
                
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email,User.Email),
                
                };

                var identify =  new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal= new ClaimsPrincipal(identify);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);





                return RedirectToPage("/Index");

            }
            return Page();
        
        }
    }
}