using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.AspNetCore.Server.Data.Contracts.Dto;

namespace Samples.AspNetCore.Server.Data.Contracts.Providers
{
    public interface IUsersProvider
    {
         Task<IEnumerable<UserDto>> GetUsersAsync();

         Task<UserDto> AddUserAsync(string username, string fullname);

         Task<bool> RemoveUserAsync(UserDto user);

         Task<UserDto> UpdateUserAsync(UserDto user, string fullname);
    }
}