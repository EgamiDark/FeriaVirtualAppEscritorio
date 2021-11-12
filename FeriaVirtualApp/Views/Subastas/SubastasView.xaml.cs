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

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
            ModificarSubastaView modificarSubastaView = new ModificarSubastaView(subasta.idSubastaTrans);
            modificarSubastaView.ShowDialog();
            modificarSubastaView.Closing += (o, s) =>
            {
                MessageBox.Show("Subasta modificada: " + s);
            };
            SetValues();
        }

        private async void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            var result =MessageBox.Show("¿Esta seguro que desea terminar esta subasta?","Terminar Subasta", MessageBoxButton.YesNo);
            if(result.ToString() == "Yes")
            {
                SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
                var fechaHoy = String.Format("{0:dd-MM-yyyy}", DateTime.Now);
                subasta.fechaTermino = fechaHoy;
                await SVM.TerminarSubasta(subasta);
                MessageBox.Show("Subasta Terminada");
                SetValues();
            }
        }

        private async void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("¿Esta seguro que desea cancelar esta subasta?", "Cancelar Subasta", MessageBoxButton.YesNo);
            if (result.ToString() == "Yes")
            {
                SubastasTrans subasta = dgSubastas.SelectedItem as SubastasTrans;
                await SVM.CancelarSubasta(subasta);
                MessageBox.Show("Subasta Cancelar");
                SetValues();
            }
        }
    }
}
