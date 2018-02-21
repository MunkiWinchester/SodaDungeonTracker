using System.Windows;
using SodaDungeonTracker.DataObjects;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="System.Windows.Controls.UserControl" />
    /// <summary>
    /// Interaction logic for RecordDetailView.xaml
    /// </summary>
    public partial class RecordDetailView
    {
        public static readonly DependencyProperty RecordProperty = DependencyProperty.Register(
            nameof(Record), typeof(Record), typeof(RecordDetailView), new PropertyMetadata(default(Record)));

        public Record Record
        {
            get => (Record) GetValue(RecordProperty);
            set => SetValue(RecordProperty, value);
        }

        public RecordDetailView()
        {
            InitializeComponent();
        }
    }
}
