using Samples.AspNetCore.Server.Data.Contracts.Dto;
using Samples.AspNetCore.Server.Data.Contracts.Providers;

namespace Samples.AspNetCore.Server.Data.Fake.Providers
{
    internal sealed class FakeLoginProvider : ILoginProvider
    {
        public UserDto GetUser(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}