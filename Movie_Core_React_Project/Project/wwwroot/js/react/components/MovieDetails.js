import React from 'react'
import { Button, Header, Image, Modal, Icon } from 'semantic-ui-react'
import imgDefault from '../img/altPhoto.jpg';

const style = {
    width: "500px",
    height: "550px",
    marginLeft: "40rem",
    marginTop: "8rem"
}

class MovieDetails extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            showDefault: false
        }
    }
    render() {
        var img = this.state.showDefault ? imgDefault : (this.props.selectedMovie.poster ? this.props.selectedMovie.poster : imgDefault);
        let price = <Icon name="dollar sign">{this.props.selectedMovie.price}</Icon>
        return (
            <Modal open={this.props.isSelectedMovie} style={style} centered={true} >
                <Modal.Header>Deatils</Modal.Header>
                <Modal.Content image>
                    <Image wrapped size='medium'
                        src={this.props.selectedMovie.poster}
                        src={img}
                        
                        onError={() => this.setState({ showDefault: true })} />
                    <Modal.Description>
                        <Header>{this.props.selectedMovie.title}</Header>
                        <p>{price}</p>
                        <p>{this.props.selectedMovie.actors}</p>
                        <p>{this.props.selectedMovie.rated}</p>
                        <p>{this.props.selectedMovie.rating}</p>
                        <p>{this.props.selectedMovie.actors}</p>
                        <p>{this.props.selectedMovie.language}</p>
                        <p>{this.props.selectedMovie.genres}</p>
                        <p>{this.props.selectedMovie.director}</p>
                        <p>{this.props.selectedMovie.year}</p>
                        <p>{this.props.source}</p>
                    </Modal.Description>
                </Modal.Content>
                <Modal.Actions>
                    <Button color='red' onClick={this.props.close}>
                        <Icon name='remove' /> Close
                     </Button>

                </Modal.Actions>
            </Modal>)
    }
}

export default MovieDetails;