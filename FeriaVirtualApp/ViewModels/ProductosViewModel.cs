using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using FeriaVirtualApp.Models;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace FeriaVirtualApp.ViewModels
{
    public class ProductosViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Producto> Productos { get; set; }

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

        private int _stock;
        public int Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
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

        public ProductosViewModel() { }

        public ProductosViewModel(Producto upProducto) 
        {
            try
            {
                if (upProducto != null)
                {
                    IdProducto = upProducto.IdProducto;
                    Nombre = upProducto.Nombre;
                    Stock = upProducto.Stock;
                    IsActive = upProducto.IsActive;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<ObservableCollection<Producto>> ObtenerUsuariosAsync()
        {
            ObservableCollection<Producto> usuariosFromApi = new();
            string url = "http://localhost:5000/api/producto/obtener/todos";
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
                    actividad = rows[i][3].ToString() == "1";

                    Producto producto = new()
                    {
                        IdProducto = int.Parse(rows[i][0].ToString()),
                        Nombre = rows[i][1].ToString(),
                        Stock = int.Parse(rows[i][2].ToString()),
                        IsActive = actividad
                    };

                    usuariosFromApi.Add(producto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return usuariosFromApi;
        }

        public async Task GuAcProducto()
        {
            StringContent data;
            Producto producto = new();
            HttpClient client = new();

            try
            {
                if(IdProducto > 0)
                {
                    producto.IdProducto = IdProducto;
                }

                producto.Nombre = Nombre;
                producto.Stock = Stock;
                producto.IsActive = IsActive;

                if (producto != null)
                {
                    if (producto.IdProducto > 0)
                    {
                        string json = JsonConvert.SerializeObject(producto);
                        data = new(json, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client
                            .PostAsync("http://localhost:5000/api/producto/modificar", data);
                        HttpStatusCode codeStatus = response.StatusCode;
                    }
                    else
                    {
                        string json = JsonConvert.SerializeObject(producto);
                        data = new(json, Encoding.UTF8, "application/json");

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
    }
}
