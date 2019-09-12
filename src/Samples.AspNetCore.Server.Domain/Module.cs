using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Samples.AspNetCore.Server.Domain.Services;
using Solid.Practices.Modularity;

namespace Samples.AspNetCore.Server.Domain
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<IUsersService, UsersService>();
        }
    }
}
