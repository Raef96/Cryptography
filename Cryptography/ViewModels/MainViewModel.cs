namespace Cryptography.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private object? _currentView;

        public MainViewModel()
        {
            KeysVM = new KeysViewModel();
            EncryptionVM = new EncryptionViewModel();

            CurrentView = KeysVM;

            KeysViewCommand = new RelayCommand(o => CurrentView = KeysVM);
            EncryptionViewCommand = new RelayCommand(o => CurrentView = EncryptionVM);
        }

        #region Properties
        public KeysViewModel KeysVM { get; set; }
        public EncryptionViewModel EncryptionVM { get; set; }
        public object? CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        #endregion

        #region Commands
        public RelayCommand KeysViewCommand { get; set; }
        public RelayCommand EncryptionViewCommand { get; set; }
        #endregion

    }
}
