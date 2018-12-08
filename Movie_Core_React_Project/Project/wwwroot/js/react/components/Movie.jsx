import React from 'react';
import ReactDOM from 'react-dom';
import axios from 'axios';

export default class Movie extends React.Component {
    render() {
        let img = this.props.image;
        return (
            <div>
                <div class="card">
                    <div class="image">
                        <img src="/images/avatar2/large/matthew.png">
                     </div>
                        <div class="content">
                            <div class="header">Matt Giampietro</div>
                            <div class="meta">
                                <a>Friends</a>
                            </div>
                            <div class="description">
                                Matthew is an interior designer living in New York.
                        </div>
                        </div>
                        <div class="extra content">
                            <span class="right floated">
                                Joined in 2013
                             </span>
                            <span>
                                <i class="user icon"></i>
                                75 Friends
                             </span>
                        </div>
                    </div>
            </div>
        );
    }
}



