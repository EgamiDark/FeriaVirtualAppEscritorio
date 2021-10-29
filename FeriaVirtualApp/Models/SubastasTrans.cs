using System;

namespace FeriaVirtualApp.Models
{
    public class SubastasTrans
    {
        public int IdSubastaTrans { get; set; }
        public DateTime FechaSubasta { get; set; }
        public DateTime Fechatermino { get; set; }

        public int IdPedido { get; set; }
        public int IdVentaLocal { get; set; }
        public int IdTipoRefrig { get; set; }
        public int IdTipoTrans { get; set; }
        public int IdEstSubasta { get; set; }
    }
}
