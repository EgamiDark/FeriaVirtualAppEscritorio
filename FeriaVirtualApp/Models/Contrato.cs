using System;

namespace FeriaVirtualApp.Models
{
    public class Contrato
    {
        public int idContrato { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaTermino { get; set; }
        public int idUsuario { get; set; }
        public byte[] pdfContrato { get; set; }
    }
}
