"use strict";

function figureOfFourSquares([number]) {
    let n = Number(number);
    let squares = '';
    let loopRepeats = n;

    if(loopRepeats % 2 == 0) {
        --loopRepeats;
    }

    for (let i = 0; i < loopRepeats; ++i) {
        if (i == 0 || i == loopRepeats - 1 || i + 1 == Math.ceil(n / 2)) {
            squares += '+' + '-'.repeat(n - 2) + '+' + '-'.repeat(n - 2) + '+\n';
        } else {
            squares += '|' + ' '.repeat(n - 2) + '|' + ' '.repeat(n - 2) + '|\n';
        }
    }

    console.log(squares);
}

figureOfFourSquares(['4']);