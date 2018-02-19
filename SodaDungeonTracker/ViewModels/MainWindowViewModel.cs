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
        private ObservableCollection<Record> _records;

        public ObservableCollection<Record> Records
        {
            get => _records;
            set => SetField(ref _records, value);
        }

        private Record _selectedRecord;

        public Record SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                OnPropertyChanged();
                _selectedRecord = value;
            }
        }

        public ICommand AddRecordCommand =>
            new DelegateCommand(() =>
            {
                var record = new Record {Id = _records.Max(t => t.Id) + 1};
                Records.Add(record);
                SelectedRecord = record;
            });

        public ICommand EditRecordCommand => new RelayCommand<MainWindow>(EditRecord);

        private void EditRecord(MainWindow mainWindow)
        {
            var dialog = new EditRecordDialog {Owner = mainWindow, Record = SelectedRecord};
            if (dialog.ShowDialog() == true)
            {
                SelectedRecord = dialog.Record;
                Records = new ObservableCollection<Record>(_records);
            }
        }

        public void Load()
        {
            //FileHandler.LoadCsv();
            var list = FileHandler.LoadPlaylistElements(
                $@"{FileHandler.GetBaseFolder()}\Resources\SodaDungeon.json");
            Records = new ObservableCollection<Record>(list);
        }
    }
}