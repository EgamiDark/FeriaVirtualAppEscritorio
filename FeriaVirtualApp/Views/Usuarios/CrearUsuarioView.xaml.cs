using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace FeriaVirtualApp.Views.Usuarios
{
    /// <summary>
    /// Interaction logic for CrearUsuarioView.xaml
    /// </summary>
    public partial class CrearUsuarioView : Window
    {
        private UsuariosViewModel UVM;

        public CrearUsuarioView()
        {
            InitializeComponent();
            UVM = new UsuariosViewModel();
            SetRoles();
        }

        public CrearUsuarioView(Usuario usuario)
        {
            InitializeComponent();
            UVM = new UsuariosViewModel(usuario);
            SetRoles();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UVM.OpenView = false;
        }

        private async Task SetRoles()
        {
            UVM = new UsuariosViewModel();
            UVM.Roles = await UVM.ObtenerRolesAsync();
            DataContext = UVM;
        }
    }
}
