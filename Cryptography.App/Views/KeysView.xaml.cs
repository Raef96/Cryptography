using System.Windows.Controls;
using static Cryptography.App.ViewModels.KeysViewModel;

namespace Cryptography.App.Views
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
