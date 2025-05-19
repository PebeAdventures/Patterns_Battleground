using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Bronze
{
    public class BronzeKnife : IKnife
    {
        public void Stab()
        {
            Console.WriteLine("Bronze knife delivers a quick stab, but lacks finesse.");
        }
    }
}
