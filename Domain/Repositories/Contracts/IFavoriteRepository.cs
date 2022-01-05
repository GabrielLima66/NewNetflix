using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    public interface IFavoriteRepository
    {
        Favorite Add(Favorite favorite);

        Favorite GetById(int id);

        Favorite Update(Favorite favorite);

        bool Delete(int id);
    }
}
