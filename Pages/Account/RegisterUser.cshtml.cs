using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciudadanos_Sanos.Pages.Account
{
    public class RegisterUserModel : PageModel
    {
        private readonly CentrosaludContext _context;

        public RegisterUserModel(CentrosaludContext context)
        {

            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public Register Register { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Registers == null || Register == null)
            {

                return Page();
            }
            _context.Registers.Add(Register);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Account/Login");

        }
    }
}
