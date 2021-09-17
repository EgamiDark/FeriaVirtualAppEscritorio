using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using FeriaVirtualApp.Core;
using FeriaVirtualApp.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace FeriaVirtualApp.ViewModels
{
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Usuario> _usuarios;
        public ObservableCollection<Usuario> Usuarios
        {
            get { return _usuarios; }
            set { _usuarios = value; }
        }

        private ObservableCollection<Rol> _roles;
        public ObservableCollection<Rol> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        private Usuario _usuario;
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != null)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(Usuario));
                }
            }
        }

        private Rol _rol;
        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        

        public bool OpenView { get; set; }

        private ICommand _guardarUsuario;
        public ICommand GuardarUsuario => _guardarUsuario ??= new CommandHandler(async () =>
                    await GuAcUsuario(), true);

        public UsuariosViewModel()
        {
            Usuario = new();
            _usuarios = new ObservableCollection<Usuario>
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
        public async Task<ObservableCollection<Rol>> ObtenerRolesAsync()
        {
            ObservableCollection<Rol> rolesFromApi = new();
            string url = "http://localhost:5000/api/auth/rol";

            try
            {
                HttpClient client = new();
                HttpResponseMessage res = await client.GetAsync(url);
                HttpContent content = res.Content;
                string data = await content.ReadAsStringAsync();
                JObject dataObj = JObject.Parse(data);

                JToken rows = dataObj["rows"];
                int length = rows.Count<object>();

                for (int i = 0; i < length; i++)
                {
                    Rol rol = new()
                    {
                        IdRol = int.Parse(rows[i][0].ToString()),
                        Descripcion = rows[i][1].ToString()
                    };

                    rolesFromApi.Add(rol);
                }
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
        private async Task GuAcUsuario()
        {
            HttpClient client = new();
            StringContent data;

            try
            {
                if (Usuario != null)
                {
                    string json = JsonConvert.SerializeObject(_usuario);
                    data = new(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/api/auth/registro", data);
                    HttpStatusCode codeStatus = response.StatusCode;
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