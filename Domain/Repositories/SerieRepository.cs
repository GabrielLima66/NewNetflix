using Domain.Models;
using Domain.Repositories.Contracts;

namespace Domain.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        NewNetflixContext context;

        public SerieRepository()
        {
            context = new NewNetflixContext();
        }
        public Series Add(Series serie)
        {

            context.Series.Add(serie);
            context.SaveChanges();
            return serie;
        }

        public bool Delete(int id)
        {
            var serie = GetById(id);

            if (serie.SeId > 0)
            {
                context.Series.Remove(serie);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Series GetById(int id) => context.Series.Find(id);


        public Series Update(Series serie)
        {
            var serieUp = GetById(serie.SeId);
            context.Entry(serieUp).CurrentValues.SetValues(serie);
            context.SaveChanges();

            return serieUp;
        }

        public IEnumerable<Series> GetAll()
        {
            return context.Series.ToList();
        }
    }
}

