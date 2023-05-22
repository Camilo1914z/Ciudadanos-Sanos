using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace Ciudadanos_Sanos.Pages.Patientes
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly CentrosaludContext _context;
		public IndexModel(CentrosaludContext context)
		{
			_context = context;
		}
		public IList<Patiente> Patientes { get; set; } = default!;
		public async Task OnGetAsync()
		{
			if (_context.Patientes != null)
			{

				Patientes = await _context.Patientes.ToListAsync();
			}
		}
	}
}
