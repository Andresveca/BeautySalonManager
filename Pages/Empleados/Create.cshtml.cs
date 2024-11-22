using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeautySalon.Data;
using BeautySalon.Models;

namespace BeautySalon.Pages.Empleados
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
        public Empleado empleado { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Empleados == null || empleado == null)
            {
                return Page();
            }

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
