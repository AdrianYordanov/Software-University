"use strict";

function stringOfNumbers([n]) {
    let stringResult = '';

    for(let i = 1; i <= Number(n); ++i) {
        stringResult += i;
    }

    console.log(stringResult);
}

stringOfNumbers(['11']);