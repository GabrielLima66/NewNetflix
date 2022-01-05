using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchLaterController : Controller
    {
        WatchLaterService service;
        public WatchLaterController()
        {
            service = new WatchLaterService();
        }


        /// <summary>
        /// Listar Todos os WatchesLater
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(service.ListarWatchLater());
        }

        /// <summary>
        /// Listar WatchesLater por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna obj genero</returns>
        [HttpGet("{id}")]
        public ActionResult<WatchLater> GetWatchById(int id)
        {
            var AllWatchLater = service.ObterPorId(id);

            if (AllWatchLater == null)
            {
                return NotFound();
            }
            return Ok(AllWatchLater);
        }

        /// <summary>
        /// Adicionar WatchLater
        /// </summary>
        [HttpPost]

        public IActionResult Adicionar(WatchLaterInputModel watchInputModel)
        {
            WatchLater watch = new WatchLater();
            watch.MvId = watchInputModel.MvId;
            watch.WatchLaterId = watchInputModel.WatchLaterId;
            watch.SeId = watchInputModel.SeId;
            watch.UsrId = watchInputModel.UsrId;

            WatchLater watchResult = service.AddWatchLater(watch);

            WatchLaterOutputModel watchOutputModel = new WatchLaterOutputModel();
            watchOutputModel.UsrId = watchInputModel.UsrId;
            watchOutputModel.SeId = watchInputModel.SeId;
            watchOutputModel.MvId = watchInputModel.MvId;
            watchOutputModel.WatchLaterId = watchInputModel.WatchLaterId;

            return Ok(watchOutputModel);
        }

        /// <summary>
        /// Excluir WatchLater
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            return Ok(service.ExcluirWatchLater(id));
        }
    }
}
