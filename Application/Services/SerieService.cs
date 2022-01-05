using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class SerieService
    {
        SerieRepository serieRepository;

        public SerieService()
        {
            serieRepository = new SerieRepository();
        }
        public Series AddUpdateSerie(Series serie)
        {
            try
            {
                #region Regra de Negócio

                bool addFlag = false;
                if (serie.SeId == 0)
                {
                    addFlag = true;
                }
                #endregion

                #region Add or Update Movie

                return addFlag ? serieRepository.Add(serie) : serieRepository.Update(serie);

                #endregion

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }


        }
        public Series ObterPorId(int id)
        {
            try
            {
                return serieRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return null;
            }
        }
        public bool ExcluirSerie(int id)
        {
            try
            {
                return serieRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro: {ex.Message}");
                return false;
            }

        }

        public IEnumerable<Series> ListarTodasSeries()
        {
            return serieRepository.GetAll();
        }
    }
}

