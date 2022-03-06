using System.Windows;
using System.Windows.Controls;

namespace Cryptography.Views
{
    /// <summary>
    /// Interaction logic for ContentCopyView.xaml
    /// </summary>
    public partial class ContentCopyView : UserControl
    {
        private static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register("TextContent", typeof(string),
                        typeof(ContentCopyView));
        public string TextContent
        {
            get { return (string)GetValue(TextContentProperty); }
            set { SetValue(TextContentProperty, value); }
        }
        public ContentCopyView()
        {
            InitializeComponent();
        }
    }
}
