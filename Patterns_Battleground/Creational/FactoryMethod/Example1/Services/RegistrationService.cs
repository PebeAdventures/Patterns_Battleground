using Patterns_Battleground.Creational.FactoryMethod.Example1.Factory;
using Patterns_Battleground.Creational.FactoryMethod.Example1.Models;

namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Services;

public class RegistrationService
{
    private readonly UserCreator userCreator;

    public RegistrationService(UserCreator userCreator)
    {
        this.userCreator = userCreator;
    }

    public IUser RegisterUser(string role)
    {
        var userCreator = this.GetUserCreator(role);
        var user = userCreator.CreateUser();
        return user;
    }

    private UserCreator GetUserCreator(string role)
    {
        return role.ToLower() switch
        {
            "admin" => new AdminUserCreator(),
            "customer" => new CustomerUserCreator(),
            _ => throw new ArgumentException($"Unknown role: {role}")
        };
    }
}
