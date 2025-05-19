using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Steel
{
    public class SteelStaff : IStaff
    {
        public void Hit()
        {
            Console.WriteLine("Steel staff delivers a crushing blow with mechanical precision.");
        }
    }
}
