using FeriaVirtualApp.ViewModels;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace FeriaVirtualApp.Views.Contratos
{
    /// <summary>
    /// Lógica de interacción para CrearContratoView.xaml
    /// </summary>
    public partial class CrearContratoView : Window
    {
        private readonly ContratoViewModel CVM;

        public CrearContratoView()
        {
            InitializeComponent();
            CVM = new ContratoViewModel();
            SetValues();
        }

        private async Task SetValues()
        {
            CVM.usuarios = await CVM.ObtenerUsuariosAsync();
            CVM.fechaCreacion = System.DateTime.Now;
            CVM.fechaTermino = System.DateTime.Now;
            DataContext = CVM;
        }

        private void BtnPdfContrato_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Documentos|*.pdf;";
            
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = @"" + openFileDialog.FileName;
                imgPdfContrato.Content = imagePath;
            }
        }

        protected static byte[] ObtenerByteRuta(string imgPath)
        {
            byte[] imageBytes = File.ReadAllBytes(imgPath);
            return imageBytes;
        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            ImageConverter _imageConverter = new();
            byte[] pdfImagenByte = (byte[])_imageConverter.ConvertTo(imageIn, typeof(byte[]));
            return pdfImagenByte;
        }

        private async void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            var pathFromLabel = imgPdfContrato.Content.ToString();
            byte[] binaryData = ObtenerByteRuta(pathFromLabel);
            CVM.pdfContrato = binaryData;
            await CVM.GuardarContrato();
            MessageBox.Show("Contrato guardado!");
            Close();
        }
    }
}