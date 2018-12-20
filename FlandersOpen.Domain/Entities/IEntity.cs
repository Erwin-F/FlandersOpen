using System;

namespace FlandersOpen.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
        DateTime ModificationDate { get; }
    }
}
