using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeautySalon.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre {  get; set; } 
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string? HorarioLaboral { get; set; }

        public ICollection<Cita> Citas { get; set; } // Propiedad de navegacion


    }
}
