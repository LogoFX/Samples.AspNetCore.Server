using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.AspNetCore.Server.Data.Contracts.Dto;
using Samples.AspNetCore.Server.Data.Contracts.Providers;

namespace Samples.AspNetCore.Server.Data.Fake.Providers
{
    public class FakeUsersProvider : IUsersProvider
    {
        private readonly List<UserDto> _users = new List<UserDto>();

        public FakeUsersProvider()
        {
            _users.AddRange(new[]
            {
                new UserDto {Username = "User1", Fullname = "User A"},
                new UserDto {Username = "User2", Fullname = "User B"},
                new UserDto {Username = "User3", Fullname = "User C"},
            });
        }

        public Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            IEnumerable<UserDto> result = _users.ToArray();
            return Task.Run(() => result);
        }

        public Task<UserDto> AddUserAsync(string username, string fullname)
        {
            var userDto = new UserDto {Username = username, Fullname = fullname};
            _users.Add(userDto);
            return Task.Run(() => userDto);
        }

        public Task<bool> RemoveUserAsync(UserDto user)
        {
            return Task.Run(() => _users.Remove(user));
        }

        public Task<UserDto> UpdateUserAsync(UserDto user, string fullname)
        {
            _users.Remove(user);

            var userDto = new UserDto
            {
                Username = user.Username,
                Fullname = fullname
            };

            _users.Add(userDto);

            return Task.Run(() => userDto);
        }
    }
}