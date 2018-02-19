using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace SodaDungeonTracker.DataObjects.Classes.Abstraction
{
    public interface IBaseClass
    {
        string Name { get; }

        [JsonIgnore] BitmapImage Image { get; }

        bool IsUnique { get; }
    }
}