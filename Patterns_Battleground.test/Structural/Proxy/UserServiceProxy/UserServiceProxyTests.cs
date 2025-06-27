using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Core;
using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Proxy;
using Patterns_Battleground.Structural.Proxy.UserServiceProxy.Services;

namespace Patterns_Battleground.test.Structural.Proxy.UserServiceProxy;

public class UserServiceProxyTests
{

    [Fact]
    public void GetProfile_WhenTokenIsValid_ShouldReturnExpectedUserProfile()
    {
        //Arrange
        var userService = new RealUserService();
        var tokenValidator = new TokenValidator();
        var proxyUserService = new AuthorizedUserServiceProxy(userService, tokenValidator);
        var correctToken = "12345";
        var expectedUser = new UserProfile("userId", "user", "user@user.com", ["user", "readUser"]);

        //Act
        var autorizedUserProfile = proxyUserService.GetProfile("userId", correctToken);

        //Assert
        Assert.Equal(expectedUser.UserId, autorizedUserProfile.UserId);
        Assert.Equal(expectedUser.Name, autorizedUserProfile.Name);
        Assert.Equal(expectedUser.Email, autorizedUserProfile.Email);
        Assert.True(expectedUser.Roles.SequenceEqual(autorizedUserProfile.Roles));
    }

    [Fact]
    public void GetProfile_WhenTokenIsInValid_ShouldThrowUnauthorizedException()
    {
        //Arrange
        var userService = new RealUserService();
        var tokenValidator = new TokenValidator();
        var proxyUserService = new AuthorizedUserServiceProxy(userService, tokenValidator);
        var incorrectToken = "abc";

        //Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => proxyUserService.GetProfile("userId", incorrectToken));
    }
    [Fact]
    public void GetProfile_WhenTokenIsNull_ShouldThrowUnauthorizedException()
    {
        //Arrange
        var userService = new RealUserService();
        var tokenValidator = new TokenValidator();
        var proxyUserService = new AuthorizedUserServiceProxy(userService, tokenValidator);
        string incorrectToken = null;

        //Act & Assert
        Assert.Throws<UnauthorizedAccessException>(() => proxyUserService.GetProfile("userId", incorrectToken));
    }
}
