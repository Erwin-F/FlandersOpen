using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Application.Repositories
{
    public interface IPitchRepository : IRepository<Pitch>
    {
        bool NumberAlreadyExists(int nr);
        Pitch GetByNumberWithItems(int nr);
    }
}
