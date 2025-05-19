namespace Patterns_Battleground.Creational.FactoryMethod.Example1.Models
{
    public class AdminUser : IUser
    {

        public string GetAccessLevel()
        {
            return "Admin";
        }
    }
}
