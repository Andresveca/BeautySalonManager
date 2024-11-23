using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Inventarios
{
    public class DeleteModel : PageModel
    {
        private readonly SalonContext _context;

        public DeleteModel(SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inventario Inventario { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _context.Inventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios.FindAsync(id);

            if (inventario != null)
            {
                Inventario = inventario;
                _context.Inventarios.Remove(Inventario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}