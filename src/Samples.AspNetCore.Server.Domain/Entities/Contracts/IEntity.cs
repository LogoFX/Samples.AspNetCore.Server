using System;

namespace Samples.AspNetCore.Server.Domain.Entities.Contracts
{
    public interface IEntity
    {
        Guid Id { get; }

        string Name { get; }
    }
}