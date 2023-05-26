using Ciudadanos_Sanos.Data;
using Ciudadanos_Sanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Ciudadanos_Sanos.Pages.AgendacionCitas
{
    public class IndexModel : PageModel
    {
        private readonly CentrosaludContext _context;

        public IndexModel(CentrosaludContext context)
        {
            _context = context;
        }

        public List<AgendacionCita> AgendacionCitas { get; set; }

        public IActionResult OnGet()
        {
            AgendacionCitas = _context.AgendacionCitas
                .Include(a => a.Doctor)
                .Include(a => a.Patiente)
                .ToList();

            return Page();
        }
    }
}
