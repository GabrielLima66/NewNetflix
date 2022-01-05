using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        MovieService service;
        public MovieController()
        {
            service = new MovieService();
        }
        [HttpGet]
        public IActionResult Index()
        {


            return Ok(service.ListarTodosMovies());
        }
        [HttpGet("{id}")]
        public ActionResult<Movie> GetAllMovies(int id)
        {
            var AllMovies = service.ObterPorId(id);

            if (AllMovies == null)
            {
                return NotFound();
            }
            return Ok(AllMovies);
        }
        [HttpPost]
        public IActionResult Adicionar(MovieInputModel movieInputModel)
        {
            Movie movie = new Movie();
            movie.MvId = movieInputModel.MvId;
            movie.MvTitle = movieInputModel.MvTitle;
            movie.MvDate = movieInputModel.MvDate;
            movie.GrId = movieInputModel.GrId;

            Movie movieResult = service.AddUpdateMovie(movie);

            MovieOutputModel movieOutputModel = new MovieOutputModel();
            movieOutputModel.MvId = movieInputModel.MvId;
            movieOutputModel.MvTitle = movieOutputModel.MvTitle;
            movieOutputModel.GrId = movieInputModel.GrId;
            movieOutputModel.MvDate = movieInputModel.MvDate;

            return Ok(movieOutputModel);
        }
        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, MovieInputModel movieInputModel)
        {
            Movie movie = new Movie();
            movie.MvId = movieInputModel.MvId;
            movie.MvTitle = movieInputModel.MvTitle;
            movie.MvDate = movieInputModel.MvDate;
            movie.GrId = movieInputModel.GrId;

  
          

           return Ok(service.AddUpdateMovie(movie));


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
            {
            return Ok(service.ExcluirMovie(id));
            }
        
    }
}
