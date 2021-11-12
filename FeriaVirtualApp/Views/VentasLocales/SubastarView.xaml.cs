using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeriaVirtualApp.Views.VentasLocales
{
    /// <summary>
    /// Interaction logic for CrearUsuarioView.xaml
    /// </summary>
    public partial class SubastarView : Window
    {
        public event EventHandler<string> AfterClosingEvent;
        private readonly VentasLocalesViewModel VLVM;

        public SubastarView(VentaLocal ventaLocal)
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Subasta";
            btnGuardar.Content = "Ingresar";
            VLVM = new VentasLocalesViewModel(ventaLocal);
            SetValues();
        }

        private async Task SetValues()
        {
            VLVM.tpRefrigerantes = await VLVM.ObtenerTipoRefrigeranteAsync();
            VLVM.tpTransportes = await VLVM.ObtenerTipoTransporteAsync();
            DataContext = VLVM;
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
                    s.idVentaLocal = int.Parse(txtIdVentaLocal.Text);
                    s.idTipoRefrig = int.Parse(cbTipoRefrigerante.SelectedValue.ToString());
                    s.idTipoTrans = int.Parse(cbTipoTransporte.SelectedValue.ToString());
                    s.idTipoVenta = 2;
                    var fechaHoy = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                    s.fechaSubasta = fechaHoy;
                    await VLVM.IngresarSubasta(s);
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
            AfterClosingEvent?.Invoke(this, txtIdVentaLocal.Text);
        }
    }
}
