using System.Windows.Input;

namespace Cryptography.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private object _currentView;

        public MainViewModel()
        {
            KeysVM = new KeysViewModel();
            EncryptionVM = new EncryptionViewModel();

            _currentView = KeysVM;

            KeysViewCommand = new RelayCommand(ChangeView, () => true);
            EncryptionViewCommand = new RelayCommand(ChangeView, () => true);
        }

        #region Properties
        public KeysViewModel KeysVM { get; set; }
        public EncryptionViewModel EncryptionVM { get; set; }
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                if (_currentView == value) return;
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        #endregion

        #region Commands
        public ICommand KeysViewCommand { get; private set; }
        public ICommand EncryptionViewCommand { get; private set; }
        #endregion

        #region Methods
        public void ChangeView()
        {
            if(_currentView == KeysVM)
            {
                CurrentView = EncryptionVM;
            }
            else if (_currentView == EncryptionVM) 
            {
                CurrentView = KeysVM;
            }
        }
        #endregion

    }
}
