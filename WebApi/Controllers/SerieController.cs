using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerieController : Controller
    {
        SerieService service;
        public SerieController()
        {
            service = new SerieService();
        }
        /// <summary>
        /// Lista todas as Series
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {


            return Ok(service.ListarTodasSeries());
        }
        /// <summary>
        /// Lista Serie por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Series> GetAllMovies(int id)
        {
            var AllSeries = service.ObterPorId(id);

            if (AllSeries == null)
            {
                return NotFound();
            }
            return Ok(AllSeries);
        }
        /// <summary>
        /// Adicionar Serie
        /// </summary>
        [HttpPost]
        public IActionResult Adicionar(SerieInputModel serieInputModel)
        {
            Series serie = new Series();
            serie.SeId = serieInputModel.SeId;
            serie.SeTitle = serieInputModel.SeTitle;
            serie.SeDate = serieInputModel.SeDate;
            serie.SeImg = serieInputModel.SeImg;
            serie.GrId = serieInputModel.GrId;
            serie.SeQtdSeasons = serieInputModel.SeQtdSeasons;

            Series serieResult = service.AddUpdateSerie(serie);

            SerieOutputModel serieOutputModel = new SerieOutputModel();
            serieOutputModel.SeId = serieInputModel.SeId;
            serieOutputModel.SeTitle = serieInputModel.SeTitle;
            serieOutputModel.GrId = serieInputModel.GrId;

            return Ok(serieOutputModel);
        }

        /// <summary>
        /// Alterar Serie por ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, SerieInputModel serieInputModel)
        {
            Series serie = new Series();
            serie.SeId = serieInputModel.SeId;
            serie.SeTitle = serieInputModel.SeTitle;
            serie.SeDate = serieInputModel.SeDate;
            serie.SeImg = serieInputModel.SeImg;
            serie.GrId = serieInputModel.GrId;
            serie.SeQtdSeasons = serieInputModel.SeQtdSeasons;

            Series serieResult = service.AddUpdateSerie(serie);

            SerieOutputModel serieOutputModel = new SerieOutputModel();
            serieOutputModel.SeId = serieInputModel.SeId;
            serieOutputModel.SeTitle = serieInputModel.SeTitle;
            serieOutputModel.GrId = serieInputModel.GrId;

            return Ok(serieResult);

        }

        /// <summary>
        /// Excluir Serie por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            return Ok(service.ExcluirSerie(id));
        }
    }
}
