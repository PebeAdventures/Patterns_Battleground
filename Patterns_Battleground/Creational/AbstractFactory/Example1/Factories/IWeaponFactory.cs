using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1.Factories
{
    public interface IWeaponFactory
    {
        ISword CreateSword();
        IStaff CreateStaff();
        IKnife CreateKnife();
    }
}
