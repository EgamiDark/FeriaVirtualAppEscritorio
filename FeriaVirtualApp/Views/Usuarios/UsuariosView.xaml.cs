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
            IEnumerable<Usuario> filtroUsuarios = UVM.Usuarios
                .Where(u => u.Nombre.Contains(txtSearch.Text) ||
                            u.Apellidos.Contains(txtSearch.Text));

            dgUsuarios.ItemsSource = filtroUsuarios;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CrearUsuarioView crearUsuarioView = new();
            crearUsuarioView.ShowDialog();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = dgUsuarios.SelectedItem as Usuario;

            CrearUsuarioView crearUsuarioView = new(usuario);

            crearUsuarioView.ShowDialog();
        }

        private async Task SetValues()
        {
            UVM = new UsuariosViewModel();
            UVM.Usuarios = await UVM.ObtenerUsuariosAsync();
            DataContext = UVM;
        }
    }
}
