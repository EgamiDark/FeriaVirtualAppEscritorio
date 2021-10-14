namespace FeriaVirtualApp.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public bool IsActive { get; set; }
        public byte[] Imagen { get; set; }
    }
}
