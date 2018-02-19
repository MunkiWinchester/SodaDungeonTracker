using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using SodaDungeonTracker.DataObjects;
using SodaDungeonTracker.DataObjects.Classes.Abstraction;

namespace SodaDungeonTracker.Views
{
    /// <inheritdoc cref="MahApps.Metro.Controls.MetroWindow" />
    /// <summary>
    /// Interaction logic for EditRecordDialog.xaml
    /// </summary>
    public partial class EditRecordDialog
    {
        public static readonly DependencyProperty AvailableClassesProperty = DependencyProperty.Register(
            nameof(AvailableClasses), typeof(ObservableCollection<BaseClass>), typeof(EditRecordDialog), new PropertyMetadata(default(ObservableCollection<BaseClass>)));

        public ObservableCollection<BaseClass> AvailableClasses
        {
            get => (ObservableCollection<BaseClass>) GetValue(AvailableClassesProperty);
            set => SetValue(AvailableClassesProperty, value);
        }

        public static readonly DependencyProperty AssignedClassesProperty = DependencyProperty.Register(
            nameof(AssignedClasses), typeof(ObservableCollection<BaseClass>), typeof(EditRecordDialog), new PropertyMetadata(default(ObservableCollection<BaseClass>)));

        public ObservableCollection<BaseClass> AssignedClasses
        {
            get => (ObservableCollection<BaseClass>) GetValue(AssignedClassesProperty);
            set => SetValue(AssignedClassesProperty, value);
        }

        public static readonly DependencyProperty SelectedClassProperty = DependencyProperty.Register(
            nameof(SelectedClass), typeof(BaseClass), typeof(EditRecordDialog), new PropertyMetadata(default(BaseClass)));

        public BaseClass SelectedClass
        {
            get => (BaseClass) GetValue(SelectedClassProperty);
            set => SetValue(SelectedClassProperty, value);
        }

        public static readonly DependencyProperty RecordProperty = DependencyProperty.Register(
            nameof(Record), typeof(Record), typeof(EditRecordDialog), new PropertyMetadata(default(Record)));

        public Record Record
        {
            get => (Record) GetValue(RecordProperty);
            set => SetValue(RecordProperty, value);
        }

        public EditRecordDialog()
        {
            Record = new Record();
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Equals(_buttonSave))
                DialogResult = true;
        }

        private void EditRecordDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            var type = typeof(IBaseClass);
            var classes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
                .Select(x => (BaseClass) Activator.CreateInstance(x)).OrderBy(s => s.Name).ToList();
            AvailableClasses = new ObservableCollection<BaseClass>(classes);
            AssignedClasses = new ObservableCollection<BaseClass>();
        }

        private void ButtonMoveAction_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Equals(_buttonMoveToAssigned))
                {
                    if (_listBoxAvailableClasses.SelectedItem is BaseClass item && AssignedClasses.Count < 5 &&
                        (!item.IsUnique || item.IsUnique && !AssignedClasses.Any(c => c.IsUnique)))
                    {
                        AssignedClasses.Add(item);
                    }
                    else
                        this.ShowMessageAsync("Party limit reached!",
                            @"You can only assign five people to your party and only one of them can be unique!");
                }
                if (button.Equals(_buttonMoveToAvailable))
                {
                    var item = _listBoxAssignedClasses.SelectedItem as BaseClass;
                    AssignedClasses.Remove(item);
                }
            }
        }
    }
}
