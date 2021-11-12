using System;

namespace FeriaVirtualApp.Models
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public DateTime fechaTermino { get; set; }
        public int cantidad { get; set; }
        public int kgUnidad { get; set; }
        public int precioMaximo { get; set; }
                   
        public int idEstPedido { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
    }
}
