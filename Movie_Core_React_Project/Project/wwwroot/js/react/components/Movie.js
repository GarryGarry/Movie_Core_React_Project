import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';
import { Card, Icon, Image } from 'semantic-ui-react';
import imgDefault from '../img/altPhoto.jpg';

export default class Movie extends React.Component {
    constructor(props) {
        super(props); 
        this.state = {
            showDefault :false
        }
    }

    render() {
        let price = "";
        if (this.props.isPrice == "true" && this.props.price) {
            price = <Icon name="dollar sign">{this.props.price}</Icon>
        }
        var img = this.state.showDefault ? imgDefault : (this.props.image ? this.props.image : imgDefault);
        var title = this.props.title ? this.props.title : (<div className="loader">Loading...</div>)
        return (
            <Card onClick={() => this.props.selectedMovie(this.props.id, this.props.source)}>
                <Image
                    src={img}
                    style={{ height: "280px", width: "100%" }}
                    alt="No Image"
                    onError={() => this.setState({ showDefault: true  })}  >
                    </Image>
                    <Card.Content>
                    <Card.Header>{title}</Card.Header>
                    <Card.Header>{price}</Card.Header>
                    <Card.Description>{this.props.source}</Card.Description>
                    </Card.Content>
                    <Card.Content extra>
                    <a><Icon name='big film'> </Icon> Details</a>
                    </Card.Content>
                </Card>         
        );
    }
}

//onClick={() => this.props.selectedMovie(this.props.id)}



