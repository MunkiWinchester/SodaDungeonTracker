namespace SodaDungeonTracker.DataObjects.Classes
{
    public class Shifter : Abstraction.BaseClass
    {
        public Abstraction.BaseClass Class1 { get; set; }
        public Abstraction.BaseClass Class2 { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Class1} / {Class2})";
        }
    }
}