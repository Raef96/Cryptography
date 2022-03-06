using System.Windows;
using System.Windows.Input;

namespace Cryptography.ViewModels
{
    internal class ContentCopyViewModel : BaseViewModel
    {
        private string _textContent;
        private bool _copyButtonIsEnabled;

        public ContentCopyViewModel()
        {
            _textContent = string.Empty;
            _copyButtonIsEnabled = false;

            CopyToClipboardCommand = new RelayCommand(CopyToClipboard, () => true);
        }

        #region Properties
        public string TextContent
        {
            get { return _textContent; }
            set
            {
                if (_textContent != value)
                {
                    _textContent = value;
                    CopyButtonIsEnabled = true;
                    OnPropertyChanged(nameof(TextContent));
                }
            }
        }
        public bool CopyButtonIsEnabled
        {
            get { return _copyButtonIsEnabled; }
            set
            {
                if (_copyButtonIsEnabled != value)
                {
                    _copyButtonIsEnabled = value;
                    OnPropertyChanged(nameof(CopyButtonIsEnabled));
                }
            }
        }
        #endregion

        public ICommand CopyToClipboardCommand { get; set; }

        public void CopyToClipboard()
        {
            Clipboard.SetText(TextContent);
        }
    }
}
