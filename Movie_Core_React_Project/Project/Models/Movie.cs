/**
 *  Class name: Movie
 *  Description: Movie model to represent each movie item received from the APIs
 * 
 *  Class name: MovieList
 *  Description: Contains a public member to represent a list of movie items recieved from the APIs.
 *      This is needed because when we try to get all movies from the APIs, they do not return a list
 *      of Movie objects. Instead they return an object with a field named 'Movies' which contains
 *      a list of Movie objects. Thus, this class is designed to facilitate JSON deserialisation.
 */

using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class MovieList
    {
        public IEnumerable<Movie> Movies;
    }
    public class Movie
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Source { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
        public string Rated { get; set; }
        public string Release { get; set; }
        public string Runtime { get; set; }
        public string Genres { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public double Metascore { get; set; }
        public double Rating { get; set; }
        public string Votes { get; set; }

        // Convert Movie data model to data transfer object.
        public static MovieDTO ConvertToMovieDTO(Movie m)
        {
            var movieDTO = new MovieDTO
            {
                ID = m.ID,
                Title = m.Title,
                Price = m.Price,
                Source = m.Source,
                Poster = m.Poster,
                Year = m.Year,
                Type = m.Type,
                Rated = m.Rated,
                Release = m.Release,
                Runtime = m.Runtime,
                Genres = m.Genres,
                Director = m.Director,
                Writer = m.Writer,
                Actors = m.Actors,
                Plot = m.Plot,
                Language = m.Language,
                Country = m.Country,
                Awards = m.Awards,
                Metascore = m.Metascore,
                Rating = m.Rating,
                Votes = m.Votes
            };
            return movieDTO;
        }
    }
}
