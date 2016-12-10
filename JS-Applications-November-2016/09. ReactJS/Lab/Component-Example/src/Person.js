import React, { Component } from 'react';
import './Person.css';

class Person extends Component {
    render() {
        return (
            <div>
                <h1>{this.props.name}'s Page</h1>
                <p>Tel. {this.props.phone}</p>
            </div>
        )
    }
}

export default Person;