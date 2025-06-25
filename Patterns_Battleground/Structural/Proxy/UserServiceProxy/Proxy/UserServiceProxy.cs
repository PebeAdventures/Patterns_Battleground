using Patterns_Battleground.Creational.FactoryMethod.Example1.Models;
using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core;
using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Services;

namespace Patterns_Battleground.Structural.Proxy.UserServiceProxy.Proxy
{
    public class UserServiceProxy : IUserService
    {
        private readonly IUserService _userService;
        private readonly ITokenValidator _tokenValidator;

        public UserServiceProxy(IUserService userService, ITokenValidator tokenValidator)
        {
            _userService = userService;
            _tokenValidator = tokenValidator;
        }


        public UserProfile GetProfile(string userId, string token)
        {
            if (!_tokenValidator.IsAuthorized(userId, token))
            {
                throw new UnauthorizedAccessException("Invalid token or unauthorized access.");
            }

            return _userService.GetProfile(userId, token);
        }
    }
}
