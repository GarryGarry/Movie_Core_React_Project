using Microsoft.Extensions.Logging;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Project.DataAccess
{
    public interface IMovieProvider
    {
        Task<IEnumerable<Movie>> GetAllMoviesFromApi(string apiName, bool? fullDetails = false);
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetFullDetailMovie(string id);
    }
    public class MovieProvider : IMovieProvider
    {
        //private readonly ILogger<MovieProvider> _logger;
        // Data for HTTP client object
        private const string URL = "http://webjetapitest.azurewebsites.net/api/";
        private const string ACCESS_TOKEN_HEADER = "x-access-token";
        private const string ACCESS_TOKEN = "sjd1HfkjU83ksdsm3802k";
        // API paths
        private const string CINEMAWORLD_GET_ALL_MOVIES = "cinemaworld/movies";
        private const string FILMWORLD_GET_ALL_MOVIES = "filmworld/movies";
        private const string CINEMAWORLD_GET_MOVIE = "cinemaworld/movie/";
        private const string FILMWORLD_GET_MOVIE = "filmworld/movie/";
        // HTTP client object
        private HttpClient httpClient = null;

        public MovieProvider()
        {
            
            // Initialise HTTP client if it does not exist
            if (httpClient == null)
            {
                httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(URL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                // Add an Accept header for JSON format
                httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                // Add access token header
                httpClient.DefaultRequestHeaders.Add(ACCESS_TOKEN_HEADER, ACCESS_TOKEN);
            }
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesFromApi(string apiName, bool? fullDetails = false)
        {
            var movies = new List<Movie>();
            var path = string.Empty;
            switch (apiName)
            {
                case "cinemaworld":
                    path = CINEMAWORLD_GET_ALL_MOVIES;
                    break;
                case "filmworld":
                    path = FILMWORLD_GET_ALL_MOVIES;
                    break;
            }
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }
            try
            {
                // Get all movies from selected API
                HttpResponseMessage apiResponse = await httpClient.GetAsync(path);

                if (apiResponse.IsSuccessStatusCode)
                {
                    var moviesList = await apiResponse.Content.ReadAsAsync<MovieList>();
                    if (moviesList != null)
                    {
                        movies = moviesList.Movies.ToList();
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                //_logger.LogError(string.Format("Error: {0}.\n Source: {1} \n InnerExceptions: {2} \n",
                //        e.Message, e.Source, e.InnerException));
                return null;
            }
            if (movies.Any())
            {
                if (fullDetails.HasValue && fullDetails.Value)
                {
                    // Here, foreach movie ID, we will make a call to the api to get the full details of each movie.
                    // Compute the batch of queries
                    IEnumerable<Task<Movie>> batchTaskQueries = movies.Select(m => GetFullDetailMovie(m.ID));
                    // Call ToList() to execute all the queries at once
                    List<Task<Movie>> batchTasks = batchTaskQueries.ToList();
                    movies = new List<Movie>();
                    while (batchTasks.Count > 0)
                    {
                        // Check if any task has done
                        Task<Movie> finishedTask = await Task.WhenAny(batchTasks);
                        batchTasks.Remove(finishedTask);
                        // Get the result from the complete task
                        var movie = await finishedTask;
                        if (movie != null)
                        {
                            movie.Source = apiName;
                            movies.Add(movie);
                        }
                    }
                }
                else
                {
                    movies.ForEach(m => m.Source = apiName);
                }
                return movies;
            }
            return null;
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var allMovies = new List<Movie>();
            // Start task: Get all movies from cinemaworld
            var cinemaWorldGetMoviesTask = GetAllMoviesFromApi("cinemaworld");
            // Start task: Get all movies from filmworld
            var filmWorldGetMoviesTask = GetAllMoviesFromApi("filmworld");

            // Wait until both async tasks are completed
            var cinemaWorldMovies = await cinemaWorldGetMoviesTask;
            var filmWorldMovies = await filmWorldGetMoviesTask;

            // Combine both results into one Movie list
            if (cinemaWorldMovies != null)
            {
                allMovies.AddRange(cinemaWorldMovies);
            }
            if (filmWorldMovies != null)
            {
                allMovies.AddRange(filmWorldMovies);
            }
            return allMovies;
        }

        public async Task<Movie> GetFullDetailMovie(string id)
        {
            var movie = new Movie();
            try
            {
                // Try get the movie detail from cinemaworld
                var cinemaWorldGetMovieTask = httpClient.GetAsync(CINEMAWORLD_GET_MOVIE + id);
                var filmWorldGetMovieTask = httpClient.GetAsync(FILMWORLD_GET_MOVIE + id);

                var cinemaWorldResponse = await cinemaWorldGetMovieTask;
                if (cinemaWorldResponse.IsSuccessStatusCode)
                {
                    movie = await cinemaWorldResponse.Content.ReadAsAsync<Movie>();
                    // If the movie is found, terminate the thread here.
                    return movie;
                }
                var filmWorldResponse = await filmWorldGetMovieTask;
                if (filmWorldResponse.IsSuccessStatusCode)
                {
                    movie = await filmWorldResponse.Content.ReadAsAsync<Movie>();
                    return movie;
                }
            }
            catch (Exception e)
            {
                //_logger.LogError(string.Format("Error: {0}.\n Source: {1} \n InnerExceptions: {2} \n",
                //       e.Message, e.Source, e.InnerException));
            }
            return null;
        }
        //Dispose HttpClient, call this when no more requests from the API are needed.
        public void Dispose()
        {
            httpClient.Dispose();
        }

    }
}
