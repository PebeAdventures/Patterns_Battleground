using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core;

namespace Patterns_Battleground.Structural.Proxy.UserServiceProxy.Services
{
    public class RealUserService : IUserService
    {
        public UserProfile GetProfile(string userId, string token)
        {
            var adminRoleList = new [] { "admin", "superAdmin" };
            if (userId == "admin") return new UserProfile("admin", " admin", "admin", adminRoleList);
            var user = PrepareUser(userId);
            return user;
        }

        private UserProfile PrepareUser(string userId)
        {
            var userRoleList = new[] { "user", "readUser" };
            return new UserProfile(userId, "user", "user@user.com", userRoleList);
        }
    }
}
