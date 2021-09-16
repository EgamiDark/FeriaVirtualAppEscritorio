using System;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

using FeriaVirtualApp.Models;
using Newtonsoft.Json;
using FeriaVirtualApp.Core;
using System.Net.Http.Headers;

namespace FeriaVirtualApp.ViewModels
{
    public class UsuariosViewModel
    {
        
        public List<Usuario> Usuarios { get; set; }
        public Usuario Usuario { get; set; }
        public bool OpenView { get; set; }

        private ICommand _guardarUsuario;
        public ICommand GuardarUsuario => _guardarUsuario ??= new CommandHandler(async () =>
                    await GuAcUsuario(Usuario), true);

        public UsuariosViewModel()
        {
            Usuario = null;
            Usuarios = new List<Usuario>
            {
                new Usuario{ IdUsuario = 1, Nombre = "Nicolas", Apellidos = "Cortes Azua", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 2, Nombre = "Matias", Apellidos = "San Martin", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 3, Nombre = "Felipe", Apellidos = "Azua", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 4, Nombre = "Frank", Apellidos = "Aravena", Direccion = "bbbbbbbbbbbbb"},
                new Usuario{ IdUsuario = 5, Nombre = "Jose", Apellidos = "Mansilla", Direccion = "ccccccccccccc"},
                new Usuario{ IdUsuario = 6, Nombre = "Belgica", Apellidos = "Campos", Direccion = "ddddddddddddd"},
                new Usuario{ IdUsuario = 7, Nombre = "Mario", Apellidos = "Diaz", Direccion = "eeeeeeeeeee"},
                new Usuario{ IdUsuario = 8, Nombre = "Juanito", Apellidos = "Perez", Direccion = "fffffffffff"},
                new Usuario{ IdUsuario = 9, Nombre = "Gustavo", Apellidos = "Caceres", Direccion = "Av. Siempre viva"},
                new Usuario{ IdUsuario = 10, Nombre = "Manuel", Apellidos = "Muñoz", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 11, Nombre = "Mickel", Apellidos = "Gutierrez", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 12, Nombre = "Gisela", Apellidos = "Soto", Direccion = "AAaaaa"},
            };

            OpenView = false;
        }

        public UsuariosViewModel(Usuario upUsuario)
        {
            Usuario = upUsuario;
        }

        // Metodo para guardar y actualizar usuario
        // Gu => Guardar
        // Ac => Actualizar
        public static async Task<List<Rol>> ObtenerRoles()
        {
            HttpClient client = new();
            List<Rol> rolesFromApi = new();

            try
            {
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("http://10.0.2.2:5000/api/auth/rol");
                WebResponse myResponse = myReq.GetResponse();
                HttpResponseMessage response = await client.GetAsync("http://10.0.2.2:5000/api/auth/rol");
                HttpContent content = response.Content;
                string data = await content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return rolesFromApi;
        }

        // Metodo para guardar y actualizar usuario
        // Gu => Guardar
        // Ac => Actualizar
        public static async Task GuAcUsuario(Usuario usuario)
        {
            List<Rol> roles = new(await ObtenerRoles());
            HttpClient client = new();
            StringContent data;
            HttpResponseMessage response = new();
            HttpStatusCode codeStatus = new();
            string json = "";

            try
            {
                if (usuario != null)
                {
                    json = JsonConvert.SerializeObject(usuario);
                    data = new(json, Encoding.UTF8, "application/json");
                    response = await client.PostAsync("http://localhost:5000/api/auth/registro", data);
                    codeStatus = response.StatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }
    }
}