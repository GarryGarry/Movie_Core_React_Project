import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Movie from '../components/Movie.jsx';


class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            movies: [
                {
                    "Title": "Star Wars: Episode IV - A New Hope",
                    "Price": "22.5",
                    "ID": "cw0076759",
                    "Source": "cinemaworld",
                    "Poster": "http://ia.media-imdb.com/images/M/MV5BOTIyMDY2NGQtOGJjNi00OTk4LWFhMDgtYmE3M2NiYzM0YTVmXkEyXkFqcGdeQXVyNTU1NTcwOTk@._V1_SX300.jpg"
                },
                {
                    "Title": "Star Wars: Episode V - The Empire Strikes Back",
                    "Price": "30.04",
                    "ID": "cw0080684",
                    "Source": "cinemaworld",
                    "Poster": "http://ia.media-imdb.com/images/M/MV5BMjE2MzQwMTgxN15BMl5BanBnXkFtZTcwMDQzNjk2OQ@@._V1_SX300.jpg"
                }
            ],

        }
    }

    componentDidMount() {
        this.fetchData();
    }

    fetchData() {
        //    axios.get('https://react-my-burger-be46c.firebaseio.com/ingredients.json')
        //        .then(res => {
        //            this.setState({ movies: res.data })
        //        })
        //        .catch(error => {
        //            this.setState({ error: true });
        //        });
    }

    render() {
        //const movies = { ...this.state.movies };
        let eachMovie = null;
        return (
            <div>
                <div class="ui link cards" >
                    {this.state.movies.map(movie =>
                        <Movie key={movie.ID} title={movie.Title} price={movie.Price} source={movie.Source} image={movie.Poster} />)
                    }
                </div>
            </div >
        )
    }
}
export default App


