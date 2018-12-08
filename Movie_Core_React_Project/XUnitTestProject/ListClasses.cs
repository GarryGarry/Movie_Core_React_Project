using Project.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject
{
   static class ListClasses
    {
        public static List<Movie> GetMockMovies()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie()
            {
                Title = "Star Wars: Episode III - Revenge of the Sith",
                Price = 30.05,
                ID = "cw0121766",
                Source = "cinemaworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BNTc4MTc3NTQ5OF5BMl5BanBnXkFtZTcwOTg0NjI4NA@@._V1_SX300.jpg"
            });
            movies.Add(new Movie()
            {
                Title = "Star Wars: Episode III - Revenge of the Sith",
                Price = 20.05,
                ID = "cw012176",
                Source = "cinemaworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BNTc4MTc3NTQ5OF5BMl5BanBnXkFtZTcwOTg0NjI4NA@@._V1_SX300.jpg"
            });
            movies.Add(new Movie()
            {
                Title = "Star Wars: Episode II - Attack of the Clones",
                Price = 5.35,
                ID = "cw0121765",
                Source = "filmworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BMTY5MjI5NTIwNl5BMl5BanBnXkFtZTYwMTM1Njg2._V1_SX300.jpg"
            });
            movies.Add(new Movie()
            {
                Title = "Star Wars: Episode II - Attack of the Clones",
                Price = 9.35,
                ID = "cw01765",
                Source = "filmworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BMTY5MjI5NTIwNl5BMl5BanBnXkFtZTYwMTM1Njg2._V1_SX300.jpg"
            });
            return movies;
        }

        public static List<Movie> GetMockNullValueMovies()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie()
            {
                Title = null,                
                ID = null,
                Source = null,
                Poster = null
            });
            movies.Add(new Movie()
            {
                Title = null,
                ID = null,
                Source = null,
                Poster = null
            });
            return movies;
        }

        public static List<Movie> GetMockEmptyMovies()
        {
            var movies = new List<Movie>();

            return movies;
        }

        public static Movie GetMockMovie()
        {
            var movie = new Movie()
            {
                Title = "Star Wars: Episode III - Revenge of the Sith",
                Price = 30.05,
                ID = "cw0121766",
                Source = "cinemaworld",
                Poster = "http://ia.media-imdb.com/images/M/MV5BNTc4MTc3NTQ5OF5BMl5BanBnXkFtZTcwOTg0NjI4NA@@._V1_SX300.jpg"
            };
            return movie;
        }
        public static Movie GetMockNullMovie()
        {
            var movie = new Movie()
            {
                Title = null,
                Price = 0,
                ID = null,
                Source = null,
                Poster = null
            };
            return movie;
        }
        public static Movie GetMockEmptyMovie()
        {
            var movie = new Movie() { };
           
            return movie;
        }

    }
}
