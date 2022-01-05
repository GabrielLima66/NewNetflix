using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface IUserWatchRepository
    {
        UserWatch Add(UserWatch watch);

        UserWatch GetById(int id);

        bool Delete(int id);
    }
}
