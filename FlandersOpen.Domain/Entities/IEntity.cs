using System;

namespace FlandersOpen.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime ModificationDate { get; set; }
    }
}
