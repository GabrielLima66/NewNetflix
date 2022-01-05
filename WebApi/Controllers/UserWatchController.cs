using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserWatchController : Controller
    {
        UserWatchService service;
        public UserWatchController()
        {
            service = new UserWatchService();
        }


        /// <summary>
        /// Listar Todos os Watches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(service.ListarTodosWatches());
        }

        /// <summary>
        /// Listar Watches por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna obj genero</returns>
        [HttpGet("{id}")]
        public ActionResult<UserWatch> GetWatchById(int id)
        {
            var AllWatches = service.ObterPorId(id);

            if (AllWatches == null)
            {
                return NotFound();
            }
            return Ok(AllWatches);
        }

        /// <summary>
        /// Adicionar UserWatch
        /// </summary>
        [HttpPost]

        public IActionResult Adicionar(UserWatchInputModel watchInputModel)
        {
            UserWatch watch = new UserWatch();
            watch.UsrWatchId = watchInputModel.UsrWatchId;
            watch.UsrId = watchInputModel.UsrId;
            watch.MvId = watchInputModel.MvId;
            watch.SeId = watchInputModel.SeId;
            watch.Watched = watchInputModel.Watched;

            UserWatch watchResult = service.AddWatch(watch);

            UserWatchOutputModel watchOutputModel = new UserWatchOutputModel();
            watchOutputModel.UsrWatchId = watchInputModel.UsrWatchId;
            watchOutputModel.Watched = watchInputModel.Watched;

            return Ok(watchOutputModel);
        }

        /// <summary>
        /// Excluir Watch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteWatch(int id)
        {
            return Ok(service.ExcluirWatch(id));
        }
    }
}
