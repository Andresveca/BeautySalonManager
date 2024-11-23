using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Pages.Clientes
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
		public Cliente Cliente { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}

			var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

			if (cliente == null)
			{
				return NotFound();
			}
			else
			{
				Cliente = cliente;
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}

			var cliente = await _context.Clientes.FindAsync(id);

			if (cliente != null)
			{
				Cliente = cliente;
				_context.Clientes.Remove(Cliente);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}

}
