using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Patientes
{
    public class DeleteModel : PageModel
    {
        private readonly CentrosaludContext _context;
        public DeleteModel(CentrosaludContext context)
        {
            _context = context;

        }

        [BindProperty]

        public Patiente Patiente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patientes == null)
            {

                return NotFound();
            }
            var patiente = await _context.Patientes.FirstOrDefaultAsync(m => m.Id == id);
            if (patiente == null)
            {
                return NotFound();

            }
            else
            {
                Patiente = patiente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
			if (id == null || _context.Patientes == null)
			{
				return NotFound();
			}
            var patiente = await _context.Patientes.FindAsync(id);
            if (patiente != null) {
                Patiente = patiente;
                _context.Patientes.Remove(Patiente);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

		}
    }
}
