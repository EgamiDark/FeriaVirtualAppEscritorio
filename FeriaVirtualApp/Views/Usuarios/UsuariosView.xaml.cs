using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace FeriaVirtualApp.Views.Usuarios
{
    /// <summary>
    /// Interaction logic for UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        private readonly UsuariosViewModel UVM;

        public UsuariosView()
        {
            InitializeComponent();
            UVM = new UsuariosViewModel();
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
            UsuariosViewModel UsuariosVM = new();
            CrearUsuarioView crearUsuarioView = new();

            if (UsuariosVM.OpenView == false)
            {
                crearUsuarioView.Show();
                UsuariosVM.OpenView = true;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = dgUsuarios.SelectedItem as Usuario;
            UsuariosViewModel UsuarioVM = new(usuario);

            CrearUsuarioView crearUsuarioView = new(usuario);

            if (UsuarioVM.OpenView == false)
            {
                crearUsuarioView.Show();
                UsuarioVM.OpenView = true;
            }
        }
    }
}
