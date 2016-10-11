"use strict";

function binaryLogarithm(array) {
    for(let element of array) {
        let number = Number(element);
        console.log(Math.log2(number));
    }
}

binaryLogarithm(['5', '1', '3']);