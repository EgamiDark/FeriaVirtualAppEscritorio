using FeriaVirtualApp.Models;
using FeriaVirtualApp.ViewModels;

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using Microsoft.Win32;
using System.Windows.Media;

namespace FeriaVirtualApp.Views.Productos
{
    /// <summary>
    /// Interaction logic for CrearProductoView.xaml
    /// </summary>
    public partial class CrearProductoView : Window
    {
        private readonly ProductosViewModel PVM;

        public CrearProductoView()
        {
            InitializeComponent();
            txtTitulo.Text = "Ingresar Producto";
            btnGuardar.Content = "Ingresar";
            PVM = new ProductosViewModel();
            DataContext = PVM;
        }

        public CrearProductoView(Producto producto)
        {
            InitializeComponent();
            txtTitulo.Text = "Actualizar Producto";
            btnGuardar.Content = "Actualizar";

            try
            {
                BitmapImage bi = new();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(producto.Imagen);
                bi.EndInit();

                ImgProducto.Source = bi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            PVM = new ProductosViewModel(producto);
            DataContext = PVM;
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ForceValidation();
            if (!Validation.GetHasError(txtNombre))
            {
                PVM.Imagen = ObtenerByteImagen();
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
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = @"" + openFileDialog.FileName;

                byte[] binaryData = ObtenerByteRuta(imagePath);

                BitmapImage bi = new();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                ImgProducto.Source = bi;
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
                BitmapImage bmp = ImgProducto.Source as BitmapImage;
                JpegBitmapEncoder encoder = new();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(ms);
                arr = ms.ToArray();
            }

            return arr;
        }
    }
}
