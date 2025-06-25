using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core;

namespace Patterns_Battleground.Structural.Proxy.UserServiceProxy.Services
{
    public interface IUserService
    {
        UserProfile GetProfile(string userId, string token);
    }
}
