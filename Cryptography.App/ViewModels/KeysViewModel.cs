using System.Windows.Input;
using System.Collections.Generic;
using Cryptography.App.Models;
using Cryptography.Core.Services;

namespace Cryptography.App.ViewModels
{
    internal class KeysViewModel : BaseViewModel
    {
        public static List<string> EncryptionTypeLabels { get; } = new List<string>()
        {
            EncryptionType.AsymmetricEncryption,
            EncryptionType.SymmetricEncryption
        };

        #region Files
        private string _encryptionType;
        private string _generatedKeys;
        #endregion

        public KeysViewModel()
        {
            _encryptionType = string.Empty;
            _generatedKeys = string.Empty;

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
                    OnPropertyChanged(nameof(CanGenerateKeys));
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
        public bool CanGenerateKeys => !string.IsNullOrEmpty(SelectedEncryptionType);

        public ContentCopyViewModel ContentCopyVM { get; private set; }
        #endregion

        #region Commands
        public ICommand Generate { get; private set; }
        #endregion

        #region Methods
        public void GenerateKeys()
        {
            if (!CanGenerateKeys) return;
            if (SelectedEncryptionType == EncryptionType.SymmetricEncryption)
            {
                GeneratedKeys = EncryptionService.CreateSymmetricKey().ToString();
            }
            if(SelectedEncryptionType == EncryptionType.AsymmetricEncryption)
            {
                GeneratedKeys = EncryptionService.CreateAsymmetricKey().ToString();
            }
        }
        #endregion
    }
}
