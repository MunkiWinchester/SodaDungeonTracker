using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SodaDungeonTracker.DataObjects.Classes;
using SodaDungeonTracker.DataObjects.Classes.Abstraction;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="System.Windows.Controls.UserControl" />
    /// <summary>
    /// Interaction logic for BaseClassView.xaml
    /// </summary>
    public partial class BaseClassView
    {
        public static readonly DependencyProperty BaseClassProperty = DependencyProperty.Register(
            nameof(BaseClass), typeof(BaseClass), typeof(BaseClassView), new PropertyMetadata(default(BaseClass)));

        public BaseClass BaseClass
        {
            get => (BaseClass) GetValue(BaseClassProperty);
            set => SetValue(BaseClassProperty, value);
        }

        public static readonly DependencyProperty ShowShifterSelectionProperty = DependencyProperty.Register(
            nameof(ShowShifterSelection), typeof(bool), typeof(BaseClassView), new PropertyMetadata(default(bool)));

        public bool ShowShifterSelection
        {
            get => (bool) GetValue(ShowShifterSelectionProperty);
            set => SetValue(ShowShifterSelectionProperty, value);
        }

        public static readonly DependencyProperty ShowShifterSelectionInternalProperty = DependencyProperty.Register(
            nameof(ShowShifterSelectionInternal), typeof(bool), typeof(BaseClassView), new PropertyMetadata(default(bool)));

        public bool ShowShifterSelectionInternal
        {
            get => (bool) GetValue(ShowShifterSelectionInternalProperty);
            set => SetValue(ShowShifterSelectionInternalProperty, value);
        }

        public static readonly DependencyProperty AvailableClassesProperty = DependencyProperty.Register(
            nameof(AvailableClasses), typeof(ObservableCollection<BaseClass>), typeof(BaseClassView), new PropertyMetadata(default(ObservableCollection<BaseClass>)));

        public ObservableCollection<BaseClass> AvailableClasses
        {
            get => (ObservableCollection<BaseClass>) GetValue(AvailableClassesProperty);
            set => SetValue(AvailableClassesProperty, value);
        }

        public BaseClassView()
        {
            InitializeComponent();
            AvailableClasses = new ObservableCollection<BaseClass>();
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (BaseClass is Shifter shifter && ShowShifterSelection)
            {
                ShowShifterSelectionInternal = !ShowShifterSelectionInternal;

                if (!AvailableClasses.Any())
                {
                    var type = typeof(IBaseClass);
                    var classes = AppDomain.CurrentDomain.GetAssemblies()
                        .SelectMany(s => s.GetTypes())
                        .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface && p != typeof(Shifter))
                        .Select(x => (BaseClass) Activator.CreateInstance(x)).OrderBy(s => s.Name).ToList();
                    AvailableClasses = new ObservableCollection<BaseClass>(classes);
                }
            }
        }
    }
}
