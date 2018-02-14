using SodaDungeonTracker.DataObjects.Classes.Abstraction;

namespace SodaDungeonTracker.DataObjects.Classes
{
    public class Shifter : BaseClass
    {
        public BaseClass Class1 { get; set; }
        public BaseClass Class2 { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Class1} / {Class2})";
        }
    }
}