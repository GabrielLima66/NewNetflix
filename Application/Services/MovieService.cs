using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class MovieService
    {

        MovieRepository movieRepository;

        public MovieService()
        {
             movieRepository = new MovieRepository();
        }
        public Movie AddUpdateMovie(Movie movie)
        {
            try
            {
                #region Regra de Negócio
                
                bool addFlag = false;
                if (movie.MvId == 0)
                {
                    addFlag = true;
                }
                #endregion

                #region Add or Update Movie

                return addFlag ? movieRepository.Add(movie) : movieRepository.Update(movie);
                
                #endregion
               
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }

           
        }
       public Movie ObterPorId(int id)
        {
            try
            {
            return movieRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirMovie( int id)
        {
            try
            {
                return movieRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                
            }

        }
        
        public IEnumerable<Movie> ListarTodosMovies()
        {
            return movieRepository.GetAll();
        }
    }
}
