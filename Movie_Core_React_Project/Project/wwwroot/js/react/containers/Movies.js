import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import Movie from '../components/Movie';
import MovieDetails from '../components/MovieDetails';
import { Card, Button, Divider, Grid, Header, Icon, Search, Segment } from 'semantic-ui-react';

class App extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            movies: [],
            cheapestFilmWorld: {},
            cheapestCinemaWorld: {},
            selectedMovie: {},
            isSelectedMovie: false,
            source: "",
            error: false
        }
        this.selectedMovieDetails = this.selectedMovieDetails.bind(this);
        this.close = this.close.bind(this);
    }

    componentDidMount() {
        this.fetchCheapestFromFilmWorld();
        this.fetchCheapestFromCinemaWorld();
        this.fetchData();
    }

    fetchData() {
        axios.get('/api/Movie/GetAllMovies')
            .then(res => {
                let data = [];
                let result = res.data;
                result.forEach((item, index) => {
                    data.push(item);
                })
                this.setState({
                    movies: data
                })

            })
            .catch(error => {
                this.setState({ error: true });
            });
    }

    fetchCheapestFromCinemaWorld() {
        let apiName = "cinemaworld";
        axios({
            url: '/api/Movie/GetCheapestMoviesFromApi?apiName=' + apiName,
            method: 'get'
        }).then(res => {
            let result = res.data;
            let c = Object.assign({}, ...result);
            this.setState({
                cheapestCinemaWorld: c
            })
        }).catch(error => {
            this.setState({ error: true });
        });
    }

    fetchCheapestFromFilmWorld() {
        let apiName = "filmworld";
        axios({
            url: '/api/Movie/GetCheapestMoviesFromApi?apiName=' + apiName,
            method: 'get'
        }).then(res => {
            let result = res.data;
            let f = Object.assign({}, ...result);
            this.setState({
                cheapestFilmWorld: f
            })
        }).catch(error => {
            console.log(error.response)
        });
    }

    selectedMovieDetails(id, source) {
        let self = this;
        axios({
            url: '/api/Movie/GetFullDetailMovie?Id=' + id,
            method: 'get'
        }).then(res => {
            let result = res.data;
            let f = Object.assign({}, result);

            self.setState({
                isSelectedMovie: true,
                selectedMovie: f,
                source: source
            });
        })
    }
    close() {
        this.setState({
            isSelectedMovie: false
        });
    }
    render() {
        let cinema = this.state.cheapestCinemaWorld;
        let film = this.state.cheapestFilmWorld;
        let modal = null;
        if (this.state.isSelectedMovie === true) {
            console.log(this.state.selectedMovie);
        }

        let selectedMovieDetails = this.state.selectedMovie;
        return (
            <div>
                {this.state.isSelectedMovie &&
                    <MovieDetails
                        isSelectedMovie={this.state.isSelectedMovie}
                        selectedMovie={selectedMovieDetails}
                        close={this.close}
                    />
                }
                <div style={{ marginTop: "1rem" }} >
                    <div className="ui grid">
                        <div className="eight wide column">
                            <h4> Cheapest Movies From Cinema World </h4>
                            <Card.Group itemsPerRow={2}>
                                {this.state.cheapestCinemaWorld ?
                                    <Movie
                                        key={cinema.id}
                                        id={cinema.id}
                                        title={cinema.title}
                                        price={cinema.price}
                                        isPrice="true"
                                        source={cinema.source}
                                        image={cinema.poster}
                                        selectedMovie={this.selectedMovieDetails} /> : (<div><p>Nothong loaded</p></div>)
                                }
                            </Card.Group>

                        </div>

                        <div className="eight wide column">
                            <h4> Cheapest Movies From Film World </h4>
                            <Card.Group itemsPerRow={2}>
                                {this.state.cheapestFilmWorld ?
                                    <Movie
                                        key={film.id}
                                        id={film.id}
                                        title={film.title}
                                        price={film.price}
                                        isPrice="true"
                                        source={film.source}
                                        image={film.poster}
                                        selectedMovie={this.selectedMovieDetails} /> : (<div><p>Nothong loaded</p></div>)
                                }
                            </Card.Group>
                        </div>
                    </div>
                </div>
                <div style={{ marginTop: "4rem" }} >
                    <h4>All Movies</h4>
                    <div className="ui segment">
                        <Card.Group itemsPerRow={4}>
                            {this.state.movies.map(movie =>
                                <Movie
                                    key={movie.id}
                                    id={movie.id}
                                    title={movie.title}
                                    price={movie.price}
                                    source={movie.source}
                                    image={movie.poster}
                                    isPrice="false"
                                    selectedMovie={this.selectedMovieDetails}

                                />)
                            }
                        </Card.Group>
                    </div >
                </div >
            </div >
        )
    }
}
export default App;


