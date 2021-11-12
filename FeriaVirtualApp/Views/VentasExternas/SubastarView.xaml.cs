using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeriaVirtualApp.Views.VentasExternas
{
    /// <summary>
    /// Interaction logic for CrearUsuarioView.xaml
    /// </summary>
    public partial class SubastarView : Window
    {
        public event EventHandler<string> AfterClosingEvent;
        private readonly VentasExternasViewModel VEVM;

        public SubastarView(VentaExterna ventaExterna)
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Subasta";
            btnGuardar.Content = "Ingresar";
            VEVM = new VentasExternasViewModel(ventaExterna);
            SetValues();
        }

        private async Task SetValues()
        {
            VEVM.tpRefrigerantes = await VEVM.ObtenerTipoRefrigeranteAsync();
            VEVM.tpTransportes = await VEVM.ObtenerTipoTransporteAsync();
            DataContext = VEVM;
        }

        private async void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dpFechaTermino.Text.Trim() == "")
                {
                    MessageBox.Show("Seleccione una fecha de termino");
                }
                else
                {
                    SubastasTrans s = new SubastasTrans();
                    var fecha = String.Format("{0:dd-MM-yyyy}", dpFechaTermino.SelectedDate.Value);
                    s.fechaTermino = fecha;
                    s.idPedido = int.Parse(txtIdVentaExterna.Text);
                    s.idTipoRefrig = int.Parse(cbTipoRefrigerante.SelectedValue.ToString());
                    s.idTipoTrans = int.Parse(cbTipoTransporte.SelectedValue.ToString());
                    s.idTipoVenta = 1;
                    var fechaHoy = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    s.fechaSubasta = fechaHoy;
                    await VEVM.IngresarSubasta(s);
                    MessageBox.Show("Subasta Ingresada");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error desde la bd");
                throw;
            }
            

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AfterClosingEvent?.Invoke(this, txtIdVentaExterna.Text);
        }
    }
}
