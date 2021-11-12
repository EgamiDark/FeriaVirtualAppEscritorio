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

namespace FeriaVirtualApp.Views.VentasExternas
{
    /// <summary>
    /// Interaction logic for VentasView.xaml
    /// </summary>
    public partial class VentasExternasView : UserControl
    {

        private VentasExternasViewModel VEVM;
        public VentasExternasView()
        {
            InitializeComponent();
            VEVM = new VentasExternasViewModel();
            SetValues();
        }

        private async Task SetValues()
        {
            VEVM = new VentasExternasViewModel();
            VEVM.ventasExternas = await VEVM.ObtenerVentasExternasAsync();
            DataContext = VEVM;
        }

        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            VentaExterna ventaExterna = dgVentasExternas.SelectedItem as VentaExterna;

            SubastarView subastarView = new(ventaExterna);

            subastarView.ShowDialog();

            subastarView.Closing += (o, s) =>
            {
                MessageBox.Show("Subasta ingresada: " + s);
            };

            SetValues();
        }

    }
}
