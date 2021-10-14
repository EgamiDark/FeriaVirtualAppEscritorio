using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Generic;

namespace FeriaVirtualApp.Views.Productos
{
    /// <summary>
    /// Interaction logic for ProductosView.xaml
    /// </summary>
    public partial class ProductosView : UserControl
    {
        private ProductosViewModel PVM;

        public ProductosView()
        {
            InitializeComponent();
            PVM = new ProductosViewModel();
            SetValues();
        }

        private async Task SetValues()
        {
            PVM = new ProductosViewModel();
            PVM.Productos = await PVM.ObtenerProdctosAsync();
            DataContext = PVM;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            IEnumerable<Producto> filtroProductos = PVM.Productos
                .Where(u => u.Nombre.Contains(txtSearch.Text));

            dgProductos.ItemsSource = filtroProductos;
        }

        private void BtnCrearProducto_Click(object sender, RoutedEventArgs e)
        {
            CrearProductoView crearProductoView = new();
            crearProductoView.ShowDialog();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = dgProductos.SelectedItem as Producto;
            CrearProductoView crearProductoView = new(producto);
            crearProductoView.ShowDialog();
        }
    }
}
