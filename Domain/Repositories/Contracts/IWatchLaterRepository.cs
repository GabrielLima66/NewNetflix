using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface IWatchLaterRepository
    {
        WatchLater Add(WatchLater watchLater);

        WatchLater GetById(int id);

        bool Delete(int id);
    }
}
