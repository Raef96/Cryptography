using System.Windows;
using System.Windows.Input;

namespace Cryptography.App.ViewModels
{
    internal class ContentCopyViewModel : BaseViewModel
    {
        private string _textContent;

        public ContentCopyViewModel()
        {
            _textContent = string.Empty;

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
                    OnPropertyChanged(nameof(CanCopy));
                    OnPropertyChanged(nameof(TextContent));
                }
            }
        }
        public bool CanCopy => ! string.IsNullOrEmpty(TextContent);
        #endregion

        public ICommand CopyToClipboardCommand { get; set; }

        public void CopyToClipboard()
        {
            Clipboard.SetText(TextContent);
        }
    }
}
