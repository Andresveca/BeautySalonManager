using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeautySalon.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Precio { get; set; }
        public string? DuracionEstimada { get; set; }
        public ICollection<Cita> Citas { get; set; } // Propiedad de navegacion

    }

}

    