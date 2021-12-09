using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using FeriaVirtualApp.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FeriaVirtualApp.ViewModels
{
    public class ContratoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Contrato> _contratos;
        public ObservableCollection<Contrato> contratos
        {
            get => _contratos;
            set
            {
                _contratos = value;
                OnPropertyChanged(nameof(contratos));
            }
        }

        public ObservableCollection<Usuario> usuarios { get; set; }

        private Usuario _usuario;
        public Usuario usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(usuario));
            }
        }

        private int _idContrato;
        public int idContrato
        {
            get => _idContrato;
            set
            {
                _idContrato = value;
                OnPropertyChanged(nameof(idContrato));
            }
        }

        private DateTime _fechaCreacion;
        public DateTime fechaCreacion
        {
            get => _fechaCreacion;
            set
            {
                _fechaCreacion = value;
                OnPropertyChanged(nameof(fechaCreacion));
            }
        }

        private DateTime _fechaTermino;
        public DateTime fechaTermino
        {
            get => _fechaTermino;
            set
            {
                _fechaTermino = value;
                OnPropertyChanged(nameof(fechaTermino));
            }
        }

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

        private byte[] _pdfContrato;
        public byte[] pdfContrato
        {
            get => _pdfContrato;
            set
            {
                _pdfContrato = value;
                OnPropertyChanged(nameof(pdfContrato));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ContratoViewModel()
        {
            SetContratos();
        }

        public async Task<ObservableCollection<Contrato>> ObtenerContratosAsync()
        {
            string url = "http://localhost:5000/api/contrato/obtener/todos";

            HttpClient client = new();
            ObservableCollection<Contrato> contratosFromApi = new();

            try
            {
                HttpResponseMessage res = await client.GetAsync(url);
                HttpContent content = res.Content;
                string data = await content.ReadAsStringAsync();
                JObject dataObj = JObject.Parse(data);

                JToken rows = dataObj["rows"];
                int length = rows.Count<object>();

                for (int i = 0; i < length; i++)
                {
                    byte[] pdf = Convert.FromBase64String(rows[i][4].ToString());

                    Contrato contrato = new()
                    {
                        idContrato = int.Parse(rows[i][0].ToString()),
                        fechaCreacion = rows[i][1].ToString(),
                        fechaTermino = rows[i][2].ToString(),
                        idUsuario = int.Parse(rows[i][3].ToString()),
                        pdfContrato = pdf
                    };

                    contratosFromApi.Add(contrato);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return contratosFromApi;
        }

        public async Task GuardarContrato()
        {
            StringContent data;
            Contrato contrato = new();
            HttpClient client = new();

            try
            {
                string fechaCreacionFormat = String.Format("{0:dd-MM-yyyy}", fechaCreacion);
                contrato.fechaCreacion = fechaCreacionFormat;

                string fechaTerminoFormat = String.Format("{0:dd-MM-yyyy}", fechaTermino);
                contrato.fechaTermino = fechaTerminoFormat;

                contrato.idUsuario = usuario.idUsuario;
                contrato.pdfContrato = pdfContrato;

                if (contrato != null)
                {
                    string json = JsonConvert.SerializeObject(contrato);
                    data = new(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client
                        .PostAsync("http://localhost:5000/api/contrato/insertar", data);
                    HttpStatusCode codeStatus = response.StatusCode;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Obtiene todos los roles del sistema
        public async Task<ObservableCollection<Usuario>> ObtenerUsuariosAsync()
        {
            ObservableCollection<Usuario> usuariosFromApi = new();
            string url = "http://localhost:5000/api/auth/usuarios";

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
                    bool actividad = false;

                    switch (rows[i][6].ToString())
                    {
                        case "1":
                            actividad = true;
                            break;
                        case "0":
                            actividad = false;
                            break;
                        default:
                            break;
                    }

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

        private async Task SetContratos()
        {
            contratos = await ObtenerContratosAsync();
        }
    }
}