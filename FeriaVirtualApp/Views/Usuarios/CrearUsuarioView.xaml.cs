﻿using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
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
        public event EventHandler<string> AfterClosingEvent;
        private readonly UsuariosViewModel UVM;

        public CrearUsuarioView()
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Usuario";
            btnGuardar.Content = "Guardar Usuario";
            actividad.IsChecked = true;
            UVM = new UsuariosViewModel();
            SetValues();
        }

        public CrearUsuarioView(Usuario usuario)
        {
            InitializeComponent();
            txtTitulo.Text = "Actualizar Usuario";
            btnGuardar.Content = "Actualizar Usuario";
            actividad.IsChecked = usuario.actividad;
            UVM = new UsuariosViewModel(usuario);
            SetValues();
        }

        private async Task SetValues()
        {
            UVM.roles = await UVM.ObtenerRolesAsync();
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
                                        UVM.actividad = actividad.IsChecked.Value;
                                        string mensajeMetodo = await UVM.GuAcUsuario();

                                        if (mensajeMetodo == "Usuario ya existe!")
                                        {
                                            MessageBox.Show(mensajeMetodo);
                                        }
                                        else
                                        {
                                            MessageBox.Show(mensajeMetodo);
                                            Close();
                                        }
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AfterClosingEvent?.Invoke(this, txtNombre.Text);
        }
    }
}
