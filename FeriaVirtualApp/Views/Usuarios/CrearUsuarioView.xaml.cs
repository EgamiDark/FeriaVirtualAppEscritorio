using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System.Windows;

namespace FeriaVirtualApp.Views.Usuarios
{
    /// <summary>
    /// Interaction logic for CrearUsuarioView.xaml
    /// </summary>
    public partial class CrearUsuarioView : Window
    {
        private readonly UsuariosViewModel UVM;

        public CrearUsuarioView()
        {
            InitializeComponent();
            UVM = new UsuariosViewModel();
        }

        public CrearUsuarioView(Usuario usuario)
        {
            InitializeComponent();
            UVM = new UsuariosViewModel(usuario);
            DataContext = UVM;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UVM.OpenView = false;
        }
    }
}
