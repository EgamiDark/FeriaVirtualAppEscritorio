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
    public class VentasExternasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TipoRefrigerante> tpRefrigerantes { get; set; }
        public ObservableCollection<TipoTransporte> tpTransportes { get; set; }
        public ObservableCollection<VentaExterna> ventasExternas { get; set; }

        private VentaExterna _ventaExterna;
        public VentaExterna ventaExterna
        {
            get => _ventaExterna;
            set
            {
                if (_ventaExterna != null)
                {
                    _ventaExterna = value;
                    OnPropertyChanged(nameof(ventaExterna));
                }
            }
        }

        private int _idVentaExterna;
        public int idVentaExterna
        {
            get => _idVentaExterna;
            set
            {
                if (_idVentaExterna != null)
                {
                    _idVentaExterna = value;
                    OnPropertyChanged(nameof(idVentaExterna));
                }
            }
        }

        public VentasExternasViewModel()
        {
            ventaExterna = new();
        }

        public VentasExternasViewModel(VentaExterna upVentaExterna)
        {
            try
            {
                idVentaExterna = upVentaExterna.idVentaExterna;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<ObservableCollection<VentaExterna>> ObtenerVentasExternasAsync()
        {
            ObservableCollection<VentaExterna> ventasExternasFromApi = new();
            string url = "http://localhost:5000/api/pedido/obtener/terminados";
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

                    VentaExterna ventaExterna = new()
                    {
                        idVentaExterna = int.Parse(rows[i][0].ToString()),
                        nombreProducto = rows[i][1].ToString(),
                        solicitante = rows[i][2].ToString(),
                        kgUnidad = int.Parse(rows[i][3].ToString()),
                        cantidad = int.Parse(rows[i][4].ToString()),
                        direccion = rows[i][5].ToString(),
                    };

                    ventasExternasFromApi.Add(ventaExterna);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ventasExternasFromApi;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Obtiene todos los tipos de refrigerante del sistema
        public async Task<ObservableCollection<TipoRefrigerante>> ObtenerTipoRefrigeranteAsync()
        {
            ObservableCollection<TipoRefrigerante> tiposRefrigeranteFromApi = new();
            string url = "http://localhost:5000/api/datosFk/tRefrigeracion";

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
                    TipoRefrigerante tipoRefrigerante = new()
                    {
                        idTipoRefrigerante = int.Parse(rows[i][0].ToString()),
                        descripcion = rows[i][1].ToString()
                    };

                    tiposRefrigeranteFromApi.Add(tipoRefrigerante);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tiposRefrigeranteFromApi;
        }

        // Obtiene todos los tipos de transporte del sistema
        public async Task<ObservableCollection<TipoTransporte>> ObtenerTipoTransporteAsync()
        {
            ObservableCollection<TipoTransporte> tiposTransporteFromApi = new();
            string url = "http://localhost:5000/api/datosFk/tTransporte";

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
                    TipoTransporte tipoTransporte = new()
                    {
                        idTipoTransporte = int.Parse(rows[i][0].ToString()),
                        descripcion = rows[i][1].ToString()
                    };

                    tiposTransporteFromApi.Add(tipoTransporte);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return tiposTransporteFromApi;
        }

        public async Task IngresarSubasta(SubastasTrans s)
        {
            StringContent data;
            HttpClient client = new();

            try
            {
                if (s != null)
                {
                    string json = JsonConvert.SerializeObject(s);
                    data = new(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client
                        .PostAsync("http://localhost:5000/api/subasta/insertarSubasta", data);
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
