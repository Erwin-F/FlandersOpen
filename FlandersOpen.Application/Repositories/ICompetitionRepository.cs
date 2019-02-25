using System;
using System.Collections.Generic;
using System.Text;
using FlandersOpen.Domain.Entities;

namespace FlandersOpen.Application.Repositories
{
    public interface ICompetitionRepository : IRepository<Competition>
    {
        bool AlreadyExists(string name);
    }
}
