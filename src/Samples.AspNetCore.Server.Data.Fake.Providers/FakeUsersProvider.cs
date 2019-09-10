using System;
using System.Collections.Generic;
using System.Linq;
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
                CreateUser("User1", "User One"),
                CreateUser("User2", "User Two"),
                CreateUser("User3", "User Three")
            });
        }

        private UserDto CreateUser(string username, string fullname)
        {
            return new UserDto {Id = Guid.NewGuid(), Username = username, Fullname = fullname};
        }

        private UserDto GetUserByNameInternal(string username)
        {
            return _users.FirstOrDefault(x => string.Compare(x.Username, username, StringComparison.OrdinalIgnoreCase) == 0);
        }

        private UserDto GetUserByIdInternal(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return Task.Run(() => (IEnumerable<UserDto>) _users.ToArray());
        }

        public Task<UserDto> GetUserByName(string username)
        {
            return Task.Run(() => GetUserByNameInternal(username));
        }

        public Task<UserDto> GetUserById(Guid id)
        {
            return Task.Run(() => GetUserByIdInternal(id));
        }

        public Task<UserDto> AddUserAsync(string username, string fullname)
        {
            return Task.Run(() =>
            {
                if (GetUserByNameInternal(username) != null)
                {
                    throw new ApplicationException($"User '{username}' already added.");
                }

                var userDto = CreateUser(username, fullname);
                _users.Add(userDto);

                return userDto;
            });
        }

        public Task<bool> RemoveUserAsync(Guid id)
        {
            return Task.Run(() =>
            {
                var user = GetUserByIdInternal(id);
                return _users.Remove(user);
            });
        }

        public Task<UserDto> UpdateUserAsync(Guid id, string username, string fullname)
        {
            return Task.Run(() =>
            {
                var user = GetUserByIdInternal(id);
                user.Username = username;
                user.Fullname = fullname;

                return user;
            });
        }
    }
}