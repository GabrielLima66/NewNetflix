using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Contracts
{
    internal interface IMovieRepository
    {
        Movie Add(Movie movie);

        Movie GetById(int id);

        Movie Update(Movie movie);

        bool Delete(int id);
    }
}
