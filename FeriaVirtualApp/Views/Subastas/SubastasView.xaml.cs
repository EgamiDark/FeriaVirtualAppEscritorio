using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

namespace FeriaVirtualApp.Views.Subastas
{
    /// <summary>
    /// Interaction logic for SubastasView.xaml
    /// </summary>
    public partial class SubastasView : UserControl
    {
        private SubastasViewModel SVM;
        private int cantOfertas=0;
        public SubastasView()
        {
            InitializeComponent();
            SVM = new SubastasViewModel();
            SetValues();
        }

        private async Task SetValues()
        {
            SVM = new SubastasViewModel();
            SVM.subastas = await SVM.ObtenerSubastasAsync();
            DataContext = SVM;
        }

        private async void btnVerOfertas_Click(object sender, RoutedEventArgs e)
        {
            SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;

            OfertasView ofertaView = new OfertasView(subasta.idSubastaTrans);
            ofertaView.ShowDialog();
            ofertaView.Closing += (o, s) =>
            {
                MessageBox.Show("Ofertas vistas: " + s);
            };
            
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
            try
            {
                await ConfirmarOfertas(subasta.idSubastaTrans);
                if (cantOfertas>0) {
                    MessageBox.Show("No puede modificar una subasta que ya posee ofertas", "Subasta no modificable");
                }
                else
                {
                    ModificarSubastaView modificarSubastaView = new ModificarSubastaView(subasta.idSubastaTrans);
                    modificarSubastaView.ShowDialog();
                    modificarSubastaView.Closing += (o, s) =>
                    {
                        MessageBox.Show("Subasta modificada: " + s);
                    };
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error desde la bd");
                throw;
            }
            
            SetValues();
        }

        private async Task ConfirmarOfertas(int id)
        {
            SVM = new SubastasViewModel();
            cantOfertas = 0;
            var a = await SVM.ObtenerOfertasAsync(id);
            cantOfertas = a.Count;
        }

        private async void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
            if(subasta.estadoSubasta == "EN PROCESO")
            {
                var result = MessageBox.Show("¿Esta seguro que desea terminar esta subasta?", "Terminar Subasta", MessageBoxButton.YesNo);
                if (result.ToString() == "Yes")
                {
                    await ConfirmarOfertas(subasta.idSubastaTrans);
                    if (cantOfertas == 0)
                    {
                        MessageBox.Show("No puede terminar una subasta que no posee ofertas", "Subasta no terminable");
                    }
                    else
                    {
                        var fechaHoy = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                        subasta.fechaTermino = fechaHoy;
                        await SVM.TerminarSubasta(subasta);
                        MessageBox.Show("Subasta Terminada");
                    }
                    SetValues();
                }
            }
            else
            {
                MessageBox.Show("Esta Subasta ya ha terminado o ha sido cancelada","Error");
            }
            
        }

        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
            if (subasta.estadoSubasta == "EN PROCESO")
            {
                var result = MessageBox.Show("¿Esta seguro que desea cancelar esta subasta?", "Cancelar Subasta", MessageBoxButton.YesNo);
                if (result.ToString() == "Yes")
                {

                    await SVM.CancelarSubasta(subasta);
                    MessageBox.Show("Subasta Cancelar");
                    SetValues();
                }
            }
            else
            {
                MessageBox.Show("Esta Subasta ya ha terminado o ha sido cancelada", "Error");
            }
        }
    }
}
