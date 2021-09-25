using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using FeriaVirtualApp.Core;
using FeriaVirtualApp.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FeriaVirtualApp.ViewModels
{
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Usuario> Usuarios { get; set; }

        public ObservableCollection<Rol> Roles { get; set; }

        private Usuario _usuario;
        public Usuario Usuario
        {
            get => _usuario;
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
            get => _rol;
            set
            {
                _rol = value;
                OnPropertyChanged(nameof(Rol));
            }
        }

        #region Inicio atributos de la Clase Usuario, para ser modificados o agregados
        private int _idUsuario;
        public int IdUsuario
        {
            get => _idUsuario;
            set
            {
                _idUsuario = value;
                OnPropertyChanged(nameof(IdUsuario));
            }
        }

        private string _rut;
        public string Rut
        {
            get => _rut;
            set
            {
                _rut = value;
                OnPropertyChanged(nameof(Rut));
            }
        }

        private string _nombre;
        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private string _apellidos;
        public string Apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged(nameof(Apellidos));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _contrasenia;
        public string Contrasenia
        {
            get => _contrasenia;
            set
            {
                _contrasenia = value;
                OnPropertyChanged(nameof(Contrasenia));
            }
        }

        private bool _actividad;
        public bool Actividad
        {
            get => _actividad;
            set
            {
                _actividad = value;
                OnPropertyChanged(nameof(Actividad));
            }
        }

        private string _direccion;
        public string Direccion
        {
            get => _direccion;
            set
            {
                _direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        private string _telefono;
        public string Telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }

        private int _idRol;
        public int IdRol
        {
            get => _idRol;
            set
            {
                _idRol = value;
                OnPropertyChanged(nameof(IdRol));
            }
        }

        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool OpenView { get; set; }

        private ICommand _guardarUsuario;
        public ICommand GuardarUsuario => _guardarUsuario ??= new CommandHandler(async () =>
                    await GuAcUsuario(), true);

        public UsuariosViewModel()
        {
            Usuario = new();
            OpenView = false;
        }

        public UsuariosViewModel(Usuario upUsuario)
        {
            Rol = new();

            try
            {
                IdUsuario = upUsuario.IdUsuario;
                Rut = upUsuario.Rut;
                Nombre = upUsuario.Nombre;
                Apellidos = upUsuario.Apellidos;
                Email = upUsuario.Email;
                Contrasenia = upUsuario.Contrasenia;
                Actividad = upUsuario.Actividad;
                Direccion = upUsuario.Direccion;
                Telefono = upUsuario.Telefono;
                IdRol = upUsuario.IdRol - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Metodo para guardar y actualizar usuario
        // Gu => Guardar
        // Ac => Actualizar
        public async Task GuAcUsuario()
        {
            HttpClient client = new();
            StringContent data;

            Usuario usuario = new();

            if (IdUsuario > 0)
            {
                usuario.IdUsuario = IdUsuario;
            }

            usuario.Rut = Rut;
            usuario.Nombre = Nombre;
            usuario.Apellidos = Apellidos;
            usuario.Email = Email;
            usuario.Contrasenia = Contrasenia;
            usuario.Actividad = Actividad;
            usuario.Direccion = Direccion;
            usuario.Telefono = Telefono;
            usuario.IdRol = Rol.IdRol;

            try
            {
                if (usuario != null)
                {
                    if (usuario.IdUsuario > 0)
                    {
                        string json = JsonConvert.SerializeObject(usuario);
                        data = new(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client
                            .PostAsync("http://localhost:5000/api/auth/modificar", data);
                        HttpStatusCode codeStatus = response.StatusCode;
                    }
                    else
                    {
                        string json = JsonConvert.SerializeObject(usuario);
                        data = new(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client
                            .PostAsync("http://localhost:5000/api/auth/registro", data);
                        HttpStatusCode codeStatus = response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        // Obtiene todos los usuarios del sistema
        public async Task<ObservableCollection<Usuario>> ObtenerUsuariosAsync()
        {
            ObservableCollection<Usuario> usuariosFromApi = new();
            string url = "http://localhost:5000/api/auth/usuarios";
            bool actividad;

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
                    // Convierte la actividad de string a booleano
                    actividad = rows[i][6].ToString() == "1";

                    Usuario usuario = new()
                    {
                        IdUsuario = int.Parse(rows[i][0].ToString()),
                        Rut = rows[i][1].ToString(),
                        Nombre = rows[i][2].ToString(),
                        Apellidos = rows[i][3].ToString(),
                        Email = rows[i][4].ToString(),
                        Contrasenia = rows[i][5].ToString(),
                        Actividad = actividad,
                        Direccion = rows[i][7].ToString(),
                        Telefono = rows[i][8].ToString(),
                        IdRol = int.Parse(rows[i][9].ToString()),
                    };

                    usuariosFromApi.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return usuariosFromApi;
        }

        // Obtiene todos los roles del sistema
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
    }
}