using BeautySalon.Data;
using BeautySalon.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeautySalon.Pages.InicioSesion
{
    public class LoginModel : PageModel
    {
        private readonly SalonContext _context;

        public LoginModel(SalonContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuarios { get; set; } = default!;

        [BindProperty]
        public Usuario Usuario { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Valida En BD
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == Usuario.Email && m.Password == Usuario.Password);

            if (usuario != null)
            {
                // Crear los Claims 
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Email,usuario.Password)
        };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");  // Manda al Home
            }

            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos.");
            return Page();
        }
    }
}
