namespace Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core
{
    public class TokenValidator : ITokenValidator
    {
        // for testing purposes, token will be valid only for value "12345"
        public bool IsAuthorized(string userId, string token)
        {
            return token == "12345";
        }
    }
}
