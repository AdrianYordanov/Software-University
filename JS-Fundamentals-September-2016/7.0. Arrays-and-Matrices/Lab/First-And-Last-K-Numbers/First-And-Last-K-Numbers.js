"use strict";

function firstAndLastK(array) {
    let numbers = array.map(Number);
    let k = array.shift();

    let firstSlice = array.slice(0, 0 + k);
    let secondSlice = array.slice(array.length - k, array.length);

    console.log(firstSlice.join(', '));
    console.log(secondSlice.join(', '));
}

firstAndLastK(['2', '7', '8', '9']);