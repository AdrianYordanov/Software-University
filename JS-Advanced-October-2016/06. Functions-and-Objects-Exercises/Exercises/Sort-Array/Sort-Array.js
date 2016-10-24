"use strict";

function sortArray(numbers, sortType) {
    let sortWays = {
        'asc': (a, b) => a - b,
        'desc': (a, b) => b - a
    };

    return numbers.sort(sortWays[sortType]);
}

sortArray([14, 7, 17, 6, 8], 'asc');