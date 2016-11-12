"use strict";

let Article = require("./article.js");

class TableArticle extends Article {
    constructor(title, content) {
        super(title, content);

        this.headings = null;
        this.data = null;
    }

    loadData(headings, data) {
        this.headings = headings;
        this.data = data;
    }

    getElementString() {
        let table = $('<table>').addClass('data');
        let tableHead = $('<tr>');

        for (let heading of this.headings) {
            tableHead.append(
                $('<th>').text(heading)
            );
        }

        table.append(tableHead);

        for (let obj of this.data) {
            let row = $('<tr>');

            for (let heading of this.headings) {
                let property = heading
                    .replace(/\s+/g, '')
                    .toLowerCase();
                row.append(
                    $('<td>').text(obj[property])
                );
            }

            table.append(row);
        }

        let result = $(super.getElementString());
        result.append($('<div>')
            .addClass('table')
            .append(table)
        );

        return result;
    }
}

module.exports = TableArticle;