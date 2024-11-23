using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Citas
{
    public class DeleteModel : PageModel
    {
        private readonly SalonContext _context;

        public DeleteModel(SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita cita { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);

            if (cita != null)
            {
                cita = cita;
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}