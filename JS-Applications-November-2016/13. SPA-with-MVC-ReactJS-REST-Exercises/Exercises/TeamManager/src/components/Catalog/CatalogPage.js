import React, {Component} from 'react';
import Team from './Team';
import {loadTeams} from '../../models/team';
import {Link} from 'react-router';
//import observer from '../../models/observer';

export default class CatalogPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            teams: []
        };
        this.bindEventHandlers();
    }

    bindEventHandlers() {
        this.onLoadSuccess = this.onLoadSuccess.bind(this);
    }

    onLoadSuccess(response) {
        // Display teams
        this.setState({teams: response})
    }

    componentDidMount() {
        // Request list of teams from the server
        loadTeams(this.onLoadSuccess);
    }

    render() {
        let createLink = null;
        if (!sessionStorage.getItem('teamId')) {
            createLink = <Link to="/create" className="btn btn-default">Create team</Link>
        }

        return (
            <div>
                <h1>Catalog Page</h1>
                {createLink}
                <div>
                    {this.state.teams.map((e, i) => {
                        return <Team key={i} name={e.name} id={e._id} description={e.comment}/>
                    })}
                </div>
            </div>
        );
    }
}