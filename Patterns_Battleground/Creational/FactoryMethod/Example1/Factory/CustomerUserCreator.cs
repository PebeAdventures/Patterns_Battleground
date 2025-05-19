using Patterns_Battleground.Creational.FactoryMethod.Example1.Models;

namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Factory
{
    public class CustomerUserCreator : UserCreator
    {
        public override IUser CreateUser()
        {
            return new CustomerUser();
        }
    }
}
