using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Citas
{
    public class CreateModel : PageModel
    {
        private readonly SalonContext _context;

        public CreateModel(SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cita cita { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Citas == null || cita == null)
            {
                return Page();
            }

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}