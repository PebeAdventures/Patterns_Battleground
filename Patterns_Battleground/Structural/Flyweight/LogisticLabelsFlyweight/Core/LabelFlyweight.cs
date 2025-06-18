using Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Domain;

namespace Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Core
{
    public record LabelFlyweight(string Name, string Icon, string Color) : ILabelFlyweight
    {
        
        public void Render(PackageContext context)
        {
            Console.WriteLine($"[Label] {Name} on package {context.PackageId} for {context.Destination}");
        }
    }
}
