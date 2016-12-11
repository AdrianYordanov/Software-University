import React, {Component} from 'react';
import {Link} from 'react-router';
import './Team.css';

export default class Team extends Component {
    render() {
        return(
            <Link to={"/catalog/" + this.props.id} className="team-box">
                <span className="spanner">Team name</span>
                <span className="title">{this.props.name}</span>
                <span className="spanner">Description</span>
                <p>{this.props.description || 'No description'}</p>
            </Link>
        )
    }
}