using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Citas
{
    public class EditModel : PageModel
    {
        private readonly SalonContext _context;

        public EditModel(SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita cita { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Citas == null)
            {
                return NotFound();
            }

            var cita = await _context.Citas.FirstOrDefaultAsync(m => m.Id == id);
            if (cita == null)
            {
                return NotFound();
            }
            cita = cita;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(cita.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CitaExists(int id)
        {
            return (_context.Citas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}