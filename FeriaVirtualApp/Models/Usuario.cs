namespace FeriaVirtualApp.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string rut { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string contrasenia { get; set; }
        public bool actividad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public int idRol { get; set; }
        public Rol rol { get; set; }
    }
}
