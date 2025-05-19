using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Bronze
{
    public class BronzeStaff : IStaff
    {
        public void Hit()
        {
            Console.WriteLine("Bronze staff thuds against the target with a hollow sound.");
        }
    }
}
