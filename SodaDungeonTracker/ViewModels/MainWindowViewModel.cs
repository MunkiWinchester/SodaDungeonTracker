using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SodaDungeonTracker.Business;
using SodaDungeonTracker.DataObjects;
using SodaDungeonTracker.Views;
using WpfUtility.Services;

namespace SodaDungeonTracker.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<Track> _tracks;

        public ObservableCollection<Track> Tracks
        {
            get => _tracks;
            set => SetField(ref _tracks, value);
        }

        public ICommand StartRunCommand => new RelayCommand<MainWindow>(StartRun);

        public ICommand EndRunCommand => new RelayCommand<MainWindow>(EndRun);

        private static void StartRun(MainWindow mainWindow)
        {
            var dialog = new StartEndRunDialog {Owner = mainWindow, Title = "Start new Run"};
            dialog.ShowDialog();
        }

        private static void EndRun(MainWindow mainWindow)
        {
            var dialog = new StartEndRunDialog { Owner = mainWindow, Title = "End current Run"};
            dialog.ShowDialog();
        }

        public void Load()
        {
            //FileHandler.LoadCsv();
            var list = FileHandler.LoadPlaylistElements(
                $@"{FileHandler.GetBaseFolder()}\Resources\SodaDungeon.json");
            Tracks = new ObservableCollection<Track>(list);
        }
    }
}