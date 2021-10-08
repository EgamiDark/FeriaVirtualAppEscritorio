using FeriaVirtualApp.Core;

namespace FeriaVirtualApp.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand UsuariosViewCommand { get; set; }
        public RelayCommand VentasViewCommand { get; set; }
        public RelayCommand ReportesViewCommand { get; set; }
        public RelayCommand TransportistaViewCommand { get; set; }
        public RelayCommand SubastasViewCommand { get; set; }
        public RelayCommand ProductosViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public UsuariosViewModel UsuariosVM { get; set; }
        public VentasViewModel VentasVM { get; set; }
        public ReportesViewModel ReportesVM { get; set; }
        public TransportistaViewModel TransportistaVM { get; set; }
        public SubastasViewModel SubastasVM { get; set; }
        public ProductosViewModel ProductosVM { get; set; }

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
            VentasVM = new VentasViewModel();
            ReportesVM = new ReportesViewModel();
            TransportistaVM = new TransportistaViewModel();
            SubastasVM = new SubastasViewModel();
            ProductosVM = new ProductosViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            UsuariosViewCommand = new RelayCommand(o =>
            {
                CurrentView = UsuariosVM;
            });

            VentasViewCommand = new RelayCommand(o =>
            {
                CurrentView = VentasVM;
            });

            ReportesViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReportesVM;
            });

            TransportistaViewCommand = new RelayCommand(o =>
            {
                CurrentView = TransportistaVM;
            });

            SubastasViewCommand = new RelayCommand(o =>
            {
                CurrentView = SubastasVM;
            });

            ProductosViewCommand = new RelayCommand(o =>
            {
                CurrentView = ProductosVM;
            });
        }
    }
}
