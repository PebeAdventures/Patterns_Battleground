using Patterns_Battleground.Creational.FactoryMethod.Example1.Models;

namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Factory
{
    public class AdminUserCreator : UserCreator
    {
        public override IUser CreateUser()
        {
            return new AdminUser();
        }
    }
}
