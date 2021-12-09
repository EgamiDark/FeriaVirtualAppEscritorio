using FeriaVirtualApp.Core;

namespace FeriaVirtualApp.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand UsuariosViewCommand { get; set; }
        public RelayCommand VentasExternasViewCommand { get; set; }
        public RelayCommand VentasLocalesViewCommand { get; set; }
        public RelayCommand SubastasViewCommand { get; set; }
        public RelayCommand ProductosViewCommand { get; set; }
        public RelayCommand ContratosViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public UsuariosViewModel UsuariosVM { get; set; }
        public VentasExternasViewModel VentasExternasVM { get; set; }
        public VentasLocalesViewModel VentasLocalesVM { get; set; }
        public SubastasViewModel SubastasVM { get; set; }
        public ProductosViewModel ProductosVM { get; set; }
        public ContratoViewModel ContratosVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            UsuariosVM = new UsuariosViewModel();
            VentasExternasVM = new VentasExternasViewModel();
            VentasLocalesVM = new VentasLocalesViewModel();
            SubastasVM = new SubastasViewModel();
            ProductosVM = new ProductosViewModel();
            ContratosVM = new ContratoViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            UsuariosViewCommand = new RelayCommand(o =>
            {
                CurrentView = UsuariosVM;
            });

            VentasExternasViewCommand = new RelayCommand(o =>
            {
                CurrentView = VentasExternasVM;
            });

            VentasLocalesViewCommand = new RelayCommand(o =>
            {
                CurrentView = VentasLocalesVM;
            });


            SubastasViewCommand = new RelayCommand(o =>
            {
                CurrentView = SubastasVM;
            });

            ProductosViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductosVM;
            });

            ContratosViewCommand = new RelayCommand(o =>
            {
                CurrentView = ContratosVM;
            });
        }
    }
}
