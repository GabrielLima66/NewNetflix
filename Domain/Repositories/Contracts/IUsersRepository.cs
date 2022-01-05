using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface IUsersRepository
    {
        User Add(User user);

        User GetById(int id);

        User Update(User user);

        bool Delete(int id);
    }
}
