using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
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

namespace FeriaVirtualApp.Views.Contratos
{
    /// <summary>
    /// Lógica de interacción para ContratosView.xaml
    /// </summary>
    public partial class ContratosView : UserControl
    {
        private ContratoViewModel CVM;

        public ContratosView()
        {
            InitializeComponent();
            CVM = new ContratoViewModel();
            DataContext = CVM;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            IEnumerable<Contrato> filtroContratos = CVM.contratos
                .Where(u => u.fechaCreacion.ToString().Contains(txtSearch.Text));

            dgContratos.ItemsSource = filtroContratos;
        }

        private void BtnCrearContrato_Click(object sender, RoutedEventArgs e)
        {
            CrearContratoView crearContratoView = new();
            crearContratoView.ShowDialog();
            crearContratoView.Closing += (o, s) =>
            {
                MessageBox.Show("Contrato agregado: " + s);
            };

            SetValues();
        }

        private async Task SetValues()
        {
            CVM = new ContratoViewModel();
            CVM.contratos = await CVM.ObtenerContratosAsync();
            DataContext = CVM;
        }
    }
}
