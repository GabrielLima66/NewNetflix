using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class WatchLaterService
    {
        WatchLaterRepository watchLaterRepository;

        public WatchLaterService()
        {
            watchLaterRepository = new WatchLaterRepository();
        }
        public WatchLater AddWatchLater(WatchLater watchLater)
        {
            try
            {

                #region Add or Update Movie

                return watchLaterRepository.Add(watchLater);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }
        public WatchLater ObterPorId(int id)
        {
            try
            {
                return watchLaterRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirWatchLater(int id)
        {
            try
            {
                return watchLaterRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<WatchLater> ListarWatchLater()
        {
            return watchLaterRepository.GetAll();
        }
    }
}
