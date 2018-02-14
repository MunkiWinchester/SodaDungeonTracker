using SodaDungeonTracker.Business;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfUtility.Services;

namespace SodaDungeonTracker.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<DataObjects.Track> _tracks;

        public ObservableCollection<DataObjects.Track> Tracks
        {
            get => _tracks;
            set => SetField(ref _tracks, value);
        }

        public ICommand StartRunCommand => new DelegateCommand(StartRun);

        public ICommand EndRunCommand => new DelegateCommand(EndRun);

        private static void StartRun()
        {
            throw new System.NotImplementedException();
        }

        private static void EndRun()
        {
            throw new System.NotImplementedException();
        }

        public void Load()
        {
            //FileHandler.LoadCsv();
            var list = FileHandler.LoadPlaylistElements(
                $@"{FileHandler.GetBaseFolder()}\Resources\SodaDungeon.json");
            Tracks = new ObservableCollection<DataObjects.Track>(list);
        }
    }
}
