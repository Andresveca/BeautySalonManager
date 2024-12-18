﻿using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeautySalon.Models
{
    public class Cliente
    {
      public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
		public string? Telefono { get; set; }
        public string Email { get; set; }
        public string? HistorialServicios { get; set; }

        public ICollection<Cita> Citas { get; set; } // navegacion

    }
}
