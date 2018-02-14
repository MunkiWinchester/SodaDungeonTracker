using SodaDungeonTracker.Business;
using System.Windows.Media.Imaging;

namespace SodaDungeonTracker.DataObjects.Classes
{
    public class Shifter : IBaseClass
    {
        public string Name => GetType().Name;
        public BitmapImage Image => new BitmapImage(new System.Uri($@"{FileHandler.GetBaseFolder()}\Resources\Icons\{Name}"));
        public IBaseClass Class1 { get; set; }
        public IBaseClass Class2 { get; set; }
    }
}