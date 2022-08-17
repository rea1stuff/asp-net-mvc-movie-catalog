using MovieCatalog.Domain.Entities;
using NetArchTest.Rules;

namespace ArchTests;

public class DomainTests
{
    [Fact]
    public void DomainShouldNotHaveDependencyOnApplication()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly)
            .ShouldNot()
            .HaveDependencyOn("MovieCatalog.Application")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void DomainShouldNotHaveDependencyOnInfrastructure()
    {
        var result = Types.InAssembly(typeof(BaseEntity).Assembly)
            .ShouldNot()
            .HaveDependencyOn("MovieCatalog.Infrastructure")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}