using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Iron
{
    public class IronSword : ISword
    {
        public void Slash()
        {
            Console.WriteLine("Iron sword cuts through with weight and force.");
        }
    }
}
