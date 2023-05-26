using Ciudadanos_Sanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly CentrosaludContext _context;

		public EditModel(CentrosaludContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Doctor Doctor { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{

			if (id == null || _context.Doctors==null)
			{
				return NotFound();
			}

			var doctor =await _context.Doctors.FirstOrDefaultAsync(m=> m.Id == id);

			if (doctor == null)
			{
				return NotFound();
			}
			Doctor = doctor;
			return Page();
		}


		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}
			_context.Attach(Doctor).State = EntityState.Modified;

			try
			{

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException){
				if (!DoctorExists(Doctor.Id))
				{
					return NotFound();
				}
				else {
					throw;
				}
			
			}
			return RedirectToPage("./Index");

		}

		private bool DoctorExists(int id)
		{

			return (_context.Doctors?.Any(a => a.Id == id)).GetValueOrDefault();
		}
	}
	}
