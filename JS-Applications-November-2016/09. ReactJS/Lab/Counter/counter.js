"use strict";

let Counter = React.createClass({
    getInitialState: function () {
        return {
            count: Number(this.props.start),
            style: {color: ''}
        }
    },
    incrementCount: function () {
        this.changeCount(+1, 'blue')
    },
    decrementCount: function () {
        this.changeCount(-1, 'red')
    },
    changeCount: function (delta, color) {
        // This will update the component UI
        this.setState({
            count: this.state.count + delta,
            style: {color: color}
        });
    },
    render: function () {
        return <div>
            Count: <span style={this.state.style}>{this.state.count}</span>
            <button type="button" onClick={this.incrementCount}>+
            </button>
            <button type="button" onClick={this.decrementCount}>-
            </button>
        </div>
    }
});
