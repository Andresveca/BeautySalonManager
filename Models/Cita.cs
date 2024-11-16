namespace BeautySalon.Models
{
    public class Cita
    {
        public int Id { get; set; } // Llave primaria
        public int IdServicio { get; set; } //llave foranea
        public int IdCliente { get; set; } //llave foranea
        public int IdEmpleado { get; set; } //llave foranea
        public string FechaHora { get; set; }
        public string Estado { get; set; }

        public Servicio Servicios { get; set; } // Propiedad de navegacion
        public Cliente Clientes { get; set; } // Propiedad de navegacion
        public Empleado Empleados { get; set; } // Propiedad de navegacion
    }
}
