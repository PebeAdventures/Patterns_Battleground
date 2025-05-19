using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Steel
{
    public class SteelKnife : IKnife
    {
        public void Stab()
        {
            Console.WriteLine("Steel knife strikes fast and true with deadly precision.");
        }
    }
}
