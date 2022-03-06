using System.Windows.Input;
using System.Collections.Generic;
using Cryptography.App.Models;

namespace Cryptography.App.ViewModels
{
    internal class KeysViewModel : BaseViewModel
    {
        public static List<string> EncryptionTypeLabels { get; } = new List<string>()
        {
            EncryptionType.AsymetricEncryption,
            EncryptionType.SymetricEncryption
        };

        #region Files
        private string _encryptionType;
        private string _generatedKeys;
        private bool _generateKeysButtonIsEnable;
        #endregion

        public KeysViewModel()
        {
            _encryptionType = string.Empty;
            _generatedKeys = string.Empty;
            _generateKeysButtonIsEnable = false;

            ContentCopyVM = new ContentCopyViewModel();

            Generate = new RelayCommand(GenerateKeys, () => true);
        }

        #region Properties
        public string SelectedEncryptionType
        {
            get { return _encryptionType; }
            set
            {
                if (_encryptionType != value)
                {
                    _encryptionType = value;
                    GenerateKeysButtonIsEnable = true;
                    OnPropertyChanged(nameof(SelectedEncryptionType));
                }
            }
        }
        public string GeneratedKeys
        {
            get { return _generatedKeys; }
            set
            {
                if (_generatedKeys != null && _generatedKeys != value)
                {
                    _generatedKeys = value;
                    ContentCopyVM.TextContent = _generatedKeys;
                    OnPropertyChanged(nameof(GeneratedKeys));
                }
            }
        }
        public bool GenerateKeysButtonIsEnable
        {
            get { return _generateKeysButtonIsEnable; }
            set
            {
                if (_generateKeysButtonIsEnable != value)
                {
                    _generateKeysButtonIsEnable = value;
                    OnPropertyChanged(nameof(GenerateKeysButtonIsEnable));
                }
            }
        }
        public ContentCopyViewModel ContentCopyVM { get; private set; }
        #endregion

        #region Commands
        public ICommand Generate { get; private set; }
        #endregion

        #region Methods
        public void GenerateKeys()
        {
            GeneratedKeys = "Keys are generated successfully";
        }
        #endregion
    }
}
