using System;

namespace FeriaVirtualApp.Models
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaTermino { get; set; }
        public int Cantidad { get; set; }
        public int KgUnidad { get; set; }
        public int PrecioMaximo { get; set; }

        public int IdEstPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
    }
}
