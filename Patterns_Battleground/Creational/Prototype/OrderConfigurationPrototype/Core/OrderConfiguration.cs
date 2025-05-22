using Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Components;

namespace Patterns_Battleground.Creational.Prototype.OrderConfigurationPrototype.Core
{
    public class OrderConfiguration : IPrototype<OrderConfiguration>
    {
        public string Name { get; }
        public List<HardwareComponent> HardwareComponents { get; }
        public List<Software> SoftwarePackages { get; }

        public OrderConfiguration(string name, List<HardwareComponent> hardwareComponents, List<Software> softwarePackages)
        {
            Name = name;
            HardwareComponents = hardwareComponents;
            SoftwarePackages = softwarePackages;
        }

        public virtual OrderConfiguration Clone()
        {
            return new OrderConfiguration(
                Name,
                HardwareComponents.Select(c => c.Clone()).ToList(),
                SoftwarePackages.Select(sp => sp.Clone()).ToList());
        }

        /// <summary>
        /// Creates a clone of the current object and safely casts it to the specified derived type.
        /// </summary>
        /// <typeparam name="T">Derived type of <see cref="OrderConfiguration"/> to cast the clone to.</typeparam>
        /// <returns>Cloned instance as type <typeparamref name="T"/>.</returns>
        /// <remarks>
        /// Useful when working with base class references and needing access to derived-type properties without manual casting.
        /// </remarks>
        public T CloneAs<T>() where T : OrderConfiguration
        {
            return (T)Clone();
        }
    }
}
