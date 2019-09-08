using Samples.AspNetCore.Server.Data.Contracts.Dto;

namespace Samples.AspNetCore.Server.Data.Contracts.Providers
{
    public interface ILoginProvider
    {
        UserDto GetUser(string username, string password);
    }
}