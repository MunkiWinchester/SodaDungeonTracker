using SodaDungeonTracker.Business;
using System.Collections.ObjectModel;
using WpfUtility.Services;

namespace SodaDungeonTracker.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<DataObjects.Track> _tracks;

        public ObservableCollection<DataObjects.Track> Tracks
        {
            get => _tracks;
            set
            {
                _tracks = value;
                SetField(ref _tracks, value);
            }
        }

        public void Load()
        {
            //FileHandler.LoadCsv();
            var list = FileHandler.LoadPlaylistElements(
                $@"{FileHandler.GetBaseFolder()}\Resources\SodaDungeonV1.json");
            Tracks = new ObservableCollection<DataObjects.Track>(list);
        }
    }
}
