using System;
using Samples.AspNetCore.Server.Domain.Entities.Contracts;

namespace Samples.AspNetCore.Server.Domain.Entities
{
    public sealed class User : EntityBase, IUser
    {
        public User(Guid id, string name, string fullname)
            : base(id, name)
        {
            Fullname = fullname;
        }

        public string Fullname { get; }
    }
}