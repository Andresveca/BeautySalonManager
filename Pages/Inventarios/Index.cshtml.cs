using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Inventarios
{
    public class IndexModel : PageModel
    {
        private readonly SalonContext _context;

        public IndexModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Inventario> Inventarios { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Inventarios != null)
            {
                Inventarios = await _context.Inventarios.ToListAsync();
            }
        }
    }
}