using Domain.Models;

namespace Domain.Repositories.Contracts
{
    internal interface IGenreRepository
    {
        Genre Add(Genre genre);

        Genre Update(Genre genre);

        bool Delete(int id);

        Genre Get(int id);
    }
}
