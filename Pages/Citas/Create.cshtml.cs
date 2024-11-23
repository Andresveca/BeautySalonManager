using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeautySalon.Pages.Citas
{
    [Authorize]
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
        public Cita Cita { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}