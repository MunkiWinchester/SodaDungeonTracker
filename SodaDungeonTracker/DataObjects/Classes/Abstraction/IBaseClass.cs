using Newtonsoft.Json;
using System.Windows.Media.Imaging;

namespace SodaDungeonTracker.DataObjects.Classes.Abstraction
{
    public interface IBaseClass
    {
        string Name { get; }
        [JsonIgnore]
        BitmapImage Image { get; }
    }
}