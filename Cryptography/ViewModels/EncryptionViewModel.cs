using System.Windows.Input;

namespace Cryptography.App.ViewModels
{
    internal class EncryptionViewModel : BaseViewModel
    {
        private string _encryptedText;
        private string _keysForEncryption;
        private string _textToEncrypt;

        public EncryptionViewModel()
        {
            _encryptedText = string.Empty;
            _keysForEncryption = string.Empty;
            _textToEncrypt = string.Empty;

            ContentCopyVM = new ContentCopyViewModel();
            EncryptCommand = new RelayCommand(EncryptText, () => true);
        }

        #region Properties
        public string EncryptedText
        {
            get { return _encryptedText; }
            set
            {
                if (_encryptedText != value)
                {
                    _encryptedText = value;
                    ContentCopyVM.TextContent = _encryptedText;
                    OnPropertyChanged(nameof(EncryptedText));
                }
            }
        }
        public string KeysForEncryption
        {
            get { return _keysForEncryption; }
            set
            {
                if (_keysForEncryption != value)
                {
                    _keysForEncryption = value;
                    OnPropertyChanged(nameof(KeysForEncryption));
                }
            }
        }
        public string TextToEncrypt
        {
            get { return _textToEncrypt; }
            set
            {
                if (_textToEncrypt != value)
                {
                    _textToEncrypt = value;
                    OnPropertyChanged(nameof(TextToEncrypt));
                }
            }
        }
        public ContentCopyViewModel ContentCopyVM { get; private set; }
        #endregion

        public ICommand EncryptCommand { get; private set; }

        public void EncryptText()
        {
            // TODO
            EncryptedText = KeysForEncryption;
        }

    }
}
