using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;
using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Iron;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Factories
{
    public class IronWeaponFactory : IWeaponFactory
    {
        public IKnife CreateKnife() => new IronKnife();

        public IStaff CreateStaff() => new IronStaff();

        public ISword CreateSword() => new IronSword();
    }
}
