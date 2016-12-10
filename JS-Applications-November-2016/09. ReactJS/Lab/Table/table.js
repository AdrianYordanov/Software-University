"use strict";

let Table = React.createClass({
    render: function () {
        let titles =
            this.props.columns.map(function (column, i) {
                return <th key={i}>{column}</th>;
            });
        let rows = this.props.rows.map(function (row, r) {
            return <tr key={r}>{row.map(function (col, c) {
                return <td key={c}>{col}</td>
            })}</tr>;
        });
        return (
            <table>
                <thead>
                <tr>{titles}</tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        )
    }
});
