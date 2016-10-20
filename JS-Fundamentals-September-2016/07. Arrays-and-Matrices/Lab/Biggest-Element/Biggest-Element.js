"use strict";

function biggestElement(array) {
    let matrix = array
        .map(x => x
            .split(' ')
            .map(Number)
        );

    let biggestNumber = Number.NEGATIVE_INFINITY;
    matrix.forEach(row => row
        .forEach(col => biggestNumber = Math.max(biggestNumber, col) ));

    console.log(biggestNumber);
}

biggestElement(['20 50 10', '8 33 145']);