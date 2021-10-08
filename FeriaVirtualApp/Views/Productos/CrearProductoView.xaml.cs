using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FeriaVirtualApp.Views.Productos
{
    /// <summary>
    /// Interaction logic for CrearProductoView.xaml
    /// </summary>
    public partial class CrearProductoView : Window
    {
        private readonly ProductosViewModel PVM;

        public CrearProductoView()
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Producto";
            btnGuardar.Content = "Ingresar";
            PVM = new ProductosViewModel();
            DataContext = PVM;
        }

        public CrearProductoView(Producto producto)
        {
            InitializeComponent();
            txtTitulo.Text = "Actualizar Producto";
            btnGuardar.Content = "Actualizar";
            PVM = new ProductosViewModel(producto);
            DataContext = PVM;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (!Validation.GetHasError(txtNombre))
            {
                if (!Validation.GetHasError(txtStock))
                {
                    await PVM.GuAcProducto();
                    MessageBox.Show("Usuario guardado!");
                    Close();
                }
            }
        }

        private void ForceValidation()
        {
            txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtStock.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void txtStock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexSoloNumeros = new Regex("[^0-9]+");
            e.Handled = regexSoloNumeros.IsMatch(e.Text);
        }
    }
}
