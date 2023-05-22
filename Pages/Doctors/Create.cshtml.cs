using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ciudadanos_Sanos.Pages.Doctors
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

        public Doctor Doctor { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Doctors == null || Doctor == null)
            {

                return Page();
            }
            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
