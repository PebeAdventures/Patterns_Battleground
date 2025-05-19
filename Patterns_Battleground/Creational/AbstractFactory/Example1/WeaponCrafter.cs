using Patterns_Battleground.Creational.AbstractFactory.Example1.Factories;
using Patterns_Battleground.Creational.AbstractFactory.Example1.Models.Interfaces;

namespace Patterns_Battleground.Creational.AbstractFactory.Example1
{
    public class WeaponCrafter
    {
        private readonly ISword sword;
        private readonly IStaff staff;
        private readonly IKnife knife;

        public WeaponCrafter(IWeaponFactory weaponFactory)
        {
            this.sword = weaponFactory.CreateSword();
            this.staff = weaponFactory.CreateStaff();
            this.knife = weaponFactory.CreateKnife();
        }

        public void DemonstrateWeapon()
        {
            sword.Slash();
            staff.Hit();
            knife.Stab();
        }
    }
}
