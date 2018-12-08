/**
 *  File: DTO classes 
 *  Description: This contains all data transfer objects,
 *      which will be used to pass json result to the front-end.
 */

using System;

namespace Project.Models
{
    public class MovieListItemDTO
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Poster { get; set; }
    }

    public class MovieDTO
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
    }
}
