using System;

namespace FeriaVirtualApp.Models
{
    public class SubastasTrans
    {
        public int idSubastaTrans { get; set; }
        public string fechaSubasta { get; set; }
        public string fechaTermino { get; set; }
        public int idPedido { get; set; }
        public int idVentaLocal { get; set; }
        public int idTipoRefrig { get; set; }
        public int idTipoTrans { get; set; }
        public int idTipoVenta { get; set; }
        public string tipoVenta { get; set; }
        public string estadoSubasta { get; set; }

    }
}
