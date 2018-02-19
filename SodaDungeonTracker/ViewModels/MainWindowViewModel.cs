using System.Collections.ObjectModel;
using System.Linq;
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
        private bool _isRunOpen;

        public ObservableCollection<Track> Tracks
        {
            get => _tracks;
            set => SetField(ref _tracks, value);
        }

        public bool IsRunOpen
        {
            get => _isRunOpen;
            set
            {
                _isRunOpen = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartRunCommand => new RelayCommand<MainWindow>(StartRun);

        public ICommand EndRunCommand => new RelayCommand<MainWindow>(EndRun);

        private void StartRun(MainWindow mainWindow)
        {
            var dialog = new StartEndRunDialog {Owner = mainWindow, Title = "Start new Run"};
            if (dialog.ShowDialog() == true)
            {

                var track = dialog.Track;

                if (dialog.AssignedClasses.Count > 0)
                    track.Setup.Class1 = dialog.AssignedClasses[0];
                if (dialog.AssignedClasses.Count > 1)
                    track.Setup.Class2 = dialog.AssignedClasses[1];
                if (dialog.AssignedClasses.Count > 2)
                    track.Setup.Class3 = dialog.AssignedClasses[2];
                if (dialog.AssignedClasses.Count > 3)
                    track.Setup.Class4 = dialog.AssignedClasses[3];
                if (dialog.AssignedClasses.Count > 4)
                    track.Setup.Class5 = dialog.AssignedClasses[4];

                track.Id = _tracks.Max(t => t.Id) + 1;

                Tracks.Add(track);
                IsRunOpen = true;
            }
        }

        private void EndRun(MainWindow mainWindow)
        {
            // TODO: Edit THIES
            //var dialog = new StartEndRunDialog { Owner = mainWindow, Title = "End current Run"};
            //dialog.ShowDialog();
            IsRunOpen = false;
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