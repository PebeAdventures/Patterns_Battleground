using Patterns_Battleground.Creational.FactoryMethod.Example1.Models;

namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Factory
{
    public abstract class UserCreator
    {
        public  abstract IUser CreateUser();

        public string ProvideAccesibilityInformation()
        {
            var user = CreateUser();
            var accesibilityInformation = "User accesibility Level: " + user.GetAccessLevel();
            return accesibilityInformation;
        }
    }
}
