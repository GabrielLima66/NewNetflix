using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class UserWatchService
    {
        UserWatchRepository watchRepository;

        public UserWatchService()
        {
            watchRepository = new UserWatchRepository();
        }
        public UserWatch AddWatch(UserWatch watch)
        {
 
              return watchRepository.Add(watch);

        }
        public UserWatch ObterPorId(int id)
        {
            try
            {
                return watchRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirWatch(int id)
        {
            try
            {
                return watchRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<UserWatch> ListarTodosWatches()
        {
            return watchRepository.GetAll();
        }
    }
}
