using System.Windows;
using System.Windows.Controls;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="MahApps.Metro.Controls.MetroWindow" />
    /// <summary>
    /// Interaction logic for StartEndRunDialog.xaml
    /// </summary>
    public partial class StartEndRunDialog
    {
        public StartEndRunDialog()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Equals(ButtonSave))
                DialogResult = true;
        }
    }
}
