using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtualApp.Models
{
    public class VentaLocal
    {
        public int idVentaLocal { get; set; }
        public string nombreProducto { get; set; }
        public string solicitante { get; set; }
        public int kgUnidad { get; set; }
        public int cantidad { get; set; }
        public string direccion { get; set; }
    }
}
