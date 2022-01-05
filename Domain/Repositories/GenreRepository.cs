using Domain.Models;
using Domain.Repositories.Contracts;

namespace Domain.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        NewNetflixContext context;

        public GenreRepository()
        {
            context = new NewNetflixContext();
        }
        public Genre Get(int id) => context.Genres.Find(id);

        public bool Delete(int id)
        {
            var genre = Get(id);
            if (genre.GrId > 0)
            {
                context.Genres.Remove(genre);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Genre Add(Genre genre)
        {
            context.Genres.Add(genre);
            context.SaveChanges();
            return genre;
        }

        public Genre Update(Genre genre)
        {
            var genreUp = Get(genre.GrId);

            context.Entry(genreUp).CurrentValues.SetValues(genre);
            context.SaveChanges();

            return genreUp;
        }

        public IEnumerable<Genre> GetAll()
        {
            return context.Genres.ToList();
        }
    }
}
