using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserWatchRepository
    {
        NewNetflixContext context;

        public UserWatchRepository()
        {
            context = new NewNetflixContext();
        }
        public UserWatch Add(UserWatch watch)
        {

            context.UserWatches.Add(watch);
            context.SaveChanges();
            return watch;
        }

        public bool Delete(int id)
        {
            var watch = GetById(id);

            if (watch.MvId > 0)
            {
                context.UserWatches.Remove(watch);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public UserWatch GetById(int id) => context.UserWatches.Find(id);

        public IEnumerable<UserWatch> GetAll()
        {
            return context.UserWatches.ToList();
        }
    }
}
