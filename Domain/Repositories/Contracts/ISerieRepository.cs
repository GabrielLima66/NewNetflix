using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface ISerieRepository
    {
        Series Add(Series serie);

        Series GetById(int id);

        Series Update(Series series);

        bool Delete(int id);
    }
}
