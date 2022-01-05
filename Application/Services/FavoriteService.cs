using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FavoriteService
    {
        FavoriteRepository favRepository;

        public FavoriteService()
        {
            favRepository = new FavoriteRepository();
        }
        public Favorite AddUpdateFav(Favorite favorite)
        {
            try
            {
                #region Regra de Negócio

                bool addFlag = false;
                if (favorite.FavoritesId == 0)
                {
                    addFlag = true;
                }
                #endregion

                #region Add or Update Movie

                return addFlag ? favRepository.Add(favorite) : favRepository.Update(favorite);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }
        public Favorite ObterPorId(int id)
        {
            try
            {
                return favRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirFav(int id)
        {
            try
            {
                return favRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<Favorite> ListarTodosFav()
        {
            return favRepository.GetAll();
        }
    }
}
