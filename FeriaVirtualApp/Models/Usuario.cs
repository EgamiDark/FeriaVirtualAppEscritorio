﻿namespace FeriaVirtualApp.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public bool Actividad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public int IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
