namespace FeriaVirtualApp.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public bool isActive { get; set; }
        public byte[] imagen { get; set; }
    }
}
