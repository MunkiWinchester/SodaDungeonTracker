using SodaDungeonTracker.Business;
using System;
using System.Windows.Media.Imaging;

namespace SodaDungeonTracker.DataObjects.Classes.Abstraction
{
    public abstract class BaseClass : IBaseClass
    {
        public string Name => GetType().Name;

        public BitmapImage Image => new BitmapImage(new Uri($@"{FileHandler.GetBaseFolder()}\Resources\Icons\{Name}.png"));

        public override string ToString() => Name;
    }
}
