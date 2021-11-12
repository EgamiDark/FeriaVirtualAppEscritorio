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

        public ObservableCollection<Usuario> usuarios { get; set; }

        public ObservableCollection<Rol> roles { get; set; }

        private Usuario _usuario;
        public Usuario usuario
        {
            get => _usuario;
            set
            {
                if (_usuario != null)
                {
                    _usuario = value;
                    OnPropertyChanged(nameof(usuario));
                }
            }
        }

        private Rol _rol;
        public Rol rol
        {
            get => _rol;
            set
            {
                _rol = value;
                OnPropertyChanged(nameof(rol));
            }
        }

        #region Inicio atributos de la Clase Usuario, para ser modificados o agregados
        private int _idUsuario;
        public int idUsuario
        {
            get => _idUsuario;
            set
            {
                _idUsuario = value;
                OnPropertyChanged(nameof(idUsuario));
            }
        }

        private string _rut;
        public string rut
        {
            get => _rut;
            set
            {
                _rut = value;
                OnPropertyChanged(nameof(rut));
            }
        }

        private string _nombre;
        public string nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(nombre));
            }
        }

        private string _apellidos;
        public string apellidos
        {
            get => _apellidos;
            set
            {
                _apellidos = value;
                OnPropertyChanged(nameof(apellidos));
            }
        }

        private string _email;
        public string email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(email));
            }
        }

        private string _contrasenia;
        public string contrasenia
        {
            get => _contrasenia;
            set
            {
                _contrasenia = value;
                OnPropertyChanged(nameof(contrasenia));
            }
        }

        private bool _actividad;
        public bool actividad
        {
            get => _actividad;
            set
            {
                _actividad = value;
                OnPropertyChanged(nameof(actividad));
            }
        }

        private string _direccion;
        public string direccion
        {
            get => _direccion;
            set
            {
                _direccion = value;
                OnPropertyChanged(nameof(direccion));
            }
        }

        private string _telefono;
        public string telefono
        {
            get => _telefono;
            set
            {
                _telefono = value;
                OnPropertyChanged(nameof(telefono));
            }
        }

        private int _idRol;
        public int idRol
        {
            get => _idRol;
            set
            {
                _idRol = value;
                OnPropertyChanged(nameof(idRol));
            }
        }

        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand _guardarUsuario;
        public ICommand GuardarUsuario => _guardarUsuario ??= new CommandHandler(async () =>
                    await GuAcUsuario(), true);

        public UsuariosViewModel()
        {
            usuario = new();
        }

        public UsuariosViewModel(Usuario upUsuario)
        {
            Rol rol = new();

            try
            {
                idUsuario = upUsuario.idUsuario;
                rut = upUsuario.rut;
                nombre = upUsuario.nombre;
                apellidos = upUsuario.apellidos;
                email = upUsuario.email;
                contrasenia = upUsuario.contrasenia;
                actividad = upUsuario.actividad;
                direccion = upUsuario.direccion;
                telefono = upUsuario.telefono;
                idRol = upUsuario.idRol - 1;
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
            StringContent data;
            Usuario usuario = new();
            HttpClient client = new();

            try
            {
                if (idUsuario > 0)
                {
                    usuario.idUsuario = idUsuario;
                }

                usuario.rut = rut;
                usuario.nombre = nombre;
                usuario.apellidos = apellidos;
                usuario.email = email;
                usuario.contrasenia = contrasenia;
                usuario.actividad = actividad;
                usuario.direccion = direccion;
                usuario.telefono = telefono;
                usuario.idRol = rol.idRol;

                if (usuario != null)
                {
                    if (usuario.idUsuario > 0)
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
                        idUsuario = int.Parse(rows[i][0].ToString()),
                        rut = rows[i][1].ToString(),
                        nombre = rows[i][2].ToString(),
                        apellidos = rows[i][3].ToString(),
                        email = rows[i][4].ToString(),
                        contrasenia = rows[i][5].ToString(),
                        actividad = actividad,
                        direccion = rows[i][7].ToString(),
                        telefono = rows[i][8].ToString(),
                        idRol = int.Parse(rows[i][9].ToString()),
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
                        idRol = int.Parse(rows[i][0].ToString()),
                        descripcion = rows[i][1].ToString()
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