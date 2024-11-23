using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Models
{
    public class Usuario
    {
        public int Id { get; set; } //Llave Primaria
        public string Nombre { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public int Edad {  get; set; }
    }
}
