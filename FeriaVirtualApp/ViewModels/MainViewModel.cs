using FeriaVirtualApp.Core;

namespace FeriaVirtualApp.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand VentasViewCommand { get; set; }
        public RelayCommand ResumenVentasViewCommand { get; set; }
        public RelayCommand TransportistaViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public VentasViewModel VentasVM { get; set; }
        public ResumenVentasViewModel RVVM { get; set; }
        public TransportistaViewModel TransportistaVM { get; set; }

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
            VentasVM = new VentasViewModel();
            RVVM = new ResumenVentasViewModel();
            TransportistaVM = new TransportistaViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            VentasViewCommand = new RelayCommand(o =>
            {
                CurrentView = VentasVM;
            });

            ResumenVentasViewCommand = new RelayCommand(o =>
            {
                CurrentView = RVVM;
            });

            TransportistaViewCommand = new RelayCommand(o =>
            {
                CurrentView = TransportistaVM;
            });
        }
    }
}
