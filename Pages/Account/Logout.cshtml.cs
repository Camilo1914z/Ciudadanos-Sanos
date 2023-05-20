using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciudadanos_Sanos.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnPostAsyn() {
            await HttpContext.SignOutAsync("MyCookieAuth");
                return RedirectToPage("/Index");
        
        }
    }
}
