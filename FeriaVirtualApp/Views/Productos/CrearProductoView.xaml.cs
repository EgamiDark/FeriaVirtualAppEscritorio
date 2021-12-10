using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace FeriaVirtualApp.Views.Productos
{
    /// <summary>
    /// Interaction logic for CrearProductoView.xaml
    /// </summary>
    public partial class CrearProductoView : Window
    {
        public event EventHandler<string> AfterClosingEvent;
        private readonly ProductosViewModel PVM;

        public CrearProductoView()
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Producto";
            BtnGuardar.Content = "Ingresar";
            isActive.IsChecked = true;
            PVM = new ProductosViewModel();
            SetValues();
        }

        public CrearProductoView(Producto producto)
        {
            InitializeComponent();
            txtTitulo.Text = "Actualizar Producto";
            BtnGuardar.Content = "Actualizar";

            try
            {
                BitmapImage bi = new();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(producto.imagen);
                bi.EndInit();

                imgProducto.Source = bi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            isActive.IsChecked = producto.isActive;
            PVM = new ProductosViewModel(producto);
            SetValues();
        }

        private async Task SetValues()
        {
            DataContext = PVM;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();

            if (!Validation.GetHasError(txtNombre))
            {
                try
                {
                    PVM.imagen = ObtenerByteImagen();
                }
                catch (Exception)
                {
                }
                PVM.isActive = isActive.IsChecked.Value;
                await PVM.GuAcProducto();
                MessageBox.Show("Producto guardado!");
                Close();
            }
        }

        private void ForceValidation()
        {
            txtNombre.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void BtnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Imagenes|*.jpg; *.png; *.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = @"" + openFileDialog.FileName;

                byte[] binaryData = ObtenerByteRuta(imagePath);
                BitmapImage bi = new();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                imgProducto.Source = bi;
            }
        }

        protected static byte[] ObtenerByteRuta(string imgPath)
        {
            byte[] imageBytes = File.ReadAllBytes(imgPath);
            return imageBytes;
        }

        public byte[] ObtenerByteImagen()
        {
            byte[] arr;

            using (MemoryStream ms = new())
            {
                BitmapImage bmp = imgProducto.Source as BitmapImage;
                JpegBitmapEncoder encoder = new();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(ms);
                arr = ms.ToArray();
            }
            return arr;
        }



        private void Window_Closed(object sender, EventArgs e)
        {
            AfterClosingEvent?.Invoke(this, txtNombre.Text);
        }
    }
}
