using System.Windows.Input;

namespace Cryptography.App.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private object _currentView;
        private bool _isSelectedKeysVM;
        private bool _isSelectedEncryptionVM;

        public MainViewModel()
        {
            KeysVM = new KeysViewModel();
            EncryptionVM = new EncryptionViewModel();

            _currentView = KeysVM;
            _isSelectedKeysVM = true;
            _isSelectedEncryptionVM = false;

            KeysViewCommand = new RelayCommand(ChangeView, () => true);
            EncryptionViewCommand = new RelayCommand(ChangeView, () => true);
        }

        #region Properties
        public KeysViewModel KeysVM { get; set; }
        public EncryptionViewModel EncryptionVM { get; set; }
        public bool IsSelectedKeysVM
        {
            get { return _isSelectedKeysVM; }
            set
            {
                if (_isSelectedKeysVM != value)
                {
                    _isSelectedKeysVM = value;
                    OnPropertyChanged(nameof(IsSelectedKeysVM));

                }
            }
        }
        public bool IsSelectedEncryptionVM
        {
            get { return _isSelectedEncryptionVM; }
            set
            {
                if (_isSelectedEncryptionVM != value)
                {
                    _isSelectedEncryptionVM = value;
                    OnPropertyChanged(nameof(IsSelectedEncryptionVM));
                }
            }
        }


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
            if (IsSelectedEncryptionVM && _currentView == KeysVM)
            {
                CurrentView = EncryptionVM;
            }
            else if (IsSelectedKeysVM && _currentView == EncryptionVM)
            {
                CurrentView = KeysVM;
            }
        }
        #endregion

    }
}
