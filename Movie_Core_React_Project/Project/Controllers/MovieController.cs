using Microsoft.AspNetCore.Mvc;
using Project.DataAccess;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    public class MovieController
    {
        private readonly IMovieProvider _movieProvider;
  //     private MovieProvider _movieProvider = new MovieProvider();
        public MovieController(IMovieProvider movieProvider)
        {
            _movieProvider = movieProvider;
    }
        [HttpGet("[action]")]
        public IEnumerable<MovieListItemDTO> GetAllMovies()
        {           
            var task = _movieProvider.GetAllMovies();
            var allMovies = task.Result;

            var movieListDTO = allMovies.Select(m => new MovieListItemDTO
            {
                ID = m.ID,
                Title = m.Title,
                Poster = m.Poster,
                Source = m.Source
            });
            return movieListDTO;
        }
        [HttpGet("[action]")]
        public IEnumerable<MovieDTO> GetCheapestMoviesFromApi(string apiName)
        {
            var cheapestMovies = new List<MovieDTO>();
            IEnumerable<Movie> allMovies = new List<Movie>(); ;
            allMovies = _movieProvider.GetAllMoviesFromApi(apiName, true).Result;
            if (allMovies != null && (allMovies.ToList().Count > 0))
            {
                var cheapestPrice = allMovies.Min(m => m.Price);
                cheapestMovies = allMovies.Where(m => m.Price == cheapestPrice).Select(m => Movie.ConvertToMovieDTO(m)).ToList();
            }
            return cheapestMovies;
        }

        [HttpGet("[action]")]
        public MovieDTO GetFullDetailMovie(string Id)
        {
            var movie = _movieProvider.GetFullDetailMovie(Id).Result;
            
            return Movie.ConvertToMovieDTO(movie);
        }
    }
}
