using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Iron
{
    public class IronStaff : IStaff
    {
        public void Hit()
        {
            Console.WriteLine("Iron staff slams down with a solid metallic impact.");
        }
    }
}
