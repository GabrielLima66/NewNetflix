using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoriteController : Controller
    {
        FavoriteService service;
        public FavoriteController()
        {
            service = new FavoriteService();
        }
        /// <summary>
        /// Listar Todos os Favorites
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {


            return Ok(service.ListarTodosFav());
        }

        /// <summary>
        /// Listar Favorite por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna obj genero</returns>
        [HttpGet("{id}")]
        public ActionResult<Favorite> GetGenreById(int id)
        {
            var AllFavs = service.ObterPorId(id);

            if (AllFavs == null)
            {
                return NotFound();
            }
            return Ok(AllFavs);
        }

        /// <summary>
        /// Adicionar Favorite
        /// </summary>
        [HttpPost]
        public IActionResult Adicionar(FavoriteInputModel favInputModel)
        {
            Favorite fav = new Favorite();
            fav.MvId = favInputModel.MvId;
            fav.UsrId = favInputModel.UsrId;
            fav.SeId = favInputModel.SeId;
            fav.FavoritesId = favInputModel.FavoritesId;

            Favorite favResult = service.AddUpdateFav(fav);

            FavoriteOutputModel favOutputModel = new FavoriteOutputModel();
            favOutputModel.MvId = favInputModel.MvId;
            favOutputModel.SeId = favOutputModel.UsrId;
            favOutputModel.FavoritesId = favOutputModel.FavoritesId;
            favOutputModel.UsrId = favOutputModel.UsrId;



            return Ok(service.AddUpdateFav(fav));
        }

        /// <summary>
        /// Alterar Favorite por ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult PutFav(int id, FavoriteInputModel favInputModel)
        {
            Favorite fav = new Favorite();
            fav.MvId = favInputModel.MvId;
            fav.UsrId = favInputModel.UsrId;
            fav.SeId = favInputModel.SeId;
            fav.FavoritesId = favInputModel.FavoritesId;

            Favorite favResult = service.AddUpdateFav(fav);

            FavoriteOutputModel favOutputModel = new FavoriteOutputModel();
            favOutputModel.MvId = favInputModel.MvId;
            favOutputModel.SeId = favOutputModel.UsrId;
            favOutputModel.FavoritesId = favOutputModel.FavoritesId;
            favOutputModel.UsrId = favOutputModel.UsrId;



            return Ok(service.AddUpdateFav(fav));

        }

        /// <summary>
        /// Excluir Favorite
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteFav(int id)
        {
            return Ok(service.ExcluirFav(id));
        }
    }
}
