namespace BeautySalon.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string CantidadDisponible { get; set; }
        public int CostoUnitario { get; set; }
        public string? Proveedor { get; set; }
    }
}
