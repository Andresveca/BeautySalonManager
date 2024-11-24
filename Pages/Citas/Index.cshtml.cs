
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeautySalon.Pages.Citas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SalonContext _context;

        public IndexModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Cita> Citas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Citas != null)
            {
                Citas = await _context.Citas.ToListAsync();
            }
        }
    }
}