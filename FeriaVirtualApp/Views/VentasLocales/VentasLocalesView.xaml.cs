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

namespace FeriaVirtualApp.Views.VentasLocales
{
    /// <summary>
    /// Interaction logic for VentasView.xaml
    /// </summary>
    public partial class VentasLocalesView : UserControl
    {

        private VentasLocalesViewModel VLVM;
        public VentasLocalesView()
        {
            InitializeComponent();
            VLVM = new VentasLocalesViewModel();
            SetValues();
        }

        private async Task SetValues()
        {
            VLVM = new VentasLocalesViewModel();
            VLVM.ventasLocales = await VLVM.ObtenerVentasLocalesAsync();
            DataContext = VLVM;
        }

        private void btnSubastar_Click(object sender, RoutedEventArgs e)
        {
            VentaLocal ventaLocal = dgVentasLocales.SelectedItem as VentaLocal;

            SubastarView subastarView = new(ventaLocal);

            subastarView.ShowDialog();

            subastarView.Closing += (o, s) =>
            {
                MessageBox.Show("Subasta ingresada: " + s);
            };

            SetValues();
        }

    }
}
