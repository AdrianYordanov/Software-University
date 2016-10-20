"use strict";

function equalNeighbours(array) {
    let matrix = array.map(x => x.split(' '));
    let counter = 0;

    for (let row = 0; row < matrix.length - 1; row++) {
        for (let col = 0; col < matrix[row].length; ++col) {
            if (matrix[row][col] == matrix[row][col + 1])
                ++counter;
            if (matrix[row][col] == matrix[row + 1][col])
                ++counter;
        }
    }

    for (let col = 0; col < matrix[matrix.length - 1].length; ++col) {
        if (matrix[matrix.length - 1][col] == matrix[matrix.length - 1][col + 1])
            ++counter;
    }

    console.log(counter);
}

equalNeighbours(['test yes yo ho', 'well done yo 6', 'not done yet 5']);