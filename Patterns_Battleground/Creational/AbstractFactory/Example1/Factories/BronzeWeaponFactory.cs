using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Bronze;
using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Factories
{
    public class BronzeWeaponFactory : IWeaponFactory
    {
        public IKnife CreateKnife() => new BronzeKnife();
        

        public IStaff CreateStaff() => new BronzeStaff();


        public ISword CreateSword() => new BronzeSword();

    }
}
