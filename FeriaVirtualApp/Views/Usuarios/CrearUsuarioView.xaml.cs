using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            txtTitulo.Text = "Ingresar Usuario";
            btnGuardar.Content = "Guardar Usuario";
            UVM = new UsuariosViewModel();
            SetValues();
        }

        public CrearUsuarioView(Usuario usuario)
        {
            InitializeComponent();
            txtTitulo.Text = "Actualizar Usuario";
            btnGuardar.Content = "Actualizar Usuario";
            UVM = new UsuariosViewModel(usuario);
            SetValues();
        }

        private async Task SetValues()
        {
            UVM.Roles = await UVM.ObtenerRolesAsync();
            DataContext = UVM;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (!Validation.GetHasError(txtRut))
            {
                if (!Validation.GetHasError(txtNombre))
                {
                    if (!Validation.GetHasError(txtApellidos))
                    {
                        if (!Validation.GetHasError(txtEmail))
                        {
                            if (!Validation.GetHasError(txtContra))
                            {
                                if (!Validation.GetHasError(txtDireccion))
                                {
                                    if (!Validation.GetHasError(txtTelefono))
                                    {
                                        await UVM.GuAcUsuario();
                                        MessageBox.Show("Usuario guardado!");
                                        Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ForceValidation()
        {
            txtRut.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtApellidos.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtEmail.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtContra.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtDireccion.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            txtTelefono.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
