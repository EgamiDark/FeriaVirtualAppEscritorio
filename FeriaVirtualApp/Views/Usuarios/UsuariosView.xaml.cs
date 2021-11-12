using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FeriaVirtualApp.Views.Usuarios
{
    /// <summary>
    /// Interaction logic for UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        private UsuariosViewModel UVM;

        public UsuariosView()
        {
            InitializeComponent();
            UVM = new UsuariosViewModel();
            SetValues();
        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            IEnumerable<Usuario> filtroUsuarios = UVM.usuarios
                .Where(u => u.nombre.Contains(txtSearch.Text) ||
                            u.apellidos.Contains(txtSearch.Text));

            dgUsuarios.ItemsSource = filtroUsuarios;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CrearUsuarioView crearUsuarioView = new();
            crearUsuarioView.ShowDialog();

            crearUsuarioView.Closing += (o, s) =>
            {
                MessageBox.Show("Producto agregado: " + s);
            };

            SetValues();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = dgUsuarios.SelectedItem as Usuario;

            CrearUsuarioView crearUsuarioView = new(usuario);

            crearUsuarioView.ShowDialog();

            crearUsuarioView.Closing += (o, s) =>
            {
                MessageBox.Show("Producto modificado: " + s);
            };

            SetValues();
        }

        private async Task SetValues()
        {
            UVM = new UsuariosViewModel();
            UVM.usuarios = await UVM.ObtenerUsuariosAsync();
            DataContext = UVM;
        }
    }
}
