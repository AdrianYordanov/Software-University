"use strict";
let data = require("./data");

function sort(property) {
    return data.sort((a, b) => a[property].toString().localeCompare(b[property].toString()))
}

function filter(property, value) {
    return data
        .filter(element => element.hasOwnProperty(property))
        .filter(element => element[property] == value)
}

exports.sort = sort;
exports.filter =filter;