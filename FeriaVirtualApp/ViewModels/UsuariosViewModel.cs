using FeriaVirtualApp.Core;
using FeriaVirtualApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FeriaVirtualApp.ViewModels
{
    public class UsuariosViewModel
    {
        public List<Usuario> Usuarios { get; set; }
        public Usuario Usuario { get; set; }
        public bool OpenView { get; set; }

        private ICommand _guardarUsuario;
        public ICommand GuardarUsuario => _guardarUsuario ??= new CommandHandler(() => GuardarUsu(Usuario), true);

        public UsuariosViewModel()
        {
            Usuarios = new List<Usuario>
            {
                new Usuario{ IdUsuario = 1, Nombre = "Nicolas", Apellidos = "Cortes Azua", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 2, Nombre = "Matias", Apellidos = "San Martin", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 3, Nombre = "Felipe", Apellidos = "Azua", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 4, Nombre = "Frank", Apellidos = "Aravena", Direccion = "bbbbbbbbbbbbb"},
                new Usuario{ IdUsuario = 5, Nombre = "Jose", Apellidos = "Mansilla", Direccion = "ccccccccccccc"},
                new Usuario{ IdUsuario = 6, Nombre = "Belgica", Apellidos = "Campos", Direccion = "ddddddddddddd"},
                new Usuario{ IdUsuario = 7, Nombre = "Mario", Apellidos = "Diaz", Direccion = "eeeeeeeeeee"},
                new Usuario{ IdUsuario = 8, Nombre = "Juanito", Apellidos = "Perez", Direccion = "fffffffffff"},
                new Usuario{ IdUsuario = 9, Nombre = "Gustavo", Apellidos = "Caceres", Direccion = "Av. Siempre viva"},
                new Usuario{ IdUsuario = 10, Nombre = "Manuel", Apellidos = "Muñoz", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 11, Nombre = "Mickel", Apellidos = "Gutierrez", Direccion = "AAaaaa"},
                new Usuario{ IdUsuario = 12, Nombre = "Gisela", Apellidos = "Soto", Direccion = "AAaaaa"},
            };

            OpenView = false;
        }

        public UsuariosViewModel(Usuario upUsuario)
        {
            Usuario = upUsuario;
        }

        public static void GuardarUsu(Usuario upUsuario)
        {
            return;
        }
    }

    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}