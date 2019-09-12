using System;
using Samples.AspNetCore.Server.Domain.Entities.Contracts;

namespace Samples.AspNetCore.Server.Domain.Entities
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; set; }
    }
}