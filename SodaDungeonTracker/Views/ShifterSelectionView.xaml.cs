using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using SodaDungeonTracker.DataObjects.Classes;
using SodaDungeonTracker.DataObjects.Classes.Abstraction;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="System.Windows.Controls.UserControl" />
    /// <summary>
    /// Interaction logic for ShifterSelectionView.xaml
    /// </summary>
    public partial class ShifterSelectionView
    {
        public static readonly DependencyProperty ShifterProperty = DependencyProperty.Register(
            nameof(Shifter), typeof(Shifter), typeof(ShifterSelectionView), new PropertyMetadata(default(Shifter)));

        public Shifter Shifter
        {
            get => (Shifter) GetValue(ShifterProperty);
            set => SetValue(ShifterProperty, value);
        }

        public static readonly DependencyProperty ClassesProperty = DependencyProperty.Register(
            nameof(Classes), typeof(ObservableCollection<BaseClass>), typeof(ShifterSelectionView), new PropertyMetadata(default(ObservableCollection<BaseClass>)));

        public ObservableCollection<BaseClass> Classes
        {
            get => (ObservableCollection<BaseClass>) GetValue(ClassesProperty);
            set => SetValue(ClassesProperty, value);
        }

        public ShifterSelectionView()
        {
            InitializeComponent();
            if(Shifter == null)
                Shifter = new Shifter();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (radioButton.Tag is BaseClass baseClass)
                {
                    if (radioButton.Name.Contains("Class1"))
                        Shifter.Class1 = baseClass;
                    else
                        Shifter.Class2 = baseClass;
                }
            }
        }
    }
}
