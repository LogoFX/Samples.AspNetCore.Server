﻿using Samples.AspNetCore.Server.Data.Contracts.Dto;

namespace Samples.AspNetCore.Server.Api.Models
{
    internal static class UserExtensions
    {
        public static User ToModel(this UserDto userDto)
        {
            return new User {Username = userDto.Username, Fullname = userDto.Fullname};
        }
    }
}