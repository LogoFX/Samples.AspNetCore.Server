using LogoFX.Server.Bootstrapping;
using Microsoft.Extensions.DependencyInjection;
using Solid.Practices.Composition;

namespace Samples.AspNetCore.Server.Facade
{
    internal sealed class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper(IServiceCollection dependencyRegistrator) 
            : base(dependencyRegistrator)
        {
        }

        public override CompositionOptions CompositionOptions => new CompositionOptions
        {
            Prefixes = new[]
            {
                "Samples.AspNetCore.Server.Facade", "Samples.AspNetCore.Server.Api", "Samples.AspNetCore.Server.Domain"
            }
        };
    }
}