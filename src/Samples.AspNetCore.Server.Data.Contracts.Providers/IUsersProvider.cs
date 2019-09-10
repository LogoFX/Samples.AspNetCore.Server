using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.AspNetCore.Server.Data.Contracts.Dto;

namespace Samples.AspNetCore.Server.Data.Contracts.Providers
{
    public interface IUsersProvider
    {
         Task<IEnumerable<UserDto>> GetUsersAsync();

         Task<UserDto> GetUserByName(string username);

         Task<UserDto> GetUserById(Guid id);

         Task<UserDto> AddUserAsync(string username, string fullname);

         Task<bool> RemoveUserAsync(Guid id);

         Task<UserDto> UpdateUserAsync(Guid id,  string username, string fullname);
    }
}