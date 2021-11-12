using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using FeriaVirtualApp.Models;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FeriaVirtualApp.ViewModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Producto> _productos;
        public ObservableCollection<Producto> productos
        {
            get => _productos;
            set
            {
                _productos = value;
                OnPropertyChanged(nameof(productos));
            }
        }

        private int _idProducto;
        public int idProducto
        {
            get => _idProducto;
            set
            {
                _idProducto = value;
                OnPropertyChanged(nameof(idProducto));
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

        private byte[] _imagen;
        public byte[] imagen
        {
            get => _imagen;
            set
            {
                _imagen = value;
                OnPropertyChanged(nameof(imagen));
            }
        }

        private bool _isActive;
        public bool isActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(isActive));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ProductosViewModel()
        {
            SetProductos();
        }

        public ProductosViewModel(Producto upProducto)
        {
            try
            {
                if (upProducto != null)
                {
                    idProducto = upProducto.idProducto;
                    nombre = upProducto.nombre;
                    imagen = upProducto.imagen;
                    isActive = upProducto.isActive;
                }

                SetProductos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<ObservableCollection<Producto>> ObtenerProductosAsync()
        {
            bool actividad;
            string url = "http://localhost:5000/api/producto/obtener/todos";

            HttpClient client = new();
            ObservableCollection<Producto> prductosFromApi = new();

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
                    // Convierte la actividad de string a booleano
                    actividad = rows[i][2].ToString() == "1";

                    byte[] image = Convert.FromBase64String(rows[i][3].ToString());

                    Producto producto = new()
                    {
                        idProducto = int.Parse(rows[i][0].ToString()),
                        nombre = rows[i][1].ToString(),
                        isActive = actividad,
                        imagen = image
                    };

                    prductosFromApi.Add(producto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return prductosFromApi;
        }

        public async Task GuAcProducto()
        {
            StringContent data;
            Producto producto = new();
            HttpClient client = new();

            try
            {
                if (idProducto > 0)
                {
                    producto.idProducto = idProducto;
                }

                producto.nombre = nombre;
                producto.imagen = imagen;
                producto.isActive = isActive;

                if (producto != null)
                {
                    string json = JsonConvert.SerializeObject(producto);
                    data = new(json, Encoding.UTF8, "application/json");

                    if (producto.idProducto > 0)
                    {
                        HttpResponseMessage response = await client
                            .PostAsync("http://localhost:5000/api/producto/modificar", data);
                        HttpStatusCode codeStatus = response.StatusCode;
                    }
                    else
                    {
                        HttpResponseMessage response = await client
                            .PostAsync("http://localhost:5000/api/producto/insertar", data);
                        HttpStatusCode codeStatus = response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task SetProductos()
        {
            productos = await ObtenerProductosAsync();
        }
    }
}