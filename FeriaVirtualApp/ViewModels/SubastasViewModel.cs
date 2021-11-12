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
    public class SubastasViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SubastasTrans> subastas { get; set; }

        public ObservableCollection<OfertaTrans> ofertas { get; set; }

        public ObservableCollection<TipoRefrigerante> tpRefrigerantes { get; set; }
        public ObservableCollection<TipoTransporte> tpTransportes { get; set; }

        public async Task<ObservableCollection<SubastasTrans>> ObtenerSubastasAsync()
        {
            ObservableCollection<SubastasTrans> subastasTransFromApi = new();
            string url = "http://localhost:5000/api/subasta/subastas";
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

                    SubastasTrans subasta = new()
                    {
                        idSubastaTrans = int.Parse(rows[i][0].ToString()),
                        fechaSubasta = rows[i][1].ToString(),
                        fechaTermino = rows[i][2].ToString(),
                        estadoSubasta = rows[i][10].ToString()
                    };

                    subastasTransFromApi.Add(subasta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return subastasTransFromApi;
        }

        public async Task<ObservableCollection<OfertaTrans>> ObtenerOfertasAsync(int id)
        {
            ObservableCollection<OfertaTrans> ofertasTransFromApi = new();
            string url = "http://localhost:5000/api/subasta/ofertas/subasta/" + id;
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

                    OfertaTrans oferta = new()
                    {
                        cantidadTransporte = int.Parse(rows[i][2].ToString()),
                        fechaEntrega = rows[i][3].ToString(),
                        precioOferta = int.Parse(rows[i][1].ToString()),
                        estadoOferta = rows[i][17].ToString()

                    };

                    ofertasTransFromApi.Add(oferta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ofertasTransFromApi;
        }

        public async Task<SubastasTrans> ObtenerSubastaAsync(int id)
        {
            SubastasTrans subastaFromApi = new();
            string url = "http://localhost:5000/api/subasta/subasta/" + id;
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
                    SubastasTrans subasta = new SubastasTrans();
                    if (int.Parse(rows[i][9].ToString()) == 1)
                    {
                        subasta = new()
                        {
                            idSubastaTrans = int.Parse(rows[i][0].ToString()),
                            fechaTermino = rows[i][2].ToString(),
                            idPedido = int.Parse(rows[i][3].ToString()),
                            idTipoRefrig = int.Parse(rows[i][5].ToString()),
                            idTipoTrans = int.Parse(rows[i][6].ToString()),
                            idTipoVenta = int.Parse(rows[i][9].ToString()),
                            tipoVenta = rows[i][10].ToString()
                        };
                    }
                    if (int.Parse(rows[i][9].ToString()) == 2)
                    {
                        subasta = new()
                        {
                            idSubastaTrans = int.Parse(rows[i][0].ToString()),
                            fechaTermino = rows[i][2].ToString(),
                            idVentaLocal = int.Parse(rows[i][4].ToString()),
                            idTipoRefrig = int.Parse(rows[i][5].ToString()),
                            idTipoTrans = int.Parse(rows[i][6].ToString()),
                            idTipoVenta = int.Parse(rows[i][9].ToString()),
                            tipoVenta = rows[i][10].ToString()
                        };
                    }

                    subastaFromApi = subasta;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return subastaFromApi;
        }

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

        public async Task ModificarSubasta(SubastasTrans s)
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
                        .PostAsync("http://localhost:5000/api/subasta/modificarSubasta", data);
                    HttpStatusCode codeStatus = response.StatusCode;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        public async Task TerminarSubasta(SubastasTrans s)
        {
            StringContent data;
            HttpClient client = new();

            try
            {

                string json = JsonConvert.SerializeObject(s);
                data = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client
                    .PostAsync("http://localhost:5000/api/subasta/terminarSubasta", data);
                HttpStatusCode codeStatus = response.StatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        public async Task CancelarSubasta(SubastasTrans s)
        {
            StringContent data;
            HttpClient client = new();

            try
            {

                string json = JsonConvert.SerializeObject(s);
                data = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client
                    .PostAsync("http://localhost:5000/api/subasta/cancelarSubasta", data);
                HttpStatusCode codeStatus = response.StatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

    }
}
