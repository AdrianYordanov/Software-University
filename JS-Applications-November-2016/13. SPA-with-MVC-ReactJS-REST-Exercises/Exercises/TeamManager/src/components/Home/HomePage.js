import React, {Component} from 'react';
import {Link} from 'react-router';

export default class HomePage extends Component {
    render() {
        let message = <p>You are currently not logged in. Please, log in or register to view team options.</p>;

        if (sessionStorage.getItem('username')) {
            if (sessionStorage.getItem('teamId')) {
                message = <Link to={"/catalog/" + sessionStorage.getItem('teamId')}>Go to my team</Link>
            } else {
                message = <p>You are currently not a member of a team. View the <Link to="/catalog">catalog</Link> to join or create one.</p>;
            }
        }
        return (
            <div>
                <h1>Home Page</h1>
                {message}
            </div>
        );
    }
}