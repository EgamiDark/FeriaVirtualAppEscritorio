using System;

namespace FeriaVirtualApp.Models
{
    public class Contrato
    {
        public int IdContrado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaTermino { get; set; }
        public byte[] PDFContrato { get; set; }

        public int IdUsuario { get; set; }
    }
}
