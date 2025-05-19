using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Iron
{
    public class IronKnife : IKnife
    {
        public void Stab()
        {
            Console.WriteLine("Iron knife pierces armor with a harsh crunch.");
        }
    }
}
