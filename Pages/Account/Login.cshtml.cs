using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ciudadanos_Sanos.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly CentrosaludContext _context;
        [BindProperty]
        public User User { get; set; }

        public LoginModel(CentrosaludContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var registro = await _context.Registers.FirstOrDefaultAsync(r => r.Email == User.Email && r.Password == User.Password);

            if (registro != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,registro.Email),
                new Claim(ClaimTypes.Email, registro.Email),
            };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return Page();
        }
    }
}
