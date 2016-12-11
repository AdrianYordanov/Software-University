import React, {Component} from 'react';
import Greeting from '../common/Greeting';

export default class Header extends Component {
    render() {
        return (
            <div className="jumbotron">
                <h1>Team Manager</h1>
                <Greeting user={this.props.user}/>
                {this.props.children}
            </div>
        );
    }
}