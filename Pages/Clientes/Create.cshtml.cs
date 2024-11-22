using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautySalon.Pages.Clientes
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
		public Cliente Cliente { get; set; } = default!; 

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
			{
				//return Page(); 
			}

			_context.Clientes.Add(Cliente); // Cambiado a Clientes
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}

}
