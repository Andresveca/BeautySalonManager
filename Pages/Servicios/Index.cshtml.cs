using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Pages.Servicios
{
    public class IndexModel : PageModel
    {
        private readonly SalonContext _context;

        public IndexModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Servicio> Servicios { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Servicios != null)

                Servicios = await _context.Servicios.ToListAsync();
        }

    }
}

