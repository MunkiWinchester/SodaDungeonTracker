using System;
using System.Windows.Media.Imaging;
using SodaDungeonTracker.Business;

namespace SodaDungeonTracker.DataObjects.Classes.Abstraction
{
    public abstract class BaseClass : IBaseClass
    {
        public string Name => GetType().Name;

        public BitmapImage Image =>
            new BitmapImage(new Uri($@"{FileHandler.GetBaseFolder()}\Resources\Icons\{GetType().Name}.png"));

        public abstract bool IsUnique { get; }

        public override string ToString()
        {
            return $"{Name}{(IsUnique ? " *" : "")}";
        }
    }
}