using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using SodaDungeonTracker.DataObjects;
using SodaDungeonTracker.DataObjects.Classes;
using SodaDungeonTracker.DataObjects.Classes.Abstraction;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="UserControl" />
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
            set
            {
                SetValue(ShifterProperty, value); 
                if(value != null)
                    SetShifterSubclasses();
            }
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

        private void SetShifterSubclasses()
        {
            foreach (var radioButton in FindVisualChildren<RadioButton>((Panel)this.Content))
            {
                if (radioButton.Name.Contains("Class1"))
                {
                    if (radioButton.Tag.Equals(Shifter.Class1))
                        radioButton.IsChecked = true;
                }
                else if (radioButton.Tag.Equals(Shifter.Class2))
                    radioButton.IsChecked = true;
                else
                    radioButton.IsChecked = false;
            }

            for (var i = 0; i < _listBoxAvailableClasses.Items.Count; i++)
            {
                var obj = _listBoxAvailableClasses.ItemContainerGenerator.ContainerFromIndex(i);
                var radioButton = FindVisualChild<RadioButton>(obj);
                if (radioButton.Name.Contains("Class1"))
                {
                    if (radioButton.Tag.Equals(Shifter.Class1))
                        radioButton.IsChecked = true;
                }
                else if (radioButton.Tag.Equals(Shifter.Class2))
                    radioButton.IsChecked = true;
                else
                    radioButton.IsChecked = false;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            var list = new List<T>();
            if (depObj != null)
            {
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T variable)
                    {
                        list.Add(variable);
                    }

                    list.AddRange(FindVisualChildren<T>(child));
                }
            }

            return list;
        }

        public static TChildItem FindVisualChild<TChildItem>(DependencyObject obj)
            where TChildItem : DependencyObject
        {
            // Search immediate children
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child is TChildItem)
                    return (TChildItem)child;

                else
                {
                    TChildItem childOfChild = FindVisualChild<TChildItem>(child);

                    if (childOfChild != null)
                        return childOfChild;
                }
            }

            return null;
        }
    }
}
