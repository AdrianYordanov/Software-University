"use strict";

function diagonalAttack(input) {
    let matrix = input.map(row => row.split(" ").map(Number));
    let main = 0, secondary = 0;

    for (let row = 0; row < matrix.length; row++) {
        main += matrix[row][row];
        secondary += matrix[row][matrix[row].length - row - 1];
    }

    if (main == secondary) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (row == col || row + col + 1 == matrix.length) {
                    continue;
                }
                matrix[row][col] = main;
            }
        }
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}

diagonalAttack(['5 3 12 3 1', '11 4 23 2 5', '101 12 3 21 10', '1 4 5 2 2', '5 22 33 11 1']);