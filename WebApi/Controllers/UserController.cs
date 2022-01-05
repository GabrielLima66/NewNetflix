using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.InputModels;
using WebApi.Models.OutputModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        UserService service;
        public UserController()
        {
            service = new UserService();
        }
        /// <summary>
        /// Listar Todos os Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {


            return Ok(service.ListarTodosUser());
        }

        /// <summary>
        /// Listar User por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna obj genero</returns>
        [HttpGet("{id}")]
        public ActionResult<User> GetGenreById(int id)
        {
            var AllUsers = service.ObterPorId(id);

            if (AllUsers == null)
            {
                return NotFound();
            }
            return Ok(AllUsers);
        }

        /// <summary>
        /// Adicionar User
        /// </summary>
        [HttpPost]
        public IActionResult Adicionar(UserInputModel userInputModel)
        {
            User user = new User();
            user.UsrId = userInputModel.UsrId;
            user.UsrName = userInputModel.UsrName;
            user.UsrPassword = userInputModel.UsrPassword;
            user.UsrEmail = userInputModel.UsrEmail;

            User userResult = service.AddUpdateUser(user);

            UserOutputModel userOutputModel = new UserOutputModel();
            userOutputModel.UsrName = userInputModel.UsrName;
            userOutputModel.UsrId = userInputModel.UsrId;

            return Ok(service.AddUpdateUser(user));
        }

        /// <summary>
        /// Alterar Genero por ID
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, UserInputModel userInputModel)
        {
            User user = new User();
            user.UsrId = userInputModel.UsrId;
            user.UsrName = userInputModel.UsrName;
            user.UsrPassword = userInputModel.UsrPassword;
            user.UsrEmail = userInputModel.UsrEmail;

            User userResult = service.AddUpdateUser(user);

            UserOutputModel userOutputModel = new UserOutputModel();
            userOutputModel.UsrName = userInputModel.UsrName;
            userOutputModel.UsrId = userInputModel.UsrId;

            return Ok(service.AddUpdateUser(user));

        }

        /// <summary>
        /// Excluir Gênero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            return Ok(service.ExcluirUser(id));
        }
    }
}
