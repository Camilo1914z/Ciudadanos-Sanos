using Ciudadanos_Sanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ciudadanos_Sanos.Models;

namespace Ciudadanos_Sanos.Pages.Patientes
{
    public class EditModel : PageModel
    {
        private readonly CentrosaludContext _context;

		public EditModel(CentrosaludContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Patiente Patiente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{

			if (id == null || _context.Patientes==null)
			{
				return NotFound();
			}

			var patiente =await _context.Patientes.FirstOrDefaultAsync(m=> m.Id == id);

			if (patiente == null)
			{
				return NotFound();
			}
			Patiente = patiente;
			return Page();
		}


		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}
			_context.Attach(Patiente).State = EntityState.Modified;

			try
			{

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException){
				if (!PatienteExists(Patiente.Id))
				{
					return NotFound();
				}
				else {
					throw;
				}
			
			}
			return RedirectToPage("./Index");

		}

		private bool PatienteExists(int id)
		{

			return (_context.Patientes?.Any(a => a.Id == id)).GetValueOrDefault();
		}
	}
	}
