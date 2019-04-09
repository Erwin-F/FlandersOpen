using FlandersOpen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlandersOpen.Persistence.Test
{
    public class UserRepositoryFact : BaseRepositoryFact<User>
    {
        protected override User BuildItem()
        {
            return User.Register("username", "firstname", "lastname", "bla");
        }
    }
}
