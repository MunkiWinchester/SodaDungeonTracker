using SodaDungeonTracker.Business;
using System.Windows.Media.Imaging;

namespace SodaDungeonTracker.DataObjects.Classes
{
    public class Conscript : IBaseClass
    {
        public string Name => GetType().Name;
        public BitmapImage Image => new BitmapImage(new System.Uri($@"{FileHandler.GetBaseFolder()}\Resources\Icons\{Name}.png"));
    }
}