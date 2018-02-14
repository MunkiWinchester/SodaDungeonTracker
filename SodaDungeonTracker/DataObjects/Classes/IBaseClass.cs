using Newtonsoft.Json;
using System.Windows.Media.Imaging;

namespace SodaDungeonTracker.DataObjects.Classes
{
    public interface IBaseClass
    {
        string Name { get; }
        [JsonIgnore]
        BitmapImage Image { get; }
    }
}