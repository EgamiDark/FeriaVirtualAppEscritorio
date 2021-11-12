using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FeriaVirtualApp.Views.Subastas
{
    public partial class OfertasView : Window
    {
        public event EventHandler<string> AfterClosingEvent;
        private SubastasViewModel SVM;
        public OfertasView()
        {
            InitializeComponent();
        }

        public OfertasView(int id)
        {
            InitializeComponent();
            SVM = new SubastasViewModel();
            SetValues(id);
        }

        private async Task SetValues(int id)
        {
            SVM = new SubastasViewModel();
            SVM.ofertas = await SVM.ObtenerOfertasAsync(id);
            DataContext = SVM;
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AfterClosingEvent?.Invoke(this, "");
        }

    }
}
