using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SodaDungeonTracker.ViewModels;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="MahApps.Metro.Controls.MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
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

        private void ButtonDetails_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // the original source is what was clicked.  For example 
                // a button.
                var dep = (DependencyObject) e.OriginalSource;

                // iteratively traverse the visual tree upwards looking for
                // the clicked row.
                while (dep != null && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                // if we found the clicked row, get the row
                // ReSharper disable once IsExpressionAlwaysTrue
                if (dep is DataGridRow gridRow)
                    // change the details visibility
                    gridRow.DetailsVisibility = gridRow.DetailsVisibility == Visibility.Collapsed
                        ? Visibility.Visible
                        : Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}