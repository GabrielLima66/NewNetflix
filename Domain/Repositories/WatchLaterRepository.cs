using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class WatchLaterRepository
    {
        NewNetflixContext context;

        public WatchLaterRepository()
        {
            context = new NewNetflixContext();
        }
        public WatchLater Add(WatchLater watchLater)
        {

            context.WatchLaters.Add(watchLater);
            context.SaveChanges();
            return watchLater;
        }

        public bool Delete(int id)
        {
            var watchLater = GetById(id);

            if (watchLater.WatchLaterId > 0)
            {
                context.WatchLaters.Remove(watchLater);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public WatchLater GetById(int id) => context.WatchLaters.Find(id);


        public IEnumerable<WatchLater> GetAll()
        {
            return context.WatchLaters.ToList();
        }
    }
}
