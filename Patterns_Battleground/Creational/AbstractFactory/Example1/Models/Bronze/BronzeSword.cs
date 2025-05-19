using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Bronze
{
    public class BronzeSword : ISword
    {
        public void Slash()
        {
            Console.WriteLine("Bronze sword slashes with a dull edge.");
        }
    }
}
