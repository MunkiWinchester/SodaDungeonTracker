using SodaDungeonTracker.ViewModels;
using System.Windows;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="MahApps.Metro.Controls.MetroWindow" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel dataContext)
                dataContext.Load();
        }
    }
}
