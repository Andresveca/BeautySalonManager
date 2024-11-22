using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly SalonContext _context;

        public IndexModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Cliente> Clientes { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Clientes != null)

                Clientes  = await _context.Clientes.ToListAsync();
            }

        }
    }

