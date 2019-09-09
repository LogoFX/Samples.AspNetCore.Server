using Microsoft.Extensions.DependencyInjection;
using Samples.AspNetCore.Server.Data.Contracts.Providers;
using Samples.AspNetCore.Server.Infra;
using Solid.Practices.Modularity;

namespace Samples.AspNetCore.Server.Data.Fake.Providers
{
    public sealed class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<ILoginProvider, FakeLoginProvider>()
                .AddSingleton<IUsersProvider, FakeUsersProvider>()
                .AddSingleton<IRestClientData, RestClientData>();
        }

    }
}