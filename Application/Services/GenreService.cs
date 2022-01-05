using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class GenreService
    {
        GenreRepository genreRepository;

        public GenreService()
        {
            genreRepository = new GenreRepository();
        }

        public Genre AddUpdateGenre(Genre genre)
        {


            try
            {
                #region Regra de Negocio
                bool addFlag = false;

                if (genre.GrId == 0)
                {
                    addFlag = true;
                }
                #endregion
                #region Adicionar ou Alterar
                return addFlag ? genreRepository.Add(genre) : genreRepository.Update(genre);
                #endregion
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }

        }
        public Genre ObterPorId(int id)
        {
            try
            {
                return genreRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirGenre(int id)
        {
            try
            {
                return genreRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }
        public IEnumerable<Genre> ListarTodosGenres()
        {
            return genreRepository.GetAll();
        }

    }
}
