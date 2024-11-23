using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeautySalon.Pages.Inventarios
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
       
       public Inventario Inventario { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
           

            _context.Inventarios.Add(Inventario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}