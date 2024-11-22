using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly SalonContext _context;

        public IndexModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Empleado> empleado { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleados != null)
            {
                empleado = await _context.Empleados.ToListAsync();
            }
        }
    }
}