using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SodaDungeonTracker.Business;
using SodaDungeonTracker.DataObjects;
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

        public ICommand StartRunCommand => new DelegateCommand(StartRun);

        public ICommand EndRunCommand => new DelegateCommand(EndRun);

        private static void StartRun()
        {
            throw new NotImplementedException();
        }

        private static void EndRun()
        {
            throw new NotImplementedException();
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