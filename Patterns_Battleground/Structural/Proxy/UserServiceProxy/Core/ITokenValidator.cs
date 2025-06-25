namespace Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core
{
    public interface ITokenValidator
    {

        bool IsAuthorized(string userId, string token);
    }
}