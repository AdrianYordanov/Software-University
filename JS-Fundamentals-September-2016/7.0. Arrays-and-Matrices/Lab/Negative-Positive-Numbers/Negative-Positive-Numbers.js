"use strict";

function negativePositiveNumbers(array) {
    let numbers = array.map(Number);
    let newArray = [];

    for (let number of numbers) {
        if (number < 0)
            newArray.unshift(number);
        else
            newArray.push(number);
    }

    newArray.forEach(x => console.log(x));
}

negativePositiveNumbers(['7', '-2', '8', '9']);