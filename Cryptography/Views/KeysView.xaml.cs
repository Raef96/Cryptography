using System.Windows.Controls;
using static Cryptography.ViewModels.KeysViewModel;

namespace Cryptography.Views
{
    /// <summary>
    /// Interaction logic for KeysView.xaml
    /// </summary>
    public partial class KeysView : UserControl
    {
        public KeysView()
        {
            InitializeComponent();
            Combo.ItemsSource = EncryptionTypeLabels;
        }
    }
}
