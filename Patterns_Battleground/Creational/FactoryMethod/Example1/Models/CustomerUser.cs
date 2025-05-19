namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Models;

public class CustomerUser : IUser
{


    public string GetAccessLevel()
    {
        return "Customer";
    }
}
