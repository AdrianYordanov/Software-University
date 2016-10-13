"use strict";

function diagonalSum(array) {
    let matrix = array
        .map(x => x.split(' ').map(Number));

    let leftToRight = 0,
        rightToLeft = 0;

    for (let row = 0; row < matrix.length; row++) {
        leftToRight += matrix[row][row];
        rightToLeft += matrix[row][matrix.length - 1 - row];
    }

    console.log(`${leftToRight} ${rightToLeft}`);
}

diagonalSum(['20 40', '10 60']);