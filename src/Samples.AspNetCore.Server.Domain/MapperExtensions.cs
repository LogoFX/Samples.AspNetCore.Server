using Samples.AspNetCore.Server.Data.Contracts.Dto;
using Samples.AspNetCore.Server.Domain.Entities;
using Samples.AspNetCore.Server.Domain.Entities.Contracts;

namespace Samples.AspNetCore.Server.Domain
{
    internal static class MapperExtensions
    {
        public static IUser ToEntity(this UserDto userDto)
        {
            return new User(userDto.Id, userDto.Username, userDto.Fullname);
        }
    }
}