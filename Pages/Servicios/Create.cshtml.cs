using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeautySalon.Pages.Servicios
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
		public Servicio Servicio { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Servicios == null || Servicio == null)
			{
				return Page();
			}

			_context.Servicios.Add(Servicio);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}

}
