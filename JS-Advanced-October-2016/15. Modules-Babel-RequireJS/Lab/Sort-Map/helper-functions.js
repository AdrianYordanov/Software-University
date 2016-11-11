"use strict";

let helper = (function () {
    function sortingTheKeys(map) {
        let result = new Map();
        [...map.entries()]
            .sort((a, b) => a[0].toString().localeCompare(b[0].toString()))
            .forEach(couple => result.set(couple[0], couple[1]));
        return result;
    }

    function sortingWithMethod(map, method) {
        let result = new Map();
        [...map.entries()]
            .sort(method)
            .forEach(couple => result.set(couple[0], couple[1]));
        return result;
    }

    return {
        sortingTheKeys: sortingTheKeys,
        sortingWithMethod: sortingWithMethod
    }
})();

exports.helper = helper;