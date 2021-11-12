using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeriaVirtualApp.Views.Subastas
{
    /// <summary>
    /// Interaction logic for CrearUsuarioView.xaml
    /// </summary>
    public partial class ModificarSubastaView : Window
    {
        public event EventHandler<string> AfterClosingEvent;
        private readonly SubastasViewModel SVM;

        public ModificarSubastaView(int id)
        {
            InitializeComponent();
            txtTitulo.Text = "Modificar Subasta";
            btnModificarSubasta.Content = "Modificar";
            SVM = new SubastasViewModel();
            SetValues(id);
        }

        private async Task SetValues(int id)
        {
            SVM.tpRefrigerantes = await SVM.ObtenerTipoRefrigeranteAsync();
            SVM.tpTransportes = await SVM.ObtenerTipoTransporteAsync();
            SubastasTrans s = await SVM.ObtenerSubastaAsync(id);
            txtIdSubastaTrans.Text = s.idSubastaTrans.ToString();
            if(s.idTipoVenta == 1)
            {
                txtIdVenta.Text = s.idPedido.ToString();
            }
            if (s.idTipoVenta == 2)
            {
                txtIdVenta.Text = s.idVentaLocal.ToString();
            }
            txtTipoVenta.Text = s.tipoVenta;
            dpFechaTermino.Text = s.fechaTermino;
            txtIdSubastaTrans.Text = s.idSubastaTrans.ToString();
            cbTipoRefrigerante.SelectedValue = s.idTipoRefrig;
            cbTipoTransporte.SelectedValue = s.idTipoTrans;
            DataContext = SVM;
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AfterClosingEvent?.Invoke(this, "");
        }

        private async void btnModificarSubasta_Click(object sender, RoutedEventArgs e)
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
                    s.idSubastaTrans = int.Parse(txtIdSubastaTrans.Text);
                    var fecha = String.Format("{0:dd-MM-yyyy}", dpFechaTermino.SelectedDate.Value);
                    s.fechaTermino = fecha;
                    s.idTipoRefrig = int.Parse(cbTipoRefrigerante.SelectedValue.ToString());
                    s.idTipoTrans = int.Parse(cbTipoTransporte.SelectedValue.ToString());
                    await SVM.ModificarSubasta(s);
                    MessageBox.Show("Subasta Modificada");
                    Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error desde la bd");
                throw;
            }
        }
    }
}
