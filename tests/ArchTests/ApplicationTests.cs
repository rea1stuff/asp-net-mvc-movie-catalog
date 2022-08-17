using MovieCatalog.Application.Users;
using NetArchTest.Rules;

namespace ArchTests;

public class ApplicationTests
{
    [Fact]
    public void ApplicationShouldNotHaveDependencyOnInfrastructure()
    {
        var result = Types.InAssembly(typeof(UserService).Assembly)
            .ShouldNot()
            .HaveDependencyOn("MovieCatalog.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}