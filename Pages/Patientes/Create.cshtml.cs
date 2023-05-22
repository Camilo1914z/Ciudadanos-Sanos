using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ciudadanos_Sanos.Pages.Patientes
{
    public class CreateModel : PageModel
    {
        private readonly CentrosaludContext _context;

        public CreateModel(CentrosaludContext context)
        {

            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]

        public Patiente Patiente { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Patientes == null || Patiente == null)
            {

                return Page();
            }
            _context.Patientes.Add(Patiente);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
