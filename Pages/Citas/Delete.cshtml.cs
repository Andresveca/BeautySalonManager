using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeautySalon.Pages.Citas
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly SalonContext _context;

        public DeleteModel(SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FindAsync(id);

            if (cita != null)
            {
                Cita = cita;
                _context.Citas.Remove(Cita);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}