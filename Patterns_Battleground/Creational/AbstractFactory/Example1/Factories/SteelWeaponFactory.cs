using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;
using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Steel;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Factories
{
    public class SteelWeaponFactory : IWeaponFactory
    {
        public IKnife CreateKnife() => new SteelKnife();

        public IStaff CreateStaff() => new SteelStaff();

        public ISword CreateSword() => new SteelSword();
    }
}
