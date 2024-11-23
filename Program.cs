using BeautySalon.Data;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

			//Agregando el concepto SalonContext a la aplicacion
			builder.Services.AddDbContext<SalonContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("BeautySalonManagerDB"))
			);

			builder.Services.AddAuthentication().AddCookie("MyCookieAuto", options =>
			{
				options.Cookie.Name = "MyCookieAuto";
				options.LoginPath = "/InicioSesion/Login"; //Sino esta Autenticado, cargue la pagina Login
                options.AccessDeniedPath = "/InicioSesion/AccesoDenegado";
            });
            
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
