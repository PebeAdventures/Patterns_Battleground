namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components
{
    public class HardwareComponent
    {
        public string Name { get; }
        public string Value { get; }

        public HardwareComponent(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public HardwareComponent Clone() => new HardwareComponent(Name, Value);
    }
}
