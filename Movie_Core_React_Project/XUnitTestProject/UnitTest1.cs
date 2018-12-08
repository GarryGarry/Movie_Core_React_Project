using Moq;
using Project.Controllers;
using Project.DataAccess;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace XUnitTestProject
{
    public class UnitTest1
    {

        [Fact]
        public void Test_GetCheapestMoviesFromApi_Returns_MovieDTO_CinemaWorld()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMoviesFromApi("cinemaworld", true)).ReturnsAsync(ListClasses.GetMockMovies());

            var controller = new MovieController(mockRepo.Object);
                     
            // Act
            var cinema = controller.GetCheapestMoviesFromApi("cinemaworld");
            var count = cinema.ToList().Count;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<MovieDTO>>(cinema);
            Assert.NotNull(cinema);
            Assert.True(cinema.ToList().Count != 0);
        }

        [Fact]
        public void Test_GetCheapestMoviesFromApi_Returns_MovieDTO_FilmWorld()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMoviesFromApi("filmworld", true)).ReturnsAsync(ListClasses.GetMockMovies());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var film = controller.GetCheapestMoviesFromApi("filmworld");
            var c = film.ToList().Count;
            
            //Assert
            Assert.IsAssignableFrom<IEnumerable<MovieDTO>>(film);
            Assert.NotNull(film);          
            Assert.True(film.ToList().Count != 0);
        }

        [Fact]
        public void Test_GetCheapestMoviesFromApi_Returns_MovieDTO_NoException_EmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMoviesFromApi("cinemaworld", true)).ReturnsAsync(ListClasses.GetMockEmptyMovies());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var random = controller.GetCheapestMoviesFromApi("cinemaworld");
            var c = random.ToList().Count;
            
            //Assert
            Assert.True(random.ToList().Count == 0);

            try
            {
                Assert.Throws<InvalidOperationException>(() => controller.GetCheapestMoviesFromApi("cinemaworld"));
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }
        [Fact]
        public void Test_GetAllMovies_Returns_MovieListItemDTO_TypeAndValues()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMovies())
                .ReturnsAsync(ListClasses.GetMockMovies());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var actual = controller.GetAllMovies();
            var kk = actual.ToList().Count;
            var k = actual.GetType();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<MovieListItemDTO>>(actual);
            Assert.NotNull(actual);
            Assert.True(actual.ToList().Count != 0);
        }

        [Fact]
        public void Test_GetAllMovies_handles_null()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMovies())
                .ReturnsAsync(ListClasses.GetMockNullValueMovies());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var actual = controller.GetAllMovies();

            //Assert
            try
            {
                Assert.Throws<InvalidOperationException>(() => controller.GetAllMovies());
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_GetAllMovies_handles_empty_result()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetAllMovies())
                .ReturnsAsync(ListClasses.GetMockEmptyMovies());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var actual = controller.GetAllMovies();

            //Assert
            Assert.True(actual.ToList().Count == 0);

            try
            {
                Assert.Throws<InvalidOperationException>(() => controller.GetAllMovies());
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_GetFullDetailMovie_Returns_ById()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetFullDetailMovie("cw0121766")).ReturnsAsync(ListClasses.GetMockMovie());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var cinema = controller.GetFullDetailMovie("cw0121766");

            //Assert
            Assert.IsAssignableFrom<MovieDTO>(cinema);
            Assert.NotNull(cinema);
        }

        [Fact]
        public void Test_GetFullDetailMovie_Returns_ById_GetMockNullMovie()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetFullDetailMovie("cw0121766")).ReturnsAsync(ListClasses.GetMockNullMovie());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var cinema = controller.GetFullDetailMovie("cw0121766");

            //Assert
            Assert.IsAssignableFrom<MovieDTO>(cinema);
            Assert.NotNull(cinema);
            try
            {
                Assert.Throws<InvalidOperationException>(() => controller.GetFullDetailMovie("cw0121766"));
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_GetFullDetailMovie_Returns_ById_EmptyList()
        {
            // Arrange
            var mockRepo = new Mock<IMovieProvider>();
            mockRepo.Setup(repo => repo.GetFullDetailMovie("cw0121766")).ReturnsAsync(ListClasses.GetMockEmptyMovie());

            var controller = new MovieController(mockRepo.Object);

            // Act
            var cinema = controller.GetFullDetailMovie("cw0121766");

            //Assert
            Assert.IsAssignableFrom<MovieDTO>(cinema);
            Assert.NotNull(cinema);

            try
            {
                Assert.Throws<InvalidOperationException>(() => controller.GetFullDetailMovie("cw0121766"));
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }
    }
}

