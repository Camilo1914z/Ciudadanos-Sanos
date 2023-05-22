using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly CentrosaludContext _context;
        public DeleteModel(CentrosaludContext context)
        {
            _context = context;

        }

        [BindProperty]

        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Doctors == null)
            {

                return NotFound();
            }
            var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();

            }
            else
            {
                Doctor = doctor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
			if (id == null || _context.Doctors == null)
			{
				return NotFound();
			}
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null) {
                Doctor = doctor;
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");

		}
    }
}
