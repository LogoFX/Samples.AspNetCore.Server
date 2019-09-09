using System.Diagnostics.CodeAnalysis;
using Samples.AspNetCore.Server.Data.Contracts.Dto;

namespace Samples.AspNetCore.Server.Data.Fake.Providers.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    class GetUserResponse
    {
        public string error { get; set; }
        public UserDto user { get; set; }
    }
}