namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components
{
    public class Software
    {

        public string Name { get; }
        public string Version { get; }

        public Software(string name, string version)
        {
            Name = name;
            Version = version;
        }

        public Software Clone() => new Software(Name, Version);
    }
}
