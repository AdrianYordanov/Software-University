"use strict";

function run(array) {
    let numbers = array.map(Number);
    let sortedNumbers = numbers.sort((a, b) => b - a);

    for(let i = 0; i < 3 && i < sortedNumbers.length; ++i) {
        console.log(sortedNumbers[i]);
    }
}

run(['20', '-5']);