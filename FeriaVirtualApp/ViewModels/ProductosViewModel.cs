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
        public ObservableCollection<Producto> Productos
        {
            get => _productos;
            set
            {
                _productos = value;
                OnPropertyChanged(nameof(Productos));
            }
        }

        private int _idProducto;
        public int IdProducto
        {
            get => _idProducto;
            set
            {
                _idProducto = value;
                OnPropertyChanged(nameof(IdProducto));
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

        private byte[] _imagen;
        public byte[] Imagen
        {
            get => _imagen;
            set
            {
                _imagen = value;
                OnPropertyChanged(nameof(Imagen));
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
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
                    IdProducto = upProducto.IdProducto;
                    Nombre = upProducto.Nombre;
                    Imagen = upProducto.Imagen;
                    IsActive = upProducto.IsActive;
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
                JToken img = dataObj["img"];
                int length = rows.Count<object>();

                for (int i = 0; i < length; i++)
                {
                    // Convierte la actividad de string a booleano
                    actividad = rows[i][2].ToString() == "1";

                    byte[] image = Convert.FromBase64String(img[i].ToString());

                    Producto producto = new()
                    {
                        IdProducto = int.Parse(rows[i][0].ToString()),
                        Nombre = rows[i][1].ToString(),
                        IsActive = actividad,
                        Imagen = image
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
                if (IdProducto > 0)
                {
                    producto.IdProducto = IdProducto;
                }

                producto.Nombre = Nombre;
                producto.Imagen = Imagen;
                producto.IsActive = IsActive;

                if (producto != null)
                {
                    string json = JsonConvert.SerializeObject(producto);
                    data = new(json, Encoding.UTF8, "application/json");

                    if (producto.IdProducto > 0)
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
            Productos = await ObtenerProductosAsync();
        }
    }
}