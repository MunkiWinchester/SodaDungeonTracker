namespace SodaDungeonTracker.Classes
{
    public class Shifter : IBaseClass
    {
        public string Name => GetType().Name;
        public IBaseClass Class1 { get; set; }
        public IBaseClass Class2 { get; set; }
    }
}