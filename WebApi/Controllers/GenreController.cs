using Application.Services;
using Domain.Models;
using Domain.Models.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        GenreService service;
        public GenreController()
        {
            service = new GenreService();
        }
        /// <summary>
        /// Listar Todos os Gêneros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {


            return Ok(service.ListarTodosGenres());
        }

        /// <summary>
        /// Listar Genero por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna obj genero</returns>
        [HttpGet("{id}")]
        public ActionResult<Movie> GetGenreById(int id)
        {
            var AllGenres = service.ObterPorId(id);

            if (AllGenres == null)
            {
                return NotFound();
            }
            return Ok(AllGenres);
        }

        /// <summary>
        /// Adicionar Gênero
        /// </summary>
        [HttpPost]
        public IActionResult Adicionar(GenreInputModel genreInputModel)
        {
            Genre genre = new Genre();
            genre.GrId = genreInputModel.GrId;
            genre.Genre1 = genreInputModel.genre;
            

            
            return Ok(service.AddUpdateGenre(genre));
        }

        /// <summary>
        /// Alterar Genero por ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, GenreInputModel genreInputModel)
        {
            Genre genre = new Genre();
            genre.GrId = genreInputModel.GrId;
            genre.Genre1 = genreInputModel.genre;

            return Ok(service.AddUpdateGenre(genre));

        }

        /// <summary>
        /// Excluir Gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            return Ok(service.ExcluirGenre(id));
        }
    }
}
