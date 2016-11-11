"use strict";

let helper = require("./helper-functions").helper;

function mapSort(map, sortMethod) {
    let result;

    if (sortMethod) {
        result = helper.sortingWithMethod(map, sortMethod)
    } else {
        result = helper.sortingTheKeys(map);
    }

    return result;
}

module.exports = mapSort;