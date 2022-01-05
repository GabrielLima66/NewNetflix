using Application.Services;
using Domain.Models;





MovieService service = new MovieService();
Movie movie = new Movie()
{
   MvId = 11,MvTitle = "Meu Malvado Favorito 3",MvDate = "2021-12-19"
};
service.AddUpdateMovie(movie);

Console.WriteLine(movie.MvId);
Console.WriteLine(movie.MvTitle);


//Console.WriteLine(service.ExcluirMovie(movie.MvId) ? $"Filme excluído {movie.MvTitle}" : "Erro ao excluir");


Console.ReadKey();
