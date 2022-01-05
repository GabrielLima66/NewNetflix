using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class FavoriteRepository
    {
        NewNetflixContext context;

        public FavoriteRepository()
        {
            context = new NewNetflixContext();
        }
        public Favorite Add(Favorite favorite)
        {

            context.Favorites.Add(favorite);
            context.SaveChanges();
            return favorite;
        }

        public bool Delete(int id)
        {
            var favorite = GetById(id);

            if (favorite.FavoritesId > 0)
            {
                context.Favorites.Remove(favorite);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public Favorite GetById(int id) => context.Favorites.Find(id);


        public Favorite Update(Favorite favorite)
        {
            var favoritesUp = GetById(favorite.FavoritesId);
            context.Entry(favoritesUp).CurrentValues.SetValues(favorite);
            context.SaveChanges();

            return favoritesUp;
        }

        public IEnumerable<Favorite> GetAll()
        {
            return context.Favorites.ToList();
        }
    }
}
