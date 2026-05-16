using BlueAtelier.Application;
using BlueAtelier.Domain;
using BlueAtelier.Infrastructure;
using BlueAtelier.Persistence;

namespace BlueAtelier.Tests;

public sealed class SolutionStructureTests
{
    [Fact]
    public void LayerAssemblyReferences_ShouldBeAvailable()
    {
        Assert.Equal("BlueAtelier.Domain", typeof(DomainAssemblyReference).Namespace);
        Assert.Equal("BlueAtelier.Application", typeof(ApplicationAssemblyReference).Namespace);
        Assert.Equal("BlueAtelier.Infrastructure", typeof(InfrastructureAssemblyReference).Namespace);
        Assert.Equal("BlueAtelier.Persistence", typeof(PersistenceAssemblyReference).Namespace);
    }
}
